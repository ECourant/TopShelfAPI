using System;
using Newtonsoft.Json;

namespace TopShelfAPI.Base
{
    /// <summary>
    /// The base class for TopShelf's Client object, all client objects are based off of this class.
    /// </summary>
    public abstract class TClient : TEnumerableItem, Basics.ITopShelfObject
    {
        /// <summary>
        /// Gets or sets the client's ID.
        /// </summary>
        [JsonProperty("ClientID", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public virtual int? ClientID { get; set; }

        /// <summary>
        /// Gets or sets the client's name.
        /// </summary>
        [JsonProperty("ClientName", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore), JsonRequired]
        public virtual string ClientName { get; set; }

        /// <summary>
        /// Gets the <see cref="DateTime"/> that the client was created.
        /// </summary>
        [JsonIgnore]
        public DateTime? DateCreated { get; private set; }

        /// <summary>
        /// Gets the <see cref="DateTime"/> that the client was last updated.
        /// </summary>
        [JsonIgnore]
        public DateTime? DateUpdated { get; private set; }

        /// <summary>
        /// Gets the client QTY.
        /// </summary>
        [JsonIgnore]
        public double ClientQTY { get; private set; }

        [JsonIgnore]
        internal override int? ItemID
        {
            get => this.ClientID;
            set => this.ClientID = value;
        }

        [JsonIgnore]
        internal override string ItemName
        {
            get => this.ClientName;
            set => this.ClientName = value;
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

        [JsonProperty("ClientQty")]
        private double ClientQTYSetter
        {
            set => this.ClientQTY = value;
        }
    }
}
