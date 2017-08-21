using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopShelfAPI.Pipelines
{
    /// <summary>
    /// Represents a pipeline of functions for getting, creating, updating and deleting <see cref="Bin"/>s.
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
    public sealed class BinsPipeline : Base.TPipeline
    {
        internal BinsPipeline(Network.TSRequestDelegate requestDelegate) : base(requestDelegate)
        {
            return;
        }

        protected override string DefaultTarget => "bins";

        /// <summary>
        /// Gets the bin with the specified <see cref="Base.TBin.WarehouseLocationID"/>.
        /// </summary>
        /// <param name="warehouseLocationID">The <see cref="Base.TBin.WarehouseLocationID"/> of the bin you are retrieving.</param>
        /// <returns>A single <see cref="Bin"/> object with the <see cref="Base.TBin.WarehouseLocationID"/> you specified.</returns>
        public Bin this[int warehouseLocationID] => this.GetBin(warehouseLocationID);

        /// <summary>
        /// Gets the bin with the specified <see cref="Base.TBin.WHName"/>.
        /// </summary>
        /// <param name="whName">The <see cref="Base.TBin.WHName"/> of the bin you are retrieving.</param>
        /// <returns>A single <see cref="Bin"/> object with the <see cref="Base.TBin.WHName"/> you specified.</returns>
        public Bin this[string whName] => this.GetBin(whName);

        /// <summary>
        /// Gets all the bins in your account.
        /// </summary>
        /// <returns>An array of <see cref="Bin"/>s.</returns>
        public LocationBins[] GetBins() => this.GetPlural<LocationBins>();

        /// <summary>
        /// Gets all the bins that fit the filters provided.
        /// </summary>
        /// <param name="filters">An array of <see cref="Basics.IFilter"/>s to search for bins.</param>
        /// <returns>An array of <see cref="Bin"/>s based on the filters provided.</returns>
        public LocationBins[] GetBins(params Basics.IFilter[] filters) => this.GetPlural<LocationBins>(filters);

        /// <summary>
        /// Gets the bins on the specified page.
        /// </summary>
        /// <param name="pageNum">The page number.</param>
        /// <param name="pageSize">The maximum number of bins to return.</param>
        /// <returns>An array of <see cref="Bin"/>s on the specified page.</returns>
        public LocationBins[] GetBins(int pageNum, int pageSize) => this.GetPlural<LocationBins>(pageNum, pageSize);

        /// <summary>
        /// Gets the bin with the specified <see cref="Base.TBin.WarehouseLocationID"/>.
        /// </summary>
        /// <param name="warehouseLocationID">The <see cref="Base.TBin.WarehouseLocationID"/> of the bin you are retrieving.</param>
        /// <returns>A single <see cref="Bin"/> object with the <see cref="Base.TBin.WarehouseLocationID"/> you specified.</returns>
        public Bin GetBin(int warehouseLocationID) => this.GetSingular<LocationBins>(warehouseLocationID, "WarehouseLocationID").Bins.FirstOrDefault();

        /// <summary>
        /// Gets the bin with the specified <see cref="Base.TBin.WHName"/>.
        /// </summary>
        /// <param name="whName">The <see cref="Base.TBin.WHName"/> of the bin you are retrieving.</param>
        /// <returns>A single <see cref="Bin"/> object with the <see cref="Base.TBin.WHName"/> you specified.</returns>
        public Bin GetBin(string whName) => this.GetSingular<LocationBins>(whName, "WHName").Bins.FirstOrDefault();

        /// <summary>
        /// Creates the bins provided in TopShelf.
        /// </summary>
        /// <param name="bins">The bins you would like to create.</param>
        /// <returns>An array of <see cref="Bin"/>s that were created.</returns>
        public Bin[] CreateBins(params Bin[] bins) => this.CreatePlural<Bin>(bins);

        /// <summary>
        /// Updates existing bins in TopShelf.
        /// </summary>
        /// <param name="bins">The existing bins that you are updating.</param>
        /// <returns>An array of <see cref="Bin"/>s that were updated.</returns>
        public Bin[] UpdateBins(params Bin[] bins) => this.UpdatePlural<Bin>(bins);

        /// <summary>
        /// Deletes existing bins in TopShelf.
        /// </summary>
        /// <param name="bins">The bins you would like to delete.</param>
        /// <returns>True if the delete was successful.</returns>
        public bool DeleteBins(params Bin[] bins) => this.DeletePlural<Bin>(bins);

        /// <summary>
        /// Deletes existing bins in TopShelf.
        /// </summary>
        /// <param name="warehouseLocationIDs">An array of <see cref="Base.TBin.WarehouseLocationID"/>s that you would like to delete.</param>
        /// <returns>True if the delete was successful.</returns>
        public bool DeleteBins(params int[] warehouseLocationIDs) => this.DeletePlural<Bin>(warehouseLocationIDs.Select(WarehouseLocationID => new Bin()
        {
            WarehouseLocationID = WarehouseLocationID
        }).ToArray());
    }
}
