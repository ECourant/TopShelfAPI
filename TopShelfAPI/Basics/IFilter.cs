using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopShelfAPI.Basics
{
    /// <summary>
    /// The interface used to create filter objects.
    /// </summary>
    public interface IFilter
    {
        /// <summary>
        /// Gets or sets the name of the filter you are using.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Gets or sets the value of the field you are filtering.
        /// </summary>
        string Value { get; set; }

        /// <summary>
        /// Gets the string that will be added to the url query.
        /// </summary>
        string GetURLEncoded { get; }
    }
}
