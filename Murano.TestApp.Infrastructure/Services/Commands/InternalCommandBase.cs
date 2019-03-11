using Murano.TestApp.Infrastructure.Services.Requests;
using Murano.TestApp.Infrastructure.Services.Responses;
using Murano.TestApp.Infrastructure.Services.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Murano.TestApp.Infrastructure.Services.Commands
{
    public abstract class InternalCommandBase<TUnitOfWork, TInternalRequest, TInternalResponse> : IInternalCommand<TInternalRequest, TInternalResponse>
            where TInternalRequest : class, IRequest
            where TInternalResponse : class, IResponse, new()
            where TUnitOfWork : IDisposable
    {
        private readonly TUnitOfWork _unitOfWork;

        private TInternalRequest _request;
        private TInternalResponse _response;


        protected virtual TUnitOfWork UnitOfWork { get { return _unitOfWork; } }
        protected virtual TInternalRequest Request { get { return _request; } }
        protected virtual TInternalResponse Response { get { return _response; } }

        public InternalCommandBase(TUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        protected abstract void Execute(CancellationToken cancellationToken);

        public virtual void ValidateRequestCustom()
        {
        }

        public virtual TInternalResponse Execute(TInternalRequest request, CancellationToken cancellationToken)
        {
            _response = new TInternalResponse();
            _response.ArgumentErrors = new ArgumentErrorsCollection();

            _request = request;

            using (_unitOfWork)
            {
                if (!Authorize())
                {
                    return ErrorResponse(new Error(CommonErrorCode.UserNotAuthorized));
                }

                if (ValidateRequest())
                {
                    try
                    {
                        Execute(cancellationToken);
                        if (Response.Error == null && Response.ArgumentErrors.Count == 0)
                        {
                            Response.IsSuccess = true;
                        }
                    }
                    catch (Exception e)
                    {
                        //ErrorLogUtils.AddError(e);
                        Response.Error = new Error(CommonErrorCode.InternalServerError, e.Message);
                    }
                }

                return Response;
            }
        }

        protected virtual bool ValidateRequest()
        {
            DtoValidator.VisitAndValidateProperties(_request, Response.ArgumentErrors as ArgumentErrorsCollection);

            if (Response.ArgumentErrors.Count == 0)
                ValidateRequestCustom();

            return Response.ArgumentErrors.Count == 0;
        }

        protected virtual bool Authorize()
        {
            return true;
        }

        protected TInternalResponse ErrorResponse(Error error, ArgumentErrorsCollection argumentErrors = null,
            string extraMessage = null)
        {
            Response.IsSuccess = false;

            Response.Error = error;

            if (argumentErrors != null)
            {
                foreach (var argumentError in argumentErrors)
                {
                    Response.ArgumentErrors[argumentError.ArgumentName] = argumentError;
                }
            }

            if (extraMessage != null)
                Response.Error.ErrorMessage += Environment.NewLine + extraMessage;

            return Response;
        }

    }
}
