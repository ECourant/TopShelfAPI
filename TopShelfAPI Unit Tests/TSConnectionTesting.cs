using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TopShelfAPI_Unit_Tests
{
    [TestClass]
    public class TSConnectionTesting
    {
        public static string APIKey_Blank = "";

        public static string APIPassword_Blank = "";

        public static string APIKey = "test";

        public static string APIPassword = "password";

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateTSConnectionWithBlankCredentials1()
        {
            TopShelfAPI.TSConnection TS = new TopShelfAPI.TSConnection(new TopShelfAPI.TSCredential(APIKey_Blank, APIPassword_Blank));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateTSConnectionWithBlankCredentials2()
        {
            TopShelfAPI.TSConnection TS = new TopShelfAPI.TSConnection(new TopShelfAPI.TSCredential(APIKey, APIPassword_Blank));
        }

        [TestMethod]
        public void CreateTSConnectionWithFilledCredentials1()
        {
            TopShelfAPI.TSConnection TS = new TopShelfAPI.TSConnection(new TopShelfAPI.TSCredential(APIKey, APIPassword));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateTSConnectionWithBadConfig1()
        {
            TopShelfAPI.TSConnection TS = new TopShelfAPI.TSConnection(new TopShelfAPI.TSCredential(APIKey, APIPassword), new TopShelfAPI.TSConfiguration() {  EndpointURL = string.Empty });
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CreateTSConnectionWithBadConfig2()
        {
            TopShelfAPI.TSConnection TS = new TopShelfAPI.TSConnection(new TopShelfAPI.TSCredential(APIKey, APIPassword), new TopShelfAPI.TSConfiguration() { RequestTimeout = TimeSpan.FromMinutes(-10) });
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CreateTSConnectionWithBadConfig3()
        {
            TopShelfAPI.TSConfiguration Config = new TopShelfAPI.TSConfiguration();
            Config.RequestLimit.MaxCallsPerDay = -1;
            Config.RequestLimit.MaxCallsPerMinute = 10;
            TopShelfAPI.TSConnection TS = new TopShelfAPI.TSConnection(new TopShelfAPI.TSCredential(APIKey, APIPassword), Config);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CreateTSConnectionWithBadConfig4()
        {
            TopShelfAPI.TSConfiguration Config = new TopShelfAPI.TSConfiguration();
            Config.RequestLimit.MaxCallsPerDay = 10000;
            Config.RequestLimit.MaxCallsPerMinute = 0;
            TopShelfAPI.TSConnection TS = new TopShelfAPI.TSConnection(new TopShelfAPI.TSCredential(APIKey, APIPassword), Config);
        }

        [TestMethod]
        public void CreateTSConnectionWithGoodConfig1()
        {
            TopShelfAPI.TSConnection TS = new TopShelfAPI.TSConnection(new TopShelfAPI.TSCredential(APIKey, APIPassword), new TopShelfAPI.TSConfiguration() { RequestTimeout = TimeSpan.FromMinutes(10) });
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateTSConnectionWithNull1()
        {
            TopShelfAPI.TSConnection TS = new TopShelfAPI.TSConnection(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateTSConnectionWithNull2()
        {
            TopShelfAPI.TSConnection TS = new TopShelfAPI.TSConnection(new TopShelfAPI.TSCredential(APIKey, APIPassword), null);
        }

        [TestMethod]
        [ExpectedException(typeof(UnauthorizedAccessException))]
        public void TestAPIRequestWithBadCredentials1()
        {
            TopShelfAPI.TSConnection TS = new TopShelfAPI.TSConnection(new TopShelfAPI.TSCredential("TEST", "TEST"));
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(TS.Vendors.GetVendors(), Newtonsoft.Json.Formatting.Indented));
        }

#if DEBUG
        [TestMethod]
        [ExpectedException(typeof(AggregateException))]
        public void TestAPIRequestWithBadEndpoint1()
        {
            TopShelfAPI.TSConnection TS = new TopShelfAPI.TSConnection(new TopShelfAPI.TSCredential("29fbb2e5b1c546f08fa36c284824cf69", "9f411b21afe0465b9e8b98a4c530f1bd"));
            TS.Test.Test();
        }
#endif
    }
}
