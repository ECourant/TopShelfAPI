using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TopShelfAPI_Unit_Tests
{
    [TestClass]
    public class ClientsTesting
    {
        public static string APIKey = "";
        public static string APIPassword = "";
        public static string Endpoint = "http://localhost:55271/";


        [TestMethod]
        public void GetClientsTestMethod1()
        {
            TopShelfAPI.TSConnection TS = new TopShelfAPI.TSConnection(
                new TopShelfAPI.TSCredential(APIKey, APIPassword),
                new TopShelfAPI.TSConfiguration()
                {
                    EndpointURL = Endpoint,
                    RequestTimeout = TimeSpan.FromMinutes(10),
                });
            int NumberOfRequestsToMake = 5;
            Parallel.For(0, NumberOfRequestsToMake, Request =>
            {
                TS.ClientsLocations.GetClients();
            });
        }

        [TestMethod]
        public void GetClientsTestMethod2()
        {
            TopShelfAPI.TSConnection TS = new TopShelfAPI.TSConnection(
                new TopShelfAPI.TSCredential(APIKey, APIPassword),
                new TopShelfAPI.TSConfiguration()
                {
                    //EndpointURL = Endpoint,
                    RequestTimeout = TimeSpan.FromMinutes(10),
                });
            int NumberOfRequestsToMake = 5;
            Parallel.For(1, NumberOfRequestsToMake, Request =>
            {
                Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(TS.ClientsLocations.GetClients(Request, 5), Newtonsoft.Json.Formatting.Indented));
            });
        }
    }
}
