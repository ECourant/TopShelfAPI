using System;
using Newtonsoft.Json;


namespace TopShelfAPI.Base
{
    /// <summary>
    /// The base class for TopShelf's Location object, all location objects are based off of this class.
    /// </summary>
    public abstract class TLocation : TEnumerableItem, Basics.ITopShelfObject
    {
        /// <summary>
        /// Gets or sets the location's ID.
        /// </summary>
        [JsonProperty("LocationID", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public virtual int? LocationID { get; set; }

        /// <summary>
        /// Gets or sets the location's name.
        /// </summary>
        [JsonProperty("LocationName", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore), JsonRequired]
        public virtual string LocationName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonIgnore]
        public DateTime? DateCreated { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonIgnore]
        public DateTime? DateUpdated { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("bActive")]
        public bool Active { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("bIsDepot")]
        public bool IsDepot { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonIgnore]
        public double LocationQTY { get; private set; }

        [JsonIgnore]
        internal override int? ItemID
        {
            get => this.LocationID;
            set => this.LocationID = value;
        }

        [JsonIgnore]
        internal override string ItemName
        {
            get => this.LocationName;
            set => this.LocationName = value;
        }

        [JsonProperty("dtCreated")]
        private string _DateCreated
        {
            set => this.DateCreated = value == TSDefaults.NullDateTime ? null : (DateTime?)DateTime.Parse(value);
        }

        [JsonProperty("dtUpdated")]
        private string _DateUpdated
        {
            set => this.DateUpdated = value == TSDefaults.NullDateTime ? null : (DateTime?)DateTime.Parse(value);
        }

        [JsonProperty("LocationQty")]
        private double _LocationQTY
        {
            set => this.LocationQTY = value;
        }
    }
}
