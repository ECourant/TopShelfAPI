using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopShelfAPI.Pipelines
{
    /// <summary>
    /// Represents a pipeline of functions for getting, creating, updating and deleting <see cref="Part"/>s.
    /// </summary>
    public sealed class PartsPipeline : Base.TPipeline
    {
        internal PartsPipeline(Network.TSRequestDelegate requestDelegate) : base(requestDelegate)
        {
            return;
        }

        protected override string DefaultTarget => "parts";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="partID"></param>
        /// <returns></returns>
        public Part this[int partID] => this.GetPart(partID);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="partName"></param>
        /// <returns></returns>
        public Part this[string partName] => this.GetPart(partName);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Part[] GetParts() => this.GetPlural<Part>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        public Part[] GetParts(params Basics.IFilter[] filters) => this.GetPlural<Part>(filters);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public Part[] GetParts(int pageNum, int pageSize) => this.GetPlural<Part>(pageNum, pageSize);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="partID"></param>
        /// <returns></returns>
        public Part GetPart(int partID) => this.GetSingular<Part>(partID, "PartID");

        /// <summary>
        /// 
        /// </summary>
        /// <param name="partName"></param>
        /// <returns></returns>
        public Part GetPart(string partName) => this.GetSingular<Part>(partName, "PartName");

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parts"></param>
        /// <returns></returns>
        public Part[] CreateParts(params Part[] parts) => this.CreatePlural<Part>(parts);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parts"></param>
        /// <returns></returns>
        public Part[] UpdateParts(params Part[] parts) => this.UpdatePlural<Part>(parts);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parts"></param>
        /// <returns></returns>
        public bool DeleteParts(params Part[] parts) => this.DeletePlural<Part>(parts);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="partIDs"></param>
        /// <returns></returns>
        public bool DeleteParts(params int[] partIDs) => this.DeletePlural<Part>(partIDs.Select(PartID => new Part()
        {
            PartID = PartID
        }).ToArray());
    }
}
