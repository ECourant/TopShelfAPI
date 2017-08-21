using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TopShelfAPI.JsonTemplates
{
    internal class JsonRequest<T> where T : Basics.ITopShelfObject
    {
        internal JsonRequest(params T[] items)
        {
#if LANG_VERSION_7_1
            if (items is Client[] clientItems)
                this.Clients = clientItems;
            else if (items is Document[])
                this.Documents = items;
            else if (items is PartInventory[] partInventoryItems)
            {
                List<InventoryUpdate> InventoryUpdate = new List<InventoryUpdate>();
                foreach (var Item in partInventoryItems)
                    foreach (var Update in Item.GetInventoryUpdate(InventoryAdjustmentType.Set))
                        InventoryUpdate.Add(Update);
                this.InventoryUpdates = InventoryUpdate.ToArray();
            }
            else if (items is InventoryUpdate[] inventoryUpdateItems)
                this.InventoryUpdates = inventoryUpdateItems;
            else if (items is Part[])
                this.Parts = items;
            else if (items is Carton[])
                this.Cartons = items;
            else if (items is Vendor[])
                this.Vendors = items;
            else if (items is Bin[])
                this.Bins = items;
            else if (items is Location[])
                this.Clients = items.Select(Item => new Client() { ClientID = null, Locations = items.Select(Location => Location as Location).ToArray() }).ToArray();
            else
                throw new NotImplementedException($"Error, the type [{typeof(T).Name}] is not implemented as a valid ITopShelfObject type and cannot be parsed into a request!");
#else
            if (typeof(T) == typeof(Client))
                this.Clients = items as Client[];
            else if (typeof(T) == typeof(Document))
                this.Documents = items;
            else if (typeof(T) == typeof(PartInventory))
            {
                PartInventory[] partInventoryItems = items as PartInventory[];
                List<InventoryUpdate> InventoryUpdate = new List<InventoryUpdate>();
                foreach (var Item in partInventoryItems)
                    foreach (var Update in Item.GetInventoryUpdate(InventoryAdjustmentType.Set))
                        InventoryUpdate.Add(Update);
                this.InventoryUpdates = InventoryUpdate.ToArray();
            }
            else if (typeof(T) == typeof(InventoryUpdate))
                this.InventoryUpdates = items as InventoryUpdate[];
            else if (typeof(T) == typeof(Part))
                this.Parts = items;
            else if (typeof(T) == typeof(Carton))
                this.Cartons = items;
            else if (typeof(T) == typeof(Vendor))
                this.Vendors = items;
            else if (typeof(T) == typeof(Bin))
                this.Bins = items;
            else if (typeof(T) == typeof(Location))
                this.Clients = items.Select(Item => new Client() { ClientID = null, Locations = items.Select(Location => Location as Location).ToArray() }).ToArray();
            else
                throw new NotImplementedException($"Error, the type [{typeof(T).Name}] is not implemented as a valid ITopShelfObject type and cannot be parsed into a request!");
#endif
        }

        [JsonProperty("Clients", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        private Client[] Clients { get; set; }

        [JsonProperty("Documents", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        private T[] Documents { get; set; }

        [JsonProperty("InventoryUpdates", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        private InventoryUpdate[] InventoryUpdates { get; set; }

        [JsonProperty("Parts", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        private T[] Parts { get; set; }

        [JsonProperty("Cartons", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        private T[] Cartons { get; set; }

        [JsonProperty("Vendors", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        private T[] Vendors { get; set; }

        [JsonProperty("Bins", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        private T[] Bins { get; set; }
    }
}
