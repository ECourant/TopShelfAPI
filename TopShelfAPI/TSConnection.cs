using System;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;

namespace TopShelfAPI
{
    /// <summary>
    /// Used for connecting to TopShelf's REST API using the credentials provided to you on your My Account page.
    /// </summary>
    public sealed class TSConnection : IDisposable
    {
        private static UnauthorizedAccessException Unauthorized = new UnauthorizedAccessException("TSConnection has not been properly initialized, you are not authorized!");

        private bool disposed = false;

        private SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        /// <summary>
        /// Initializes a new instance of <see cref="TSConnection"/> with the provided <see cref="TSCredential"/>s.
        /// </summary>
        /// <param name="credentials">The REST API credentials for your TopShelf account.</param>
        public TSConnection(TSCredential credentials) : this(credentials, new TSConfiguration())
        {
            return;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="TSConnection"/> with the provided <see cref="TSCredential"/>s and <see cref="TSConfiguration"/>.
        /// </summary>
        /// <param name="credentials">The REST API credentials for your TopShelf account.</param>
        /// <param name="configuration">The settings that will be used for the connection to TopShelf's REST API.</param>
        public TSConnection(TSCredential credentials, TSConfiguration configuration)
        {
            if (credentials is null)
                throw new ArgumentNullException("credentials", "Credentials cannot be null");
            if (configuration is null)
                throw new ArgumentNullException("configuration", "Configuration cannot be null");
            this.Credentials = credentials;
            this.Configuration = configuration;
            this.RequestHandler = new Network.RequestHandler(this.Configuration, this.Credentials);

            this._ClientsLocations = new Pipelines.ClientsLocationsPipeline(this.RequestSentDelegate);
            this._Documents = new Pipelines.DocumentsPipeline(this.RequestSentDelegate);
            this._Bins = new Pipelines.BinsPipeline(this.RequestSentDelegate);
            this._Cartons = new Pipelines.CartonsPipeline(this.RequestSentDelegate);
            this._Vendors = new Pipelines.VendorsPipeline(this.RequestSentDelegate);
            this._Parts = new Pipelines.PartsPipeline(this.RequestSentDelegate);
            this._Inventory = new Pipelines.InventoryPipeline(this.RequestSentDelegate);
#if DEBUG
            this._Test = new Pipelines.TestPipeline(this.RequestSentDelegate);
#endif
        }

        /// <summary>
        /// Gets the pipeline for <see cref="Client"/> and <see cref="Location"/> functions.
        /// </summary>
        public Pipelines.ClientsLocationsPipeline ClientsLocations => this._ClientsLocations ?? throw new UnauthorizedAccessException();

        /// <summary>
        /// Gets the pipeline for <see cref="Document"/> functions.
        /// </summary>
        public Pipelines.DocumentsPipeline Documents => this._Documents ?? throw Unauthorized;

        /// <summary>
        /// Gets the pipeline for <see cref="Bin"/> functions.
        /// </summary>
        /// <example>
        /// <para>Getting a list of bins.</para>
        /// <code>
        /// TopShelfAPI.TSConnection TS = new TopShelfAPI.TSConnection(
        ///     new TopShelfAPI.TSCredential(APIKey, APIPassword),
        ///     new TopShelfAPI.TSConfiguration()
        ///     {
        ///         RequestTimeout = TimeSpan.FromMinutes(10),
        ///     });
        /// TopShelfAPI.LocationBins[] Bins = TS.Bins.GetBins();
        /// </code>
        /// <para></para>
        /// <para>Getting a single bin.</para>
        /// <code>
        /// TopShelfAPI.TSConnection TS = new TopShelfAPI.TSConnection(
        ///     new TopShelfAPI.TSCredential(APIKey, APIPassword),
        ///     new TopShelfAPI.TSConfiguration()
        ///     {
        ///         RequestTimeout = TimeSpan.FromMinutes(10),
        ///     });
        /// TopShelfAPI.Bin SingleBin = TS.Bins.GetBin("TestBin");
        /// //Or
        /// TopShelfAPI.Bin SingleBin2 = TS.Bins["TestBin"];
        /// 
        /// //Using WarehouseLocationID
        /// TopShelfAPI.Bin SingleBin3 = TS.Bins.GetBin(124);
        /// //Or
        /// TopShelfAPI.Bin SingleBin4 = TS.Bins[124];
        /// </code>
        /// </example> 
        public Pipelines.BinsPipeline Bins => this._Bins ?? throw Unauthorized;

        /// <summary>
        /// Gets the pipeline for <see cref="Carton"/> functions.
        /// </summary>
        public Pipelines.CartonsPipeline Cartons => this._Cartons ?? throw Unauthorized;

        /// <summary>
        /// Gets the pipeline for <see cref="Vendor"/> functions.
        /// </summary>
        public Pipelines.VendorsPipeline Vendors => this._Vendors ?? throw Unauthorized;

        /// <summary>
        /// Gets the pipeline for <see cref="Part"/> functions.
        /// </summary>
        public Pipelines.PartsPipeline Parts => this._Parts ?? throw Unauthorized;

        /// <summary>
        /// Gets the pipeline for <see cref="PartInventory"/> functions.
        /// </summary>
        public Pipelines.InventoryPipeline Inventory => this._Inventory ?? throw Unauthorized;

#if DEBUG
        public Pipelines.TestPipeline Test => this._Test ?? throw Unauthorized;
#endif

        private TSCredential Credentials { get; set; } = null;

        private TSConfiguration Configuration { get; set; } = null;

        private Network.RequestHandler RequestHandler { get; set; } = null;

        private Pipelines.ClientsLocationsPipeline _ClientsLocations { get; set; }

        private Pipelines.DocumentsPipeline _Documents { get; set; }

        private Pipelines.BinsPipeline _Bins { get; set; }

        private Pipelines.CartonsPipeline _Cartons { get; set; }

        private Pipelines.VendorsPipeline _Vendors { get; set; }

        private Pipelines.PartsPipeline _Parts { get; set; }

        private Pipelines.InventoryPipeline _Inventory { get; set; }

#if DEBUG
        private Pipelines.TestPipeline _Test { get; set; }
#endif

        /// <summary>
        /// Disposes the current <see cref="TSConnection"/>.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        private Basics.IResponse RequestSentDelegate(Basics.IRequest request) => this.RequestHandler.SendRequest(request);

        private void Dispose(bool disposing)
        {
            if (this.disposed)
                return;

            if (disposing)
            {
                this.handle.Dispose();

                // Free any other managed objects here.
            }

            // Free any unmanaged objects here.
            this.disposed = true;
        }
    }
}
