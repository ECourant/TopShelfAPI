using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopShelfAPI.Pipelines
{
    /// <summary>
    /// Represents a pipeline of functions for getting, creating, updating and deleting <see cref="Vendor"/>s.
    /// </summary>
    public sealed class VendorsPipeline : Base.TPipeline
    {
        internal VendorsPipeline(Network.TSRequestDelegate requestDelegate) : base(requestDelegate)
        {
            return;
        }

        protected override string DefaultTarget => "vendors";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vendorID"></param>
        /// <returns></returns>
        public Vendor this [int vendorID] => this.GetVendor(vendorID);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vendorName"></param>
        /// <returns></returns>
        public Vendor this [string vendorName] => this.GetVendor(vendorName);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Vendor[] GetVendors() => this.GetPlural<Vendor>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        public Vendor[] GetVendors(params Basics.IFilter[] filters) => this.GetPlural<Vendor>(filters);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public Vendor[] GetVendors(int pageNum, int pageSize) => this.GetPlural<Vendor>(pageNum, pageSize);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vendorID"></param>
        /// <returns></returns>
        public Vendor GetVendor(int vendorID) => this.GetSingular<Vendor>(vendorID, "VendorID");

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vendorName"></param>
        /// <returns></returns>
        public Vendor GetVendor(string vendorName) => this.GetSingular<Vendor>(vendorName, "VendorName");

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vendors"></param>
        /// <returns></returns>
        public Vendor[] CreateVendors(params Vendor[] vendors) => this.CreatePlural<Vendor>(vendors);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vendors"></param>
        /// <returns></returns>
        public Vendor[] UpdateVendors(params Vendor[] vendors) => this.UpdatePlural<Vendor>(vendors);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vendors"></param>
        /// <returns></returns>
        public bool DeleteVendors(params Vendor[] vendors) => this.DeletePlural<Vendor>(vendors);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vendorIDs"></param>
        /// <returns></returns>
        public bool DeleteVendors(params int[] vendorIDs) => this.DeletePlural<Vendor>(vendorIDs.Select(VendorID => new Vendor()
        {
            VendorID = VendorID
        }).ToArray());
    }
}
