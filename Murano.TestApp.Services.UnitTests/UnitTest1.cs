using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Murano.TestApp.Domain.Services.FlightsModule.ExternalApi.FlightsApiClient;

namespace Murano.TestApp.Services.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestSearchAirports()
        {
            var api = new FlightsApiClient();
            var response = api.SearchAirports("ANA");

            var success = response.IsSuccess;
        }

        [TestMethod]
        public void TestSearchAirlines()
        {
            var api = new FlightsApiClient();
            var response = api.GetAirlines("UJ");

            var success = response.IsSuccess;
        }

        [TestMethod]
        public void TestSearchRoutes()
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

            var api = new FlightsApiClient();

            var response = api.GetRoutes(cancellationTokenSource.Token, "SVO");

            var success = response.IsSuccess;
        }
    }
}
