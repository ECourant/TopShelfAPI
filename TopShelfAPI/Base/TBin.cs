using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TopShelfAPI.Base
{
    /// <summary>
    /// The base class for TopShelf's Bin object, all bin objects are based off of this class.
    /// </summary>
    public class TBin : TEnumerableItem
    {
        /// <summary>
        /// Gets or sets the bin's warehouse location ID.
        /// </summary>
        [JsonProperty("WarehouseLocationID", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int? WarehouseLocationID { get; set; }

        /// <summary>
        /// Gets or sets the bin's warehouse name or bin name.
        /// </summary>
        [JsonProperty("WHName", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string WHName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("bCommonLocation")]
        public bool CommonLocation { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("WavePickOrder")]
        public int WavePickOrder { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("ParentWarehouseLocationID", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int? ParentWarehouseLocationID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("InventoryIsDeviceHidden")]
        public bool InventoryIsDeviceHidden { get; set; }

        [JsonIgnore]
        internal override int? ItemID { get => this.WarehouseLocationID; set => this.WarehouseLocationID = value; }

        [JsonIgnore]
        internal override string ItemName { get => this.WHName; set => this.WHName = value; }
    }
}
