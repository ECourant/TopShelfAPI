using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopShelfAPI.Pipelines
{
    /// <summary>
    /// Represents a pipeline of functions for getting, creating, updating and deleting <see cref="Carton"/>s.
    /// </summary>
    public sealed class CartonsPipeline : Base.TPipeline
    {
        internal CartonsPipeline(Network.TSRequestDelegate requestDelegate) : base(requestDelegate)
        {
            return;
        }

        protected override string DefaultTarget => "cartons";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cartonID"></param>
        /// <returns></returns>
        public Carton this [int cartonID] => this.GetCarton(cartonID);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="documentNumber"></param>
        /// <returns></returns>
        public Carton[] this [string documentNumber] => this.GetCartons(documentNumber);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Carton[] GetCartons() => this.GetPlural<Carton>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        public Carton[] GetCartons(params Basics.IFilter[] filters) => this.GetPlural<Carton>(filters);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public Carton[] GetCartons(int pageNum, int pageSize) => this.GetPlural<Carton>(pageNum, pageSize);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="documentID"></param>
        /// <returns></returns>
        public Carton[] GetCartons(int documentID) => this.GetPlural<Carton>(new Filtering.TSFilter("DocumentID", documentID.ToString()));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="documentNumber"></param>
        /// <returns></returns>
        public Carton[] GetCartons(string documentNumber) => this.GetPlural<Carton>(new Filtering.TSFilter("DocNumber", documentNumber));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cartonID"></param>
        /// <returns></returns>
        public Carton GetCarton(int cartonID) => this.GetSingular<Carton>(cartonID, "CartonID");

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cartons"></param>
        /// <returns></returns>
        public Carton[] CreateCartons(params Carton[] cartons) => this.CreatePlural<Carton>(cartons);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cartons"></param>
        /// <returns></returns>
        public Carton[] UpdateCartons(params Carton[] cartons) => this.UpdatePlural<Carton>(cartons);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cartons"></param>
        /// <returns></returns>
        public bool DeleteCartons(params Carton[] cartons) => this.DeletePlural<Carton>(cartons);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cartonIDs"></param>
        /// <returns></returns>
        public bool DeleteCartons(params int[] cartonIDs) => this.DeletePlural<Carton>(cartonIDs.Select(CartonID => new Carton()
        {
            CartonID = CartonID
        }).ToArray());
    }
}
