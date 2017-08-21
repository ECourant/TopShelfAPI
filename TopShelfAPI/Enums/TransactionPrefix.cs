using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopShelfAPI
{
    /// <summary>
    /// Another form of representing types of <see cref="Document"/>s.
    /// </summary>
    public enum TransactionPrefix
    {
        /// <summary>
        /// Purchase Order
        /// </summary>
        PurchaseOrder,

        /// <summary>
        /// Sales Order
        /// </summary>
        SalesOrder
    }
}
