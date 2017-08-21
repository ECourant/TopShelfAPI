using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TopShelfAPI
{
    /// <summary>
    /// Represents a collection of bins within a given location.
    /// </summary>
    public class LocationBins : Base.TLocation
    {
        /// <summary>
        /// Gets a collection of bins in this location.
        /// </summary>
        [JsonProperty("Bins")]
        public Base.TEnumerable<Bin> Bins { get; private set; }
    }
}
