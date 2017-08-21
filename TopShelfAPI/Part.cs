using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TopShelfAPI
{
    /// <summary>
    /// Represents a part object in TopShelf.
    /// </summary>
    public class Part : Base.TPart
    {
        /// <summary>
        /// Initializes a new instance of the part object.
        /// </summary>
        public Part()
        {
            this.PutAwayBins = new Base.TEnumerable<PutAwayBin>();
            this.KitContents = new Base.TEnumerable<KitContent>();
            this.UnitsOfMeasure = new Base.TEnumerable<UnitOfMeasure>();
        }

        /// <summary>
        /// Gets or sets the default description for the part.
        /// </summary>
        [JsonProperty("PartDescription", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string PartDescription { get; set; }

        /// <summary>
        /// Gets or sets the part's vendor ID.
        /// </summary>
        [JsonProperty("VendorID", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int? VendorID { get; set; }

        /// <summary>
        /// Gets or sets the name of the part's vendor.
        /// </summary>
        [JsonProperty("VendorName", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string VendorName { get; set; }

        /// <summary>
        /// Gets or sets the client description for the part.
        /// </summary>
        [JsonProperty("ClientDescription", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string ClientDescription { get; set; }

        /// <summary>
        /// Gets or sets custom field 1.
        /// </summary>
        [JsonProperty("Custom1", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Custom1 { get; set; }

        /// <summary>
        /// Gets or sets the products UPC or barcode.
        /// </summary>
        [JsonProperty("Custom2", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Custom2 { get; set; }

        /// <summary>
        /// Gets or sets custom field 3.
        /// </summary>
        [JsonProperty("Custom3", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Custom3 { get; set; }

        /// <summary>
        /// Gets or sets custom field 4.
        /// </summary>
        [JsonProperty("Custom4", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Custom4 { get; set; }

        /// <summary>
        /// Gets or sets custom field 5.
        /// </summary>
        [JsonProperty("Custom5", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Custom5 { get; set; }

        /// <summary>
        /// Gets or sets custom field 6.
        /// </summary>
        [JsonProperty("Custom6", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Custom6 { get; set; }

        /// <summary>
        /// Gets or sets custom field 7.
        /// </summary>
        [JsonProperty("Custom7", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Custom7 { get; set; }

        /// <summary>
        /// Gets or sets custom field 8.
        /// </summary>
        [JsonProperty("Custom8", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Custom8 { get; set; }

        /// <summary>
        /// Gets or sets custom field 9.
        /// </summary>
        [JsonProperty("Custom9", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Custom9 { get; set; }

        /// <summary>
        /// Gets or sets whether or not LotCustom1 is enabled.
        /// </summary>
        [JsonProperty("LotCustom1IsEnabled")]
        public bool LotCustom1IsEnabled { get; set; }

        /// <summary>
        /// Gets or sets whether or not LotCustom1 is required.
        /// </summary>
        [JsonProperty("LotCustom1IsRequired")]
        public bool LotCustom1IsRequired { get; set; }

        /// <summary>
        /// Gets or sets the regex string used to format LotCustom1.
        /// </summary>
        [JsonProperty("LotCustom1IsFormat", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string LotCustom1IsFormat { get; set; }

        /// <summary>
        /// Gets or sets the description of LotCustom1.
        /// </summary>
        [JsonProperty("LotCustom1IsDescription", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string LotCustom1IsDescription { get; set; }

        /// <summary>
        /// Gets or sets whether or not LotCustom2 is enabled.
        /// </summary>
        [JsonProperty("LotCustom2IsEnabled")]
        public bool LotCustom2IsEnabled { get; set; }

        /// <summary>
        /// Gets or sets whether or not LotCustom2 is required.
        /// </summary>
        [JsonProperty("LotCustom2IsRequired")]
        public bool LotCustom2IsRequired { get; set; }

        /// <summary>
        /// Gets or sets the regex string used to format LotCustom2.
        /// </summary>
        [JsonProperty("LotCustom2IsFormat", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string LotCustom2IsFormat { get; set; }

        /// <summary>
        /// Gets or sets the description of LotCustom2.
        /// </summary>
        [JsonProperty("LotCustom2IsDescription", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string LotCustom2IsDescription { get; set; }

        /// <summary>
        /// Gets or sets whether or not LotCustom3 is enabled.
        /// </summary>
        [JsonProperty("LotCustom3IsEnabled")]
        public bool LotCustom3IsEnabled { get; set; }

        /// <summary>
        /// Gets or sets whether or not LotCustom3 is required.
        /// </summary>
        [JsonProperty("LotCustom3IsRequired")]
        public bool LotCustom3IsRequired { get; set; }

        /// <summary>
        /// Gets or sets the regex string used to format LotCustom3.
        /// </summary>
        [JsonProperty("LotCustom3IsFormat", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string LotCustom3IsFormat { get; set; }

        /// <summary>
        /// Gets or sets the description of LotCustom3.
        /// </summary>
        [JsonProperty("LotCustom3IsDescription", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string LotCustom3IsDescription { get; set; }

        /// <summary>
        /// Gets or sets whether or not LotCustom4 is enabled.
        /// </summary>
        [JsonProperty("LotCustom4IsEnabled")]
        public bool LotCustom4IsEnabled { get; set; }

        /// <summary>
        /// Gets or sets whether or not LotCustom4 is required.
        /// </summary>
        [JsonProperty("LotCustom4IsRequired")]
        public bool LotCustom4IsRequired { get; set; }

        /// <summary>
        /// Gets or sets the regex string used to format LotCustom4.
        /// </summary>
        [JsonProperty("LotCustom4IsFormat", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string LotCustom4IsFormat { get; set; }

        /// <summary>
        /// Gets or sets the description of LotCustom4.
        /// </summary>
        [JsonProperty("LotCustom4IsDescription", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string LotCustom4IsDescription { get; set; }

        /// <summary>
        /// Gets or sets whether or not the part is perishable.
        /// </summary>
        [JsonProperty("isPerishable")]
        public bool IsPerishable { get; set; }

        /// <summary>
        /// Gets or sets whether or not the part is last in first out.
        /// </summary>
        [JsonProperty("IsLIFO")]
        public bool IsLIFO { get; set; }

        /// <summary>
        /// Gets or sets whether or not the part is first in first out.
        /// </summary>
        [JsonProperty("IsFIFO")]
        public bool IsFIFO { get; set; }

        /// <summary>
        /// Gets or sets the url of the product's image.
        /// </summary>
        [JsonProperty("ImageURL", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string ImageURL { get; set; }

        /// <summary>
        /// Gets or sets the cost to purchase the part from the vendor.
        /// </summary>
        [JsonProperty("Cost", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public double Cost { get; set; }

        /// <summary>
        /// Gets or sets the rate of the part.
        /// </summary>
        [JsonProperty("Rate", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public double Rate { get; set; }

        /// <summary>
        /// Gets or sets the shipping weight.
        /// </summary>
        [JsonProperty("ShippingWeight", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public double ShippingWeight { get; set; }

        /// <summary>
        /// Gets the date the part was created.
        /// </summary>
        [JsonIgnore]
        public DateTime? DateCreated { get; private set; }

        /// <summary>
        /// Gets the date the part was last updated.
        /// </summary>
        [JsonIgnore]
        public DateTime? DateUpdated { get; private set; }

        /// <summary>
        /// Gets the list of put away bins for the part.
        /// </summary>
        [JsonIgnore]
        public Base.TEnumerable<PutAwayBin> PutAwayBins { get; set; }

        /// <summary>
        /// Gets a list of parts that are in this part as a kit.
        /// </summary>
        [JsonIgnore]
        public Base.TEnumerable<KitContent> KitContents { get; set; }

        /// <summary>
        /// Gets a list of units of measure.
        /// </summary>
        [JsonIgnore]
        public Base.TEnumerable<UnitOfMeasure> UnitsOfMeasure { get; set; }

        [JsonProperty("dtCreated")]
        private string DateCreatedSetter
        {
            set => this.DateCreated = value == TSDefaults.NullDateTime ? null : (DateTime?)DateTime.Parse(value);
        }

        [JsonProperty("dtUpdated")]
        private string DateUpdatedSetter
        {
            set => this.DateUpdated = value == TSDefaults.NullDateTime ? null : (DateTime?)DateTime.Parse(value);
        }

        [JsonProperty("PutAwayBins", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        private PutAwayBin[] PutAwayBinsHandler
        {
            get => (this.PutAwayBins ?? new Base.TEnumerable<PutAwayBin>()).ToArray();
            set => this.PutAwayBins = value;
        }

        [JsonProperty("KitContents", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        private KitContent[] KitContentsHandler
        {
            get => (this.KitContents ?? new Base.TEnumerable<KitContent>()).ToArray();
            set => this.KitContents = value;
        }

        [JsonProperty("UnitsOfMeasure", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        private UnitOfMeasure[] UnitsOfMeasureHandler
        {
            get => (this.UnitsOfMeasure ?? new Base.TEnumerable<UnitOfMeasure>()).ToArray();
            set => this.UnitsOfMeasure = value;
        }
    }
}
