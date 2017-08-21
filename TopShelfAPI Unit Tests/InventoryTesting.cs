using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TopShelfAPI_Unit_Tests
{
    [TestClass]
    public class InventoryTesting
    {
        public static string APIKey = "";
        public static string APIPassword = "";

        [TestMethod]
        public void GetInventory1()
        {
            TopShelfAPI.TSConnection TS = new TopShelfAPI.TSConnection(
               new TopShelfAPI.TSCredential(APIKey, APIPassword),
               new TopShelfAPI.TSConfiguration()
               {
                   RequestTimeout = TimeSpan.FromMinutes(10),
               });
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(TS.Inventory.GetBinInventory("JIT%"), Newtonsoft.Json.Formatting.Indented));
        }
    }
}
