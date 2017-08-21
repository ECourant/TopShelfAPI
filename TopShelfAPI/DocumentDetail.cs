using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TopShelfAPI
{
    /// <summary>
    /// Represents a single line on a receiving or shipping document.
    /// </summary>
    public class DocumentDetail : Base.TPart
    {
        /// <summary>
        /// Gets or sets the ID of the document detail.
        /// </summary>
        [JsonProperty("DocumentDetailID", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public int? DocumentDetailID { get; set; }

        /// <summary>
        /// Gets or sets the QTY expected to be picked or received for this document.
        /// </summary>
        [JsonProperty("QTY")]
        public double QTY { get; set; }

        /// <summary>
        /// Gets the date that this document detail was last updated.
        /// </summary>
        [JsonIgnore]
        public DateTime? DateUpdated { get; private set; }

        /// <summary>
        /// Gets or sets the integration ID of the source system.
        /// </summary>
        [JsonProperty("IntegrationID", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string IntegrationID { get; set; }

        /// <summary>
        /// Gets or sets the document detail code.
        /// </summary>
        [JsonProperty("Code", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the document detail's unit price.
        /// </summary>
        [JsonProperty("UnitPrice")]
        public double UnitPrice { get; set; }

        /// <summary>
        /// Gets the QTY received so far.
        /// </summary>
        [JsonIgnore]
        public double QTYReceived { get; private set; }

        /// <summary>
        /// Gets the QTY shipped so far.
        /// </summary>
        [JsonIgnore]
        public double QTYShipped { get; private set; }

        /// <summary>
        /// Gets the QTY that has been pre received.
        /// </summary>
        [JsonIgnore]
        public double QTYPreReceived { get; private set; }

        /// <summary>
        /// Gets the QTY that has been pre shipped.
        /// </summary>
        [JsonIgnore]
        public double QTYPreShipped { get; private set; }

        /// <summary>
        /// Gets the pre-QTY.
        /// </summary>
        [JsonIgnore]
        public double PreQTY { get; private set; }

        [JsonIgnore]
        internal override int? ItemID
        {
            get => this.DocumentDetailID;
            set => this.DocumentDetailID = value;
        }

        [JsonIgnore]
        internal override string ItemName
        {
            get => this.PartName;
            set => this.PartName = value;
        }

        [JsonProperty("DetailUpdatedDate")]
        private string DateUpdatedSetter
        {
            set => this.DateUpdated = value == TSDefaults.NullDateTime ? null : (DateTime?)DateTime.Parse(value);
        }

        [JsonProperty("QTYReceived")]
        private double QTYReceivedSetter
        {
            set => this.QTYReceived = value;
        }

        [JsonProperty("QTYShipped")]
        private double QTYShippedSetter
        {
            set => this.QTYShipped = value;
        }

        [JsonProperty("QTYPreReceived")]
        private double QTYPreReceivedSetter
        {
            set => this.QTYPreReceived = value;
        }

        [JsonProperty("QTYPreShipped")]
        private double QTYPreShippedSetter
        {
            set => this.QTYPreShipped = value;
        }

        [JsonProperty("PreQTY")]
        private double PreQTYSetter
        {
            set => this.PreQTY = value;
        }
    }
}
