using Microsoft.Practices.TransientFaultHandling;
using Murano.TestApp.Infrastructure.ExternalApi.Responses;
using RestSharp;
using RestSharp.Serialization.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Murano.TestApp.Infrastructure.ExternalApi
{
    public class ApiClientBase
    {
        public class ResponseErrorDetectionStrategy : ITransientErrorDetectionStrategy
        {
            public bool IsTransient(Exception ex)
            {
                return true;
            }
        }

        public ApiClientBase(string apiBaseUrl)
        {
            ApiBaseUrl = apiBaseUrl;
            Client = new RestClient(ApiBaseUrl);
        }

        public string ApiBaseUrl { get; set; } = string.Empty;

        public RestClient Client { get; set; } = null;

        public JsonDeserializer Deserializer { get; set; } = new JsonDeserializer();

        protected RestRequest InitRequest(string resource, Method method)
        {
            return new RestRequest(resource, method) { RequestFormat = DataFormat.Json };
        }

        protected T GetResponse<T>(RestRequest request, CancellationToken cancellationToken, Func<IRestResponse, T> deserealize = null) where T : ResponseBase, new ()
        {
            var retryStrategy = new Incremental(3, TimeSpan.FromMilliseconds(100), TimeSpan.FromMilliseconds(100));
            var policy = new RetryPolicy(new ResponseErrorDetectionStrategy(), retryStrategy);

            Exception lastException = null;

            IRestResponse rawResponse = null;

            try
            {
                return policy.ExecuteAction(() =>
                {
                    rawResponse = Client.ExecuteTaskAsync(request, cancellationToken).Result;

                    if (rawResponse.ResponseStatus != ResponseStatus.Completed || rawResponse.StatusCode != HttpStatusCode.OK)
                    {
                        throw new Exception("Response status is: " + rawResponse.ResponseStatus, rawResponse.ErrorException);
                    }
  
                    var response = deserealize == null ? Deserializer.Deserialize<T>(rawResponse) : deserealize(rawResponse);

                    response.IsSuccess = rawResponse.StatusCode == HttpStatusCode.OK;

                    return response;
                });
            }

            catch (Exception e)
            {
                lastException = e;

                if (rawResponse != null)
                {
                    lastException = new AggregateException(e, new Exception(rawResponse.Content));
                }
            }

            //ErrorLogUtils.AddError(lastException);

            var errorResponse = new T
            {
                ErrorMessage = String.Format("Last error message: {0}", lastException.Message)
            };

            return errorResponse;
        }

    }
}
