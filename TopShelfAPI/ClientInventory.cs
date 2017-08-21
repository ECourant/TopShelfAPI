using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TopShelfAPI
{
    /// <summary>
    /// Represents an inventory object for clients.
    /// </summary>
    public class ClientInventory : Base.TClient
    {
        /// <summary>
        /// Initializes a new client inventory object.
        /// </summary>
        public ClientInventory() => this.Locations = new Base.TEnumerable<LocationInventory>();

        /// <summary>
        /// Gets or sets the of inventory locations that are apart of this client.
        /// </summary>
        [JsonIgnore]
        public Base.TEnumerable<LocationInventory> Locations { get; set; }

        [JsonProperty("Locations", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        private LocationInventory[] LocationsHandler
        {
            get => (this.Locations ?? new Base.TEnumerable<LocationInventory>()).ToArray();
            set => this.Locations = value;
        }
    }
}
