using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TopShelfAPI
{
    /// <summary>
    /// Represents an inventory object for locations.
    /// </summary>
    public class LocationInventory : Base.TLocation
    {
        /// <summary>
        /// Initializes a new location inventory object.
        /// </summary>
        public LocationInventory()
        {
            this.SerialNumbers = new List<string>();
            this.Bins = new Base.TEnumerable<BinInventory>();
        }

        /// <summary>
        /// Gets or sets the list of serial numbers that are within this location.
        /// </summary>
        [JsonProperty("SerialNumbers", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Include)]
        public List<string> SerialNumbers { get; set; }

        /// <summary>
        /// Gets or sets the list of bins that are within this location.
        /// </summary>
        [JsonIgnore]
        public Base.TEnumerable<BinInventory> Bins { get; set; }

        [JsonProperty("Bins", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        private BinInventory[] BinsHandler
        {
            get => (this.Bins ?? new Base.TEnumerable<BinInventory>()).ToArray();
            set => this.Bins = value;
        }
    }
}
