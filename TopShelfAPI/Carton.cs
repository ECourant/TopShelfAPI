using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TopShelfAPI
{
    /// <summary>
    /// Represents a carton object in TopShelf.
    /// </summary>
    public class Carton : Base.TEnumerableItem, Basics.ITopShelfObject
    {
        /// <summary>
        /// Initializes a new instance of the carton object.
        /// </summary>
        public Carton() => this.CartonLines = new Base.TEnumerable<CartonLine>();

        /// <summary>
        /// Gets or sets the carton ID.
        /// </summary>
        [JsonProperty("CartonID", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int? CartonID { get; set; }

        /// <summary>
        /// Gets or sets the document ID that this carton is associated with.
        /// </summary>
        [JsonProperty("DocumentID", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int? DocumentID { get; set; }

        /// <summary>
        /// Gets or sets the document number that this carton is associated with.
        /// </summary>
        [JsonProperty("DocNumber", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string DocumentNumber { get; set; }

        /// <summary>
        /// Gets or sets the tracking number for this carton.
        /// </summary>
        [JsonProperty("TrackingNumber"), JsonRequired]
        public string TrackingNumber { get; set; }

        /// <summary>
        /// Gets or sets the notes for this carton.
        /// </summary>
        [JsonProperty("Notes", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Notes { get; set; }

        /// <summary>
        /// Gets the date that this carton was last updated.
        /// </summary>
        [JsonIgnore]
        public DateTime? DateCreated { get; private set; }

        /// <summary>
        /// Gets the <see cref="CartonLine"/>s inside this carton.
        /// </summary>
        [JsonIgnore]
        public Base.TEnumerable<CartonLine> CartonLines { get; set; }

        [JsonIgnore]
        internal override int? ItemID { get => this.CartonID; set => this.CartonID = value; }

        [JsonIgnore]
        internal override string ItemName { get => null; set => throw new NotImplementedException("Error, Cartons do not have unique name"); }

        [JsonProperty("CreateDate")]
        private string _DateCreated
        {
            set => this.DateCreated = value == TSDefaults.NullDateTime ? null : (DateTime?)DateTime.Parse(value);
        }

        [JsonProperty("CartonLines", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        private CartonLine[] _CartonLines
        {
            get => (this.CartonLines ?? new Base.TEnumerable<CartonLine>()).ToArray();
            set => this.CartonLines = value;
        }
    }
}
