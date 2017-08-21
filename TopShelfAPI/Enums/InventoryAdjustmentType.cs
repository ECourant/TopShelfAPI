using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopShelfAPI
{
    /// <summary>
    /// Represents the typeof of adjustments that can be made to inventory QTYs.
    /// </summary>
    public enum InventoryAdjustmentType
    {
        /// <summary>
        /// Will set the QTY.
        /// </summary>
        Set,

        /// <summary>
        /// Will add to the current QTY.
        /// </summary>
        Add,

        /// <summary>
        /// Will remove from the current QTY.
        /// </summary>
        Remove
    }
}
