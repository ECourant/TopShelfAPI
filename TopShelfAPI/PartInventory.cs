using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TopShelfAPI
{
    /// <summary>
    /// Represents the inventory object for parts.
    /// </summary>
    public class PartInventory : Base.TPart
    {
        /// <summary>
        /// Gets the total QTY of this part that exists in inventory.
        /// </summary>
        [JsonIgnore]
        public double TotalQTY { get; private set; }

        /// <summary>
        /// Gets whether or not the part's QTY has changed since the last time reset_flag was called.
        /// </summary>
        [JsonIgnore]
        public bool NewQTY { get; private set; }

        /// <summary>
        /// Gets or sets the list of client's that this part is in.
        /// </summary>
        [JsonIgnore]
        public Base.TEnumerable<ClientInventory> Clients { get; set; }

        [JsonProperty("TotalQty")]
        private double TotalQTYSetter
        {
            set => this.TotalQTY = value;
        }

        [JsonProperty("NewQty")]
        private bool NewQTYSetter
        {
            set => this.NewQTY = value;
        }

        [JsonProperty("Clients", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        private ClientInventory[] ClientsHandler
        {
            get => (this.Clients ?? new Base.TEnumerable<ClientInventory>()).ToArray();
            set => this.Clients = value;
        }

        /// <summary>
        /// Creates an array of <see cref="InventoryUpdate"/> objects based on the current QTYs in this collection.
        /// </summary>
        /// <param name="inventoryAdjustmentType">The <see cref="InventoryAdjustmentType"/> you are going to send this update as.</param>
        /// <returns>An array of <see cref="InventoryUpdate"/> objects with the specified <see cref="InventoryAdjustmentType"/> and the QTYs defined.</returns>
        public InventoryUpdate[] GetInventoryUpdate(InventoryAdjustmentType inventoryAdjustmentType)
        {
            List<InventoryUpdate> Update = new List<InventoryUpdate>();
            foreach (var Client in this.Clients)
                foreach (var Location in Client.Locations)
                    foreach (var Bin in Location.Bins)
                        Update.Add(new InventoryUpdate(Bin, this, inventoryAdjustmentType, Bin.BinQTY));
            return Update.ToArray();
        }
    }
}
