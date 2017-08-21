using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TopShelfAPI
{
    /// <summary>
    /// Represents a <see cref="Part"/>s put away bin in the warehouse.
    /// </summary>
    public class PutAwayBin : Base.TBin
    {
        /// <summary>
        /// Gets the planned QTY.
        /// </summary>
        [JsonIgnore]
        public double PlannedQTY { get; private set; }

        /// <summary>
        /// Gets whether or not the put away bin is a common location.
        /// </summary>
        [JsonIgnore]
        public bool CommonLocation { get; private set; }

        /// <summary>
        /// Gets the order for wave picking.
        /// </summary>
        [JsonIgnore]
        public int WavePickOrder { get; private set; }

        /// <summary>
        /// Gets the parent warehouse location id of the parent bin.
        /// </summary>
        [JsonIgnore]
        public int? ParentWarehouseLocationID { get; private set; }

        /// <summary>
        /// Gets whethor or not the inventory in this bin is device hidden.
        /// </summary>
        [JsonIgnore]
        public bool InventoryIsDeviceHidden { get; private set; }

        /// <summary>
        /// Gets the total QTY inside this bin.
        /// </summary>
        [JsonIgnore]
        public double BinQTY { get; private set; }

        [JsonProperty("PlannedQTY")]
        private double PlannedQTYSetter
        {
            set => this.PlannedQTY = value;
        }

        [JsonProperty("bCommonLocation")]
        private bool CommonLocationSetter
        {
            set => this.CommonLocation = value;
        }

        [JsonProperty("WavePickOrder")]
        private int WavePickOrderSetter
        {
            set => this.WavePickOrder = value;
        }

        [JsonProperty("ParentWarehouseLocationID")]
        private int? ParentWarehouseLocationIDSetter
        {
            set => this.ParentWarehouseLocationID = value;
        }

        [JsonProperty("InventoryIsDeviceHidden")]
        private bool InventoryIsDeviceHiddenSetter
        {
            set => this.InventoryIsDeviceHidden = value;
        }

        [JsonProperty("BinQty")]
        private double BinQTYSetter
        {
            set => this.BinQTY = value;
        }
    }
}
