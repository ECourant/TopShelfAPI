using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopShelfAPI
{
    /// <summary>
    /// The detail level for TopShelf's inventory data.
    /// </summary>
    public enum DetailLevel
    {
        /// <summary>
        /// Lists part and total QTY.
        /// </summary>
        None,

        /// <summary>
        /// List inventory per client.
        /// </summary>
        Low,

        /// <summary>
        /// List inventory per location.
        /// </summary>
        Medium,

        /// <summary>
        /// List inventory per bin.
        /// </summary>
        High,

        /// <summary>
        /// List individual serial numbers for assets, and qtys per lot number for lots. No difference for items.
        /// </summary>
        Max
    }
}
