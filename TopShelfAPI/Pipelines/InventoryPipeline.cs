using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopShelfAPI.Pipelines
{
    /// <summary>
    /// Represents a pipeline of functions for getting, creating, updating and deleting <see cref="PartInventory"/>.
    /// </summary>
    public sealed class InventoryPipeline : Base.TPipeline
    {
        internal InventoryPipeline(Network.TSRequestDelegate requestDelegate) : base(requestDelegate)
        {
            this.DetailLevel = TSDefaults.DefaultDetailLevel;
        }

        /// <summary>
        /// Gets or sets the <see cref="TopShelfAPI.DetailLevel"/> to be used when requesting inventory data.
        /// </summary>
        public DetailLevel DetailLevel { get; set; }

        protected override string DefaultTarget => "inventory";

        private Filtering.TSFilter[] DetailLevelFilter => new[] { new Filtering.TSFilter("detail_level", this.DetailLevel.ToString().ToLower()) };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="partID"></param>
        /// <returns></returns>
        public PartInventory this[int partID] => null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="partName"></param>
        /// <returns></returns>
        public PartInventory this[string partName] => null;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public PartInventory[] GetInventory() => this.GetPlural<PartInventory>(this.DetailLevelFilter);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public PartInventory[] GetInventory(params Basics.IFilter[] filter) => this.GetPlural<PartInventory>(filter.Concat(this.DetailLevelFilter).ToArray());

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public PartInventory[] GetInventory(int pageNum, int pageSize) => this.GetPlural<PartInventory>(pageNum, pageSize, this.DetailLevelFilter);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="partID"></param>
        /// <returns></returns>
        public PartInventory GetPartInventory(int partID) => this.GetSingular<PartInventory>(partID, "PartID", this.DetailLevelFilter);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="partName"></param>
        /// <returns></returns>
        public PartInventory GetPartInventory(string partName) => this.GetSingular<PartInventory>(partName, "PartName", this.DetailLevelFilter);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="clientID"></param>
        /// <returns></returns>
        public PartInventory[] GetClientInventory(int clientID) => this.GetPlural<PartInventory>(new[] 
        {
            new Filtering.TSFilter("ClientID", clientID.ToString())
        }.Concat(this.DetailLevelFilter).ToArray());

        /// <summary>
        /// 
        /// </summary>
        /// <param name="clientName"></param>
        /// <returns></returns>
        public PartInventory[] GetClientInventory(string clientName) => this.GetPlural<PartInventory>(new[] 
        {
            new Filtering.TSFilter("ClientName", clientName)
        }.Concat(this.DetailLevelFilter).ToArray());

        /// <summary>
        /// 
        /// </summary>
        /// <param name="locationID"></param>
        /// <returns></returns>
        public PartInventory[] GetLocationInventory(int locationID) => this.GetPlural<PartInventory>(new[] 
        {
            new Filtering.TSFilter("LocationID", locationID.ToString())
        }.Concat(this.DetailLevelFilter).ToArray());

        /// <summary>
        /// 
        /// </summary>
        /// <param name="locationName"></param>
        /// <returns></returns>
        public PartInventory[] GetLocationInventory(string locationName) => this.GetPlural<PartInventory>(new[] 
        {
            new Filtering.TSFilter("LocationName", locationName)
        }.Concat(this.DetailLevelFilter).ToArray());

        /// <summary>
        /// 
        /// </summary>
        /// <param name="warehouseLocationID"></param>
        /// <returns></returns>
        public PartInventory[] GetBinInventory(int warehouseLocationID) => this.GetPlural<PartInventory>(new[] 
        {
            new Filtering.TSFilter("WarehouseLocationID", warehouseLocationID.ToString())
        }.Concat(this.DetailLevelFilter).ToArray());

        /// <summary>
        /// 
        /// </summary>
        /// <param name="whName"></param>
        /// <returns></returns>
        public PartInventory[] GetBinInventory(string whName) => this.GetPlural<PartInventory>(new[] 
        {
            new Filtering.TSFilter("WHName", whName)
        }.Concat(this.DetailLevelFilter).ToArray());

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reset"></param>
        /// <returns></returns>
        public PartInventory[] GetNewInventory(bool reset) => this.GetPlural<PartInventory>(new[]
        {
            new Filtering.TSFilter("NewQty", "1"),
            new Filtering.TSFilter("reset_flag", reset ? "1" : "0"),
        }.Concat(this.DetailLevelFilter).ToArray());

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inventoryUpdates"></param>
        /// <returns></returns>
        public bool UpdateInventory(params InventoryUpdate[] inventoryUpdates) => this.UpdatePluralResponseless<InventoryUpdate>(inventoryUpdates);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="partInventory"></param>
        /// <returns></returns>
        public bool UpdateInventory(params PartInventory[] partInventory) => this.UpdatePluralResponseless<PartInventory>(partInventory);
    }
}
