using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopShelfAPI
{
    /// <summary>
    /// Represents different licenses in TopShelf. Each license type will change the default values in <see cref="TSRequestLimit"/>.
    /// </summary>
    public enum TopShelfLicense
    {
        /// <summary>
        /// TopShelf's Advanced Account License.
        /// </summary>
        Advanced,

        /// <summary>
        /// TopShelf's Enterprise Account License.
        /// </summary>
        Enterprise,

        /// <summary>
        /// TopShelf's Unleashed Account License.
        /// </summary>
        Unleashed,

        /// <summary>
        /// This will represent custom values in <see cref="TSRequestLimit"/>.
        /// </summary>
        Other
    }
}
