using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TopShelfAPI
{
    /// <summary>
    /// Represents a carton line object in TopShelf.
    /// </summary>
    public class CartonLine : Base.TEnumerableItem
    {
        /// <summary>
        /// Gets or sets the line ID.
        /// </summary>
        [JsonProperty("CartonLineID", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int? CartonLineID { get; set; }

        /// <summary>
        /// Gets or sets the part ID of this line.
        /// </summary>
        [JsonProperty("PartID", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int? PartID { get; set; }

        /// <summary>
        /// Gets or sets the part name of this line.
        /// </summary>
        [JsonProperty("PartName", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string PartName { get; set; }

        /// <summary>
        /// Gets or sets the QTY of this line.
        /// </summary>
        [JsonProperty("QTY"), JsonRequired]
        public int QTY { get; set; }

        /// <summary>
        /// Gets or sets the serial number of the part in this line.
        /// </summary>
        [JsonProperty("SerialNumber", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string SerialNumber { get; set; }

        /// <summary>
        /// Gets or sets the lot ID of the part in this line.
        /// </summary>
        [JsonProperty("LotID", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int? LotID { get; set; }

        /// <summary>
        /// Gets or sets the lot number of the part in this line.
        /// </summary>
        [JsonProperty("LotNumber", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string LotNumber { get; set; }

        /// <summary>
        /// Gets the date that this carton line was created.
        /// </summary>
        [JsonIgnore]
        public DateTime? DateCreated { get; private set; }

        [JsonIgnore]
        internal override int? ItemID { get => this.CartonLineID; set => this.CartonLineID = value; }

        [JsonIgnore]
        internal override string ItemName { get => null; set => throw new NotImplementedException("Error, CartonLines do not have a unique name."); }

        [JsonProperty("CreateDate")]
        private string _DateCreated
        {
            set => this.DateCreated = value == TSDefaults.NullDateTime ? null : (DateTime?)DateTime.Parse(value);
        }
    }
}
