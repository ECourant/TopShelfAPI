using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TopShelfAPI
{
    /// <summary>
    /// Represents TopShelf's unit of measure for <see cref="Part"/>s.
    /// </summary>
    public class UnitOfMeasure : Base.TEnumerableItem
    {
        /// <summary>
        /// Gets or sets the name of the unit of measure.
        /// </summary>
        [JsonProperty("UnitOfMeasure"), JsonRequired]
        public string UnitOfMeasureName { get; set; }

        /// <summary>
        /// Gets or sets the multiplier.
        /// </summary>
        [JsonIgnore]
        public double UnitMultiplier { get; set; }

        [JsonIgnore]
        internal override int? ItemID { get => null; set => throw new NotImplementedException(); }

        [JsonIgnore]
        internal override string ItemName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        [JsonProperty("UnitMultipler"), JsonRequired]
        private string UnitMultiplerHandler
        {
            get => this.UnitMultiplier.ToString();
            set
            {
                try
                {
                    this.UnitMultiplier = Convert.ToDouble(value);
                }
                catch
                {
                    this.UnitMultiplier = 0.00;
                }
            }
        }
    }
}
