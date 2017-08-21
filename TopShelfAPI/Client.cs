using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TopShelfAPI
{
    /// <summary>
    /// Represents a client object in TopShelf.
    /// </summary>
    public class Client : Base.TClient
    {
        /// <summary>
        /// Initializes a new instance of the client object.
        /// </summary>
        public Client()
        {
            this.Locations = new Base.TEnumerable<Location>();
        }

        /// <summary>
        /// Gets or sets client's account number.
        /// </summary>
        [JsonProperty("AccountNumber", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public string AccountNumber { get; set; }

        /// <summary>
        /// Gets or sets the Email address for the client.
        /// </summary>
        [JsonProperty("Email", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the URL to an image for the client's logo.
        /// </summary>
        [JsonProperty("LogoUrl", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public string LogoURL { get; set; }

        /// <summary>
        /// Gets or sets the locations that are apart of this client.
        /// </summary>
        [JsonIgnore]
        public Base.TEnumerable<Location> Locations { get; set; }

        [JsonProperty("Locations", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        private Location[] _Locations => (this.Locations ?? new Base.TEnumerable<Location>() { }).ToArray();
    }
}
