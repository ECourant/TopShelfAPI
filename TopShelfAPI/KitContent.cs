using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TopShelfAPI
{
    /// <summary>
    /// Represents an item that will be created when a parent kit is broken in TopShelf.
    /// </summary>
    public class KitContent : Base.TEnumerableItem
    {
        /// <summary>
        /// Gets or sets the part ID of the part that will be created.
        /// </summary>
        [JsonProperty("ChildPartID", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int? ChildPartID { get; set; }

        /// <summary>
        /// Gets or sets the part name/SKU of the part that will be created.
        /// </summary>
        [JsonProperty("ChildPartName", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string ChildPartName { get; set; }

        /// <summary>
        /// Gets or sets whether or not the QTY of the part created is dynamic.
        /// </summary>
        [JsonProperty("IsDynamic")]
        public bool IsDynamic { get; set; }

        /// <summary>
        /// Gets or sets the usual QTY of the part created.
        /// </summary>
        [JsonProperty("UsualQTY")]
        public double UsualQTY { get; set; }

        /// <summary>
        /// Gets or sets the minimum QTY to create when breaking the parent.
        /// </summary>
        [JsonProperty("MinDynamicQty")]
        public double MinDynamicQTY { get; set; }

        /// <summary>
        /// Gets or sets the maximum QTY to create when breaking the parent.
        /// </summary>
        [JsonProperty("MaxDynamicQty")]
        public double MaxDynamicQTY { get; set; }

        [JsonIgnore]
        internal override int? ItemID { get => this.ChildPartID; set => this.ChildPartID = value; }

        [JsonIgnore]
        internal override string ItemName { get => this.ChildPartName; set => this.ChildPartName = value; }
    }
}
