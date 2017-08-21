using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TopShelfAPI
{
    /// <summary>
    /// Represents a bin object in TopShelf.
    /// </summary>
    public class Bin : Base.TBin, Basics.ITopShelfObject
    {
        /// <summary>
        /// Gets or sets the LocationID of the bin.
        /// </summary>
        [JsonProperty("LocationID", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int? LocationID { get; set; }

        /// <summary>
        /// Gets or sets the LocationName of the bin.
        /// </summary>
        [JsonProperty("LocationName", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string LocationName { get; set; }

        /// <summary>
        /// Gets or sets the type ID of the bin.
        /// </summary>
        [JsonProperty("BinTypeID", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int? BinTypeID { get; set; }
        
        /// <summary>
        /// Gets or sets the type name of the bin.
        /// </summary>
        [JsonProperty("BinTypeName", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string BinTypeName { get; set; }

        /// <summary>
        /// Gets or sets the name of the parent bin.
        /// </summary>
        [JsonProperty("ParentBinName", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string ParentBinName { get; set; }
    }
}
