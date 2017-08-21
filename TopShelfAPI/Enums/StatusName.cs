using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopShelfAPI
{
    /// <summary>
    /// Represents the state of <see cref="Document"/>s in TopShelf.
    /// </summary>
    public enum StatusName
    {
        /// <summary>
        /// The document is <see cref="PickedComplete"/> and has tracking info.
        /// </summary>
        ShippedComplete,

        /// <summary>
        /// The document is <see cref="PickedIncomplete"/> and has tracking info.
        /// </summary>
        ShippedIncomplete,

        /// <summary>
        /// The document has all of it's items picked completely.
        /// </summary>
        PickedComplete,

        /// <summary>
        /// The document has items that are not completely picked.
        /// </summary>
        PickedIncomplete,

        /// <summary>
        /// The document has all of it's items completely received.
        /// </summary>
        ReceivedComplete,

        /// <summary>
        /// The document has items that are not completely received.
        /// </summary>
        ReceivedIncomplete,

        /// <summary>
        /// The document has not been opened by a user.
        /// </summary>
        Open,

        /// <summary>
        /// The document has been canceled and will not be picked.
        /// </summary>
        Canceled
    }
}
