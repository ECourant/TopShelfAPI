using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TopShelfAPI.Base
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class TEnumerable<T> : IEnumerable<T> where T : TEnumerableItem
    {
        /// <summary>
        /// 
        /// </summary>
        public TEnumerable() => this._Items = new List<T>();

        /// <summary>
        /// 
        /// </summary>
        public TEnumerable(IEnumerable<T> items)
        {
            this._Items = new List<T>();
            foreach (var Item in items)
                this.Add(Item);
        }

        /// <summary>
        /// 
        /// </summary>
        [JsonIgnore]
        public int Count => this._Items.Count;

        [JsonProperty("Items")]
        private List<T> _Items { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T this [int id]
        {
            get => this.Get(id);
            set => this.Update(value, id);
        }

        /// <summary>
        /// Returns an object based on its Name identifier. NOTE: Not all objects have a unique name identifier and a <see cref="NotImplementedException"/> may be thrown.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public T this [string name]
        {
            get => this.Get(name);
            set => this.Update(value, name);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public static implicit operator TEnumerable<T>(T[] value) => new TEnumerable<T>(value);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator() => this._Items.GetEnumerator();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator() => this._Items.GetEnumerator();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T Get(int id) => this._Items.Where(Item => Item.ItemID != null && Item.ItemID == id).FirstOrDefault();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public T Get(string name) => this._Items.Where(Item => !string.IsNullOrWhiteSpace(Item.ItemName) && Item.ItemName == name).FirstOrDefault();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Contains(int id) => this._Items.Where(Item => Item.ItemID != null && Item.ItemID == id).Count() > 0;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool Contains(string name) => this._Items.Where(Item => !string.IsNullOrWhiteSpace(Item.ItemName) && Item.ItemName == name).Count() > 0;

        /// <summary>
        /// Adds an item to the collection.
        /// </summary>
        /// <param name="item"></param>
        public void Add(T item)
        {
            if (item.ItemID == null && string.IsNullOrWhiteSpace(item.ItemName))
                throw new ArgumentException($"Error, cannot add a [{typeof(T).Name}] without a valid ID or Name");
            if (this.Contains(item.ItemID ?? -1) || this.Contains(item.ItemName))
                throw new InvalidOperationException($"Error, a [{typeof(T).Name}] already exists in this collection with ID [{item.ItemID ?? -1}] or with Name [{item.ItemName}]");
            this._Items.Add(item);
        }

        private void Update(T value, int id)
        {
            if (value.ItemID != id)
                value.ItemID = id; // If the user is trying to overwrite an item with a specfic id with an object that does not have a matching id, then the id will be assigned to that object.
            if (this.Contains(id))
            {
                int Index = this._Items.IndexOf(this.Get(id));
                this._Items[Index] = value;
            }
            else
                throw new KeyNotFoundException($"Error, could not update [{typeof(T).Name}] with ID [{id}] because it does not exist in the current collection.");
        }

        private void Update(T value, string name)
        {
            if (value.ItemName != name)
                value.ItemName = name; // If the user is trying to overwrite an item with a specfic name with an object that does not have a matching name, then the name will be assigned to that object.
            if (this.Contains(name))
            {
                int Index = this._Items.IndexOf(this.Get(name));
                this._Items[Index] = value;
            }
            else
                throw new KeyNotFoundException($"Error, could not update [{typeof(T).Name}] with Name [{name}] because it does not exist in the current collection.");
        }
    }
}
