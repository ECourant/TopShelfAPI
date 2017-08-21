using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopShelfAPI.Pipelines
{
    /// <summary>
    /// Represents a pipeline of functions for getting, creating, updating and deleting <see cref="Client"/>s and <see cref="Location"/>s.
    /// </summary>
    public sealed class ClientsLocationsPipeline : Base.TPipeline
    {
        internal ClientsLocationsPipeline(Network.TSRequestDelegate requestDelegate) : base(requestDelegate)
        {
            return;
        }

        protected override string DefaultTarget => "clients";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="clientID"></param>
        /// <returns></returns>
        public Client this [int clientID] => this.GetClient(clientID);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="clientName"></param>
        /// <returns></returns>
        public Client this [string clientName] => this.GetClient(clientName);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Client[] GetClients() => this.GetPlural<Client>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        public Client[] GetClients(params Basics.IFilter[] filters) => this.GetPlural<Client>(filters);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public Client[] GetClients(int pageNum, int pageSize) => this.GetPlural<Client>(pageNum, pageSize);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="clientID"></param>
        /// <returns></returns>
        public Client GetClient(int clientID) => this.GetSingular<Client>(clientID, "ClientID");

        /// <summary>
        /// 
        /// </summary>
        /// <param name="clientName"></param>
        /// <returns></returns>
        public Client GetClient(string clientName) => this.GetSingular<Client>(clientName, "ClientName");

        /// <summary>
        /// 
        /// </summary>
        /// <param name="clients"></param>
        /// <returns></returns>
        public Client[] CreateClients(params Client[] clients) => this.CreatePlural<Client>(clients);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="clients"></param>
        /// <returns></returns>
        public Client[] UpdateClients(params Client[] clients) => this.UpdatePlural<Client>(clients);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="clients"></param>
        /// <returns></returns>
        public bool DeleteClients(params Client[] clients) => this.DeletePlural<Client>(clients);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="clientIDs"></param>
        /// <returns></returns>
        public bool DeleteClients(params int[] clientIDs) => this.DeletePlural<Client>(clientIDs.Select(ClientID => new Client()
        {
            ClientID = ClientID
        }).ToArray());

        /// <summary>
        /// 
        /// </summary>
        /// <param name="locations"></param>
        /// <returns></returns>
        public bool DeleteLocations(params Location[] locations) => this.DeletePlural<Location>(locations);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="locationIDs"></param>
        /// <returns></returns>
        public bool DeleteLocations(params int[] locationIDs) => this.DeletePlural<Location>(locationIDs.Select(LocationID => new Location()
        {
            LocationID = LocationID
        }).ToArray());
    }
}
