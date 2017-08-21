using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TopShelfAPI_Unit_Tests
{
    [TestClass]
    public class BinTesting
    {
        public static string APIKey = "";
        public static string APIPassword = "";


        [TestMethod]
        public void GetBinsTestMethod1()
        {
            TopShelfAPI.TSConnection TS = new TopShelfAPI.TSConnection(
                new TopShelfAPI.TSCredential(APIKey, APIPassword),
                new TopShelfAPI.TSConfiguration()
                {
                    RequestTimeout = TimeSpan.FromMinutes(10),
                });
            int NumberOfRequestsToMake = 5;
            for (int Request = 0; Request < NumberOfRequestsToMake; Request++)
            {
                Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(TS.Bins.GetBins(Request + 1, 5), Newtonsoft.Json.Formatting.Indented));
            }
        }
        [TestMethod]
        public void GetBinsTestMethod2()
        {
            TopShelfAPI.TSConnection TS = new TopShelfAPI.TSConnection(
                new TopShelfAPI.TSCredential(APIKey, APIPassword),
                new TopShelfAPI.TSConfiguration()
                {
                    RequestTimeout = TimeSpan.FromMinutes(10),
                });
            TopShelfAPI.LocationBins[] Bins = TS.Bins.GetBins();
        }
    }
}
