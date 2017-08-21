using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TopShelfAPI.JsonTemplates
{
    internal class JsonResponse<T> where T : Basics.ITopShelfObject
    {
        internal T[] Items
        {
            get
            {
                if (typeof(T) == typeof(Client))
                    return this.Clients;
                else if (typeof(T) == typeof(Document))
                    return this.Documents;
                else if (typeof(T) == typeof(PartInventory))
                    return this.PartInventory;
                else if (typeof(T) == typeof(Part))
                    return this.Parts;
                else if (typeof(T) == typeof(Carton))
                    return this.Cartons;
                else if (typeof(T) == typeof(Vendor))
                    return this.Vendors;
                else if (typeof(T) == typeof(LocationBins))
                    return this.Locations;
                else if (typeof(T) == typeof(Bin))
                    return this.Bins;
                else
                    return new T[] { };
            }
        }

        [JsonProperty("Bins")]
        private T[] Bins { get; set; }

        [JsonProperty("Locations")]
        private T[] Locations { get; set; }

        [JsonProperty("Clients")]
        private T[] Clients { get; set; }

        [JsonProperty("Documents")]
        private T[] Documents { get; set; }

        [JsonProperty("PartInventory")]
        private T[] PartInventory { get; set; }

        [JsonProperty("Parts")]
        private T[] Parts { get; set; }

        [JsonProperty("Cartons")]
        private T[] Cartons { get; set; }

        [JsonProperty("Vendors")]
        private T[] Vendors { get; set; }
    }
}
