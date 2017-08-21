using System;
using System.Web;

namespace TopShelfAPI.Filtering
{
    /// <summary>
    /// Used to filter GET requests.
    /// </summary>
    public class TSFilter : Basics.IFilter
    {
        /// <summary>
        /// Creates a new filter parameter with a blank value.
        /// </summary>
        /// <param name="Name">The filter or field you are using.</param>
        public TSFilter(string Name)
        {
            this.Name = Name;
            this.Value = string.Empty;
        }

        /// <summary>
        /// Creates a new filter with a value.
        /// </summary>
        /// <param name="Name">The filter or field you are using.</param>
        /// <param name="Value">The value you are filtering by.</param>
        public TSFilter(string Name, string Value)
        {
            this.Name = Name;
            this.Value = Value;
        }

        /// <summary>
        /// Gets or Sets the name of the field or filter you are using, this cannot be null or white space.
        /// </summary>
        /// <exception cref="ArgumentException">Is thrown when the value is null or white space.</exception>
        public string Name
        {
            get => this._Name;
            set => this._Name = string.IsNullOrWhiteSpace(value) ? throw new ArgumentException("Name cannot be null or white space!") : value;
        }

        /// <summary>
        /// Gets or Sets the value you are filtering by.
        /// </summary>
        public string Value { get; set; } // Value can be null or white space.

        /// <summary>
        /// Returns the URL encoded string for the filter.
        /// </summary>
        public string GetURLEncoded => $"{Name}={HttpUtility.UrlEncode(Value ?? string.Empty)}";

        private string _Name { get; set; }
    }
}
