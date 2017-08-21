using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TopShelfAPI_Unit_Tests
{
    [TestClass]
    public class VendorsTesting
    {
        public static string APIKey = "";
        public static string APIPassword = "";

        [TestMethod]
        public void GetVendors1()
        {            
            TopShelfAPI.TSConnection TS = new TopShelfAPI.TSConnection(
                new TopShelfAPI.TSCredential(APIKey, APIPassword),
                new TopShelfAPI.TSConfiguration()
                {
                    RequestTimeout = TimeSpan.FromMinutes(10),
                });
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(TS.Vendors.GetVendors(), Newtonsoft.Json.Formatting.Indented));
        }

        [TestMethod]
        public void GetVendors2()
        {
            TopShelfAPI.TSConnection TS = new TopShelfAPI.TSConnection(
                new TopShelfAPI.TSCredential(APIKey, APIPassword),
                new TopShelfAPI.TSConfiguration()
                {
                    RequestTimeout = TimeSpan.FromMinutes(10),
                });
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(TS.Vendors[34], Newtonsoft.Json.Formatting.Indented));
        }

        [TestMethod]
        public void GetVendors3()
        {
            TopShelfAPI.TSConnection TS = new TopShelfAPI.TSConnection(
                new TopShelfAPI.TSCredential(APIKey, APIPassword),
                new TopShelfAPI.TSConfiguration()
                {
                    RequestTimeout = TimeSpan.FromMinutes(10),
                });
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(TS.Vendors["Great Planes"], Newtonsoft.Json.Formatting.Indented));
        }

        //[TestMethod]
        public void GetVendors4()
        {
            var Config = new TopShelfAPI.TSConfiguration()
            {
                RequestTimeout = TimeSpan.FromMinutes(10)
            };
            Config.RequestLimit.MinDelayBetweenRequests = TimeSpan.FromMilliseconds(1);
            Config.RequestLimit.MaxCallsPerMinute = 1000;
            TopShelfAPI.TSConnection TS = new TopShelfAPI.TSConnection(
                new TopShelfAPI.TSCredential(APIKey, APIPassword),
                Config
                );
            int NumberOfRequests = 150;
            for (int Request = 0; Request <= NumberOfRequests; Request++)
            {
                Console.Write("SENDING REQUEST " + Request);
                Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(TS.Vendors.GetVendors(), Newtonsoft.Json.Formatting.Indented));
            }
        }
    }
}
