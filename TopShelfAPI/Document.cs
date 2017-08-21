using System;
using System.Linq;
using Newtonsoft.Json;

namespace TopShelfAPI
{
    /// <summary>
    /// Represents a receiving or shipping document.
    /// </summary>
    public class Document : Base.TEnumerableItem, Basics.ITopShelfObject
    {
        /// <summary>
        /// Initializes a new instance of the Document object with the default <see cref="Document.DocumentType"/> set to <see cref="DocumentType.PurchaseOrder"/>.
        /// </summary>
        public Document() : this(TopShelfAPI.DocumentType.PurchaseOrder)
        {
        }

        /// <summary>
        /// Initializes a new instance of the Document object with the specified <see cref="DocumentType"/>.
        /// </summary>
        /// <param name="documentType">The <see cref="TopShelfAPI.DocumentType"/> that this document will be.</param>
        public Document(DocumentType documentType)
        {
            this.DocumentDetails = new Base.TEnumerable<DocumentDetail>();
            this.DocumentType = documentType;
            this.ToLocation = new Location();
            this.ToClient = new Client();
            this.FromLocation = new Location();
            this.FromClient = new Client();
            this.Vendor = new Vendor();
        }

        /// <summary>
        /// Gets or sets the document's unique numeric identifier.
        /// </summary>
        [JsonProperty("DocumentID", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int? DocumentID { get; set; }
        
        /// <summary>
        /// Gets or sets the document number.
        /// </summary>
        [JsonProperty("DocNumber", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string DocumentNumber { get; set; }

        /// <summary>
        /// Gets or sets the ToLocation, this will define <see cref="ToLocationID"/> and <see cref="ToLocationName"/>.
        /// </summary>
        [JsonIgnore]
        public Location ToLocation { get; set; }
        
        /// <summary>
        /// Gets or sets the ToLocationID which is defined in <see cref="ToLocation"/>.
        /// </summary>
        [JsonProperty("ToLocationID", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int? ToLocationID
        {
            get => this.ToLocation?.LocationID;
            set
            {
                if (this.ToLocation == null)
                    this.ToLocation = new Location();
                this.ToLocation.LocationID = value;
            }
        }

        /// <summary>
        /// Gets or sets the ToLocationName which is defined in <see cref="ToLocation"/>.
        /// </summary>
        [JsonProperty("ToLocationName", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string ToLocationName
        {
            get => this.ToLocation?.LocationName;
            set
            {
                if (this.ToLocation == null)
                    this.ToLocation = new Location();
                this.ToLocation.LocationName = value;
            }
        }

        /// <summary>
        /// Gets or sets the ToClient, this will define <see cref="ToClientID"/> and <see cref="ToClientName"/>.
        /// </summary>
        [JsonIgnore]
        public Client ToClient { get; set; }

        /// <summary>
        /// Gets or sets the ToClientID which is defined in <see cref="ToClient"/>.
        /// </summary>
        [JsonProperty("ToClientID", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int? ToClientID
        {
            get => this.ToClient?.ClientID;
            set
            {
                if (this.ToClient == null)
                    this.ToClient = new Client();
                this.ToClient.ClientID = value;
            }
        }

        /// <summary>
        /// Gets or sets the ToClientName which is defined in <see cref="ToClient"/>.
        /// </summary>
        [JsonProperty("ToClientName", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string ToClientName
        {
            get => this.ToClient?.ClientName;
            set
            {
                if (this.ToClient == null)
                    this.ToClient = new Client();
                this.ToClient.ClientName = value;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="TopShelfAPI.DocumentType"/> based on it's numeric representation.
        /// </summary>
        [JsonProperty("DocTypeID")]
        public int? DocumentTypeID
        {
            get => (int?)this.DocumentType;
            set => this.DocumentType = (DocumentType)value;
        }

        /// <summary>
        /// Gets or sets the document type.
        /// </summary>
        [JsonIgnore]
        public DocumentType? DocumentType { get; set; }

        /// <summary>
        /// Gets or sets the transaction prefix.
        /// </summary>
        [JsonIgnore]
        public TransactionPrefix TransactionPrefix
        {
            get => (this.DocumentType ?? TopShelfAPI.DocumentType.PurchaseOrder) == TopShelfAPI.DocumentType.PurchaseOrder ? TransactionPrefix.PurchaseOrder : TransactionPrefix.SalesOrder;
            set => this.DocumentType = value == TransactionPrefix.PurchaseOrder ? TopShelfAPI.DocumentType.PurchaseOrder : TopShelfAPI.DocumentType.SalesOrder; 
        }

        /// <summary>
        /// Gets or sets the customer's purchase order number.
        /// </summary>
        [JsonProperty("CustomerPO", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string CustomerPO { get; set; }

        /// <summary>
        /// Gets or sets the FromLocation, this will define <see cref="FromLocationID"/> and <see cref="FromLocationName"/>.
        /// </summary>
        [JsonIgnore]
        public Location FromLocation { get; set; }

        /// <summary>
        /// Gets or sets the FromLocationID which is defined in <see cref="FromLocation"/>.
        /// </summary>
        [JsonProperty("FromLocationID", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int? FromLocationID
        {
            get => this.FromLocation?.LocationID;
            set
            {
                if (this.FromLocation == null)
                    this.FromLocation = new Location();
                this.FromLocation.LocationID = value;
            }
        }

        /// <summary>
        /// Gets or sets the FromLocationName which is defined in <see cref="FromLocation"/>.
        /// </summary>
        [JsonProperty("FromLocationName", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string FromLocationName
        {
            get => this.FromLocation?.LocationName;
            set
            {
                if (this.FromLocation == null)
                    this.FromLocation = new Location();
                this.FromLocation.LocationName = value;
            }
        }

        /// <summary>
        /// Gets or sets the FromClient, this will define <see cref="FromClientID"/>, <see cref="FromAccountNumber"/> and <see cref="FromClientName"/>.
        /// </summary>
        [JsonIgnore]
        public Client FromClient { get; set; }

        /// <summary>
        /// Gets or sets the FromClientID which is defined in <see cref="FromClient"/>.
        /// </summary>
        [JsonProperty("FromClientID", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int? FromClientID
        {
            get => this.FromClient?.ClientID;
            set
            {
                if (this.FromClient == null)
                    this.FromClient = new Client();
                this.FromClient.ClientID = value;
            }
        }

        /// <summary>
        /// Gets or sets the FromClientName which is defined in <see cref="FromClient"/>.
        /// </summary>
        [JsonProperty("FromClientName", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string FromClientName
        {
            get => this.FromClient?.ClientName;
            set
            {
                if (this.FromClient == null)
                    this.FromClient = new Client();
                this.FromClient.ClientName = value;
            }
        }

        /// <summary>
        /// Gets or sets the FromAccountNumber which is defined in <see cref="FromClient"/>.
        /// </summary>
        [JsonProperty("FromAccountNumber", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string FromAccountNumber
        {
            get => this.FromClient?.AccountNumber;
            set
            {
                if (this.FromClient == null)
                    this.FromClient = new Client();
                this.FromClient.AccountNumber = value;
            }
        }

        /// <summary>
        /// Gets or sets the Vendor, this will define <see cref="VendorID"/> and <see cref="VendorName"/>.
        /// </summary>
        [JsonIgnore]
        public Vendor Vendor { get; set; }

        /// <summary>
        /// Gets or sets the VendorID which is defined in <see cref="Vendor"/>.
        /// </summary>
        [JsonProperty("VendorID", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int? VendorID
        {
            get => this.Vendor?.VendorID;
            set
            {
                if (this.Vendor == null)
                    this.Vendor = new Vendor();
                this.Vendor.VendorID = value;
            }
        }

        /// <summary>
        /// Gets or sets the VendorName which is defined in <see cref="Vendor"/>.
        /// </summary>
        [JsonProperty("VendorName", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string VendorName
        {
            get => this.Vendor?.VendorName;
            set
            {
                if (this.Vendor == null)
                    this.Vendor = new Vendor();
                this.Vendor.VendorName = value;
            }
        }

        /// <summary>
        /// Gets or sets whether or not the document is currently being held. If true the document cannot be opened on devices.
        /// </summary>
        [JsonProperty("HoldForPick", NullValueHandling = NullValueHandling.Ignore)]
        public bool HoldForPick { get; set; }

        /// <summary>
        /// Gets or sets the date which the hold will expire.
        /// </summary>
        [JsonIgnore]
        public DateTime? HoldForPickDate { get; set; }

        /// <summary>
        /// Gets or sets the integration doc used for storing custom data from integrations.
        /// </summary>
        [JsonProperty("IntegrationDoc", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string IntegrationDoc { get; set; }

        /// <summary>
        /// Gets or sets the integration source used for storing custom data from integrations.
        /// </summary>
        [JsonProperty("IntegrationSource", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string IntegrationSource { get; set; }

        /// <summary>
        /// Gets the date the document was created.
        /// </summary>
        [JsonIgnore]
        public DateTime? DateCreated { get; private set; }

        /// <summary>
        /// Gets the date the document was last updated.
        /// </summary>
        [JsonIgnore]
        public DateTime? DateUpdated { get; private set; }

        /// <summary>
        /// Gets the subtotal value of the document.
        /// </summary>
        [JsonProperty("SubTotal")]
        public double SubTotal { get; private set; }

        /// <summary>
        /// Gets the total value of the document.
        /// </summary>
        [JsonProperty("Total")]
        public double Total { get; private set; }

        /// <summary>
        /// Gets the shipping paid for this document.
        /// </summary>
        [JsonProperty("ShippingPaid")]
        public double ShippingPaid { get; private set; }

        /// <summary>
        /// Gets or sets the tax for this document.
        /// </summary>
        [JsonProperty("Tax")]
        public double Tax { get; set; }

        /// <summary>
        /// Gets or sets the shipping type id.
        /// </summary>
        [JsonProperty("ShippingTypeID", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int? ShippingTypeID { get; set; }

        /// <summary>
        /// Gets or sets the shipping type name.
        /// </summary>
        [JsonProperty("ShippingTypeName", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string ShippingTypeName { get; set; }

        /// <summary>
        /// Gets the <see cref="TopShelfAPI.StatusName"/> of the document.
        /// </summary>
        [JsonIgnore]
        public StatusName StatusName { get; private set; }

        /// <summary>
        /// Gets or sets the documents notes.
        /// </summary>
        [JsonProperty("Notes", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Notes { get; set; }

        /// <summary>
        /// Gets or sets the list of parts that are to be received or picked for this document.
        /// </summary>
        [JsonIgnore]
        public Base.TEnumerable<DocumentDetail> DocumentDetails { get; set; }

        [JsonIgnore]
        internal override int? ItemID { get => this.DocumentID; set => this.DocumentID = value; }

        [JsonIgnore]
        internal override string ItemName { get => this.DocumentNumber; set => this.DocumentNumber = value; }

        [JsonProperty("isReceiving")]
        private bool IsReceivingHandler
        {
            get => this.DocumentType == TopShelfAPI.DocumentType.SalesOrder;
        }

        [JsonProperty("StatusName")]
        private string StatusNameSetter
        {
            set => this.StatusName = Helpers.EnumHandler.ConvertString<StatusName>(value);
        }

        [JsonProperty("DocCreatedDate")]
        private string DateCreatedSetter
        {
            set => this.DateCreated = value == TSDefaults.NullDateTime ? null : (DateTime?)DateTime.Parse(value);
        }

        [JsonProperty("DocUpdatedDate")]
        private string DateUpdatedSetter
        {
            set => this.DateUpdated = value == TSDefaults.NullDateTime ? null : (DateTime?)DateTime.Parse(value);
        }

        [JsonProperty("holdForPickDate")]
        private string HoldForPickDateHandler
        {
            get => this.HoldForPickDate == null || this.HoldForPickDate == default(DateTime) ? TSDefaults.NullDateTime : this.HoldForPickDate.ToString();
            set => this.HoldForPickDate = value == TSDefaults.NullDateTime ? null : (DateTime?)DateTime.Parse(value);
        }

        [JsonProperty("DocumentDetail", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        private DocumentDetail[] _DocumentDetails
        {
            get => (this.DocumentDetails ?? new Base.TEnumerable<DocumentDetail>()).ToArray();
            set => this.DocumentDetails = value;
        } 

        [JsonProperty("DocumentType")]
        private string _DocumentType => Helpers.EnumHandler.ConvertEnum<DocumentType>(this.DocumentType ?? TopShelfAPI.DocumentType.PurchaseOrder);

        [JsonProperty("TransactionPrefix")]
        private string TransactionPrefixHandler
        {
            get => this.TransactionPrefix.ToString();
            set => this.TransactionPrefix = (TransactionPrefix)Enum.Parse(typeof(TransactionPrefix), value);
        }
    }
}
