using Newtonsoft.Json;

namespace TopShelfAPI.Base
{
    /// <summary>
    /// The base class for TopShelf's Part object, all part objects are based off of this class.
    /// </summary>
    public class TPart : TEnumerableItem, Basics.ITopShelfObject
    {
        /// <summary>
        /// Gets or sets the ID of the part.
        /// </summary>
        [JsonProperty("PartID", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public virtual int? PartID { get; set; }

        /// <summary>
        /// Gets or sets the name/SKU of the part.
        /// </summary>
        [JsonProperty("PartName", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore), JsonRequired]
        public virtual string PartName { get; set; }

        /// <summary>
        /// Gets or sets whether or not the part will require a unique serial number when added to inventory.
        /// </summary>
        [JsonProperty("RequiresSerialNumber")]
        public bool RequiresSerialNumber { get; set; }

        /// <summary>
        /// Gets or sets whether or not the part will by part of a Lot when added to inventory.
        /// </summary>
        [JsonProperty("RequiresLot")]
        public bool RequiresLot { get; set; }

        [JsonIgnore]
        internal override int? ItemID
        {
            get => this.PartID;
            set => this.PartID = value;
        }

        [JsonIgnore]
        internal override string ItemName
        {
            get => this.PartName;
            set => this.PartName = value;
        }
    }
}
