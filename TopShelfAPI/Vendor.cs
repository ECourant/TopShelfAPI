using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TopShelfAPI
{
    /// <summary>
    /// Represents a vendor object in TopShelf.
    /// </summary>
    public class Vendor : Base.TEnumerableItem, Basics.ITopShelfObject
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("VendorID", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int? VendorID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("VendorName", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string VendorName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("ContactFirstName", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string ContactFirstName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("ContactLastName", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string ContactLastName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("Address", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Address { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("City", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string City { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("StateOrProvice", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string StateOrProvince { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("PostalCode", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string PostalCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("Country", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Country { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("LogoUrl", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string LogoURL { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("ContactEmail", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string ContactEmail { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("PhoneNumber", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("FanNumber", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string FanNumber { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("Title", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Title { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("Notes", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Notes { get; set; }

        [JsonIgnore]
        internal override int? ItemID { get => this.VendorID; set => this.VendorID = value; }

        [JsonIgnore]
        internal override string ItemName { get => this.VendorName; set => this.VendorName = value; }
    }
}
