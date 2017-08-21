using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopShelfAPI
{
    /// <summary>
    /// The type of <see cref="Document"/> that can exist depending on whether inventory is added from the document or to the document.
    /// </summary>
    public enum DocumentType
    {
        /// <summary>
        /// The type of document that items will be added or picked to from inventory.
        /// </summary>
        PurchaseOrder = 1,

        /// <summary>
        /// The type of document that items will be added to inventroy from.
        /// </summary>
        SalesOrder = 2
    }
}
