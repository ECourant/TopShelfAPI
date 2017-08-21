using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TopShelfAPI
{
    /// <summary>
    /// Represents the inventory object of a TopShelf bin.
    /// </summary>
    public class BinInventory : Base.TBin
    {
        /// <summary>
        /// Gets or sets the QTY of an item inside this bin.
        /// </summary>
        [JsonProperty("BinQty", NullValueHandling = NullValueHandling.Include, DefaultValueHandling = DefaultValueHandling.Include)]
        public double BinQTY { get; set; }
    }
}
