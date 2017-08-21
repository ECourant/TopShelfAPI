using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TopShelfAPI
{
    /// <summary>
    /// Represents a location object in TopShelf.
    /// </summary>
    public class Location : Base.TLocation
    {
        /// <summary>
        /// Gets or sets the first address field.
        /// </summary>
        [JsonProperty("Address1", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Address1 { get; set; }

        /// <summary>
        /// Gets or sets the second address field.
        /// </summary>
        [JsonProperty("Address2", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Address2 { get; set; }

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        [JsonProperty("City", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the state or province.
        /// </summary>
        [JsonProperty("State", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string State { get; set; }

        /// <summary>
        /// Gets or sets the zip code.
        /// </summary>
        [JsonProperty("Zip", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Zip { get; set; }

        /// <summary>
        /// Gets or sets the country code.
        /// </summary>
        [JsonProperty("CountryCode", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string CountryCode { get; set; } // ISO

        /// <summary>
        /// Gets or sets the name of the location's contact.
        /// </summary>
        [JsonProperty("ContactName", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string ContactName { get; set; }

        /// <summary>
        /// Gets or sets the phone number of the location's contact.
        /// </summary>
        [JsonProperty("ContactPhone", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string ContactPhone { get; set; }

        /// <summary>
        /// Gets or sets the reference number.
        /// </summary>
        [JsonProperty("ReferenceNum", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string ReferenceNum { get; set; }

        /// <summary>
        /// Gets or sets the url of the location's logo.
        /// </summary>
        [JsonProperty("LogoUrl", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string LogoURL { get; set; }
    }
}
