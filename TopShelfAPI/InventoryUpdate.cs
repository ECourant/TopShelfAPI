using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TopShelfAPI
{
    /// <summary>
    /// Represents an inventory update object to be sent to TopShelf.
    /// </summary>
    public class InventoryUpdate : Base.TEnumerableItem, Basics.ITopShelfObject
    {
        /// <summary>
        /// Initializes a new instance of the inventory update object with the <see cref="AdjustmentType"/> set to <see cref="InventoryAdjustmentType.Add"/>.
        /// </summary>
        public InventoryUpdate() : this(new Base.TBin(), new Base.TPart(), InventoryAdjustmentType.Add, 0)
        {
            return;
        }

        /// <summary>
        /// Initializes a new instance of the inventory update object with the provided <see cref="Base.TBin"/> and <see cref="Base.TPart"/>.
        /// </summary>
        /// <param name="bin">The bin that will be updated.</param>
        /// <param name="part">The part that will be updated within that bin.</param>
        /// <param name="adjustmentType">The type of inventory update you are sending.</param>
        /// <param name="qty">The QTY update that will be sent.</param>
        public InventoryUpdate(Base.TBin bin, Base.TPart part, InventoryAdjustmentType adjustmentType, double qty)
        {
            this.Bin = bin;
            this.Part = part;
            this.AdjustmentType = adjustmentType;
            this.QTY = qty;
        }
        
        /// <summary>
        /// Initializes a new instance of the inventory update object with the provided <see cref="Base.TBin.WarehouseLocationID"/> and <see cref="Base.TPart.PartID"/>.
        /// </summary>
        /// <param name="warehouseLocationID">The warehouse location ID of the bin that will be updated.</param>
        /// <param name="partID">The part ID of the part that will be updated within that bin.</param>
        /// <param name="adjustmentType">The type of inventory update you are sending.</param>
        /// <param name="qty">The QTY update that will be sent.</param>
        public InventoryUpdate(int warehouseLocationID, int partID, InventoryAdjustmentType adjustmentType, double qty) : this(new Base.TBin() { WarehouseLocationID = warehouseLocationID }, new Base.TPart() { PartID = partID }, adjustmentType, qty)
        {
            return;
        }

        /// <summary>
        /// Initializes a new instance of the inventory update object with the provided <see cref="Base.TBin.WHName"/> and <see cref="Base.TPart.PartName"/>.
        /// </summary>
        /// <param name="whName">The warehouse name of the bin that will be updated.</param>
        /// <param name="partName">The part name/SKU of the part that will be updated within that bin.</param>
        /// <param name="adjustmentType">The type of inventory update that you are sending.</param>
        /// <param name="qty">The QTY update that will be sent.</param>
        public InventoryUpdate(string whName, string partName, InventoryAdjustmentType adjustmentType, double qty) : this(new Base.TBin() { WHName = whName }, new Base.TPart() { PartName = partName }, adjustmentType, qty)
        {
            return;
        }

        /// <summary>
        /// Gets or sets the <see cref="Base.TBin"/> that you are updating inventory within, this will define <see cref="WarehouseLocationID"/> and <see cref="WHName"/>.
        /// </summary>
        [JsonIgnore]
        public Base.TBin Bin { get; set; }

        /// <summary>
        /// Gets or sets the warehouse location ID that will be updated within the <see cref="Bin"/> field.
        /// </summary>
        [JsonProperty("WarehouseLocationID", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int? WarehouseLocationID
        {
            get => this.Bin?.WarehouseLocationID;
            set
            {
                if (this.Bin == null)
                    this.Bin = new Base.TBin();
                this.Bin.WarehouseLocationID = value;
            }
        }

        /// <summary>
        /// Gets or sets the warehouse name that will be updated within the <see cref="Bin"/> field.
        /// </summary>
        [JsonProperty("WHName", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string WHName
        {
            get => this.Bin?.WHName;
            set
            {
                if (this.Bin == null)
                    this.Bin = new Base.TBin();
                this.Bin.WHName = value;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="Base.TPart"/> that you are updating inventory within the specified bin, this will define <see cref="PartID"/> and <see cref="PartName"/>.
        /// </summary>
        [JsonIgnore]
        public Base.TPart Part { get; set; }

        /// <summary>
        /// Gets or sets the part ID that will be updated within the <see cref="Part"/> field.
        /// </summary>
        [JsonProperty("PartID", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int? PartID
        {
            get => this.Part?.PartID;
            set
            {
                if (this.Part == null)
                    this.Part = new Base.TPart();
                this.Part.PartID = value;
            }
        }

        /// <summary>
        /// Gets or sets the part name that will be updated within the <see cref="Part"/> field.
        /// </summary>
        [JsonProperty("PartName", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string PartName
        {
            get => this.Part?.PartName;
            set
            {
                if (this.Part == null)
                    this.Part = new Base.TPart();
                this.Part.PartName = value;
            }
        }

        /// <summary>
        /// Gets or sets the type of inventory adjustment you are sending.
        /// </summary>
        [JsonProperty("AdjustmentType"), JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public InventoryAdjustmentType AdjustmentType { get; set; }

        /// <summary>
        /// Gets or sets the QTY that you are sending in this inventory update.
        /// </summary>
        [JsonProperty("QTY")]
        public double QTY { get; set; }

        /// <summary>
        /// Gets or sets the lot number of the part you are sending.
        /// </summary>
        [JsonProperty("LotNumber", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string LotNumber { get; set; }

        /// <summary>
        /// Gets or sets the serial number of the part you are sending.
        /// </summary>
        [JsonProperty("SerialNumber", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string SerialNumber { get; set; }

        /// <summary>
        /// Gets or sets the first custom field of the part you are sending, this is only for serialized parts and lots.
        /// </summary>
        [JsonProperty("Custom1", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Custom1 { get; set; }

        /// <summary>
        /// Gets or sets the second custom field of the part you are sending, this is only for serialized parts and lots.
        /// </summary>
        [JsonProperty("Custom2", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Custom2 { get; set; }

        /// <summary>
        /// Gets or sets the third custom field of the part you are sending, this is only for serialized parts and lots.
        /// </summary>
        [JsonProperty("Custom3", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Custom3 { get; set; }

        /// <summary>
        /// Gets or sets the fourth custom field of the part you are sending, this is only for serialized parts and lots.
        /// </summary>
        [JsonProperty("Custom4", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Custom4 { get; set; }

        [JsonIgnore]
        internal override int? ItemID { get => this.WarehouseLocationID ?? this.PartID; set => throw new NotImplementedException(); }

        [JsonIgnore]
        internal override string ItemName { get => string.IsNullOrWhiteSpace(this.WHName) ? this.PartName : string.Empty; set => throw new NotImplementedException(); }
    }
}
