using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopShelfAPI.Base
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class TEnumerableItem
    {
        internal abstract int? ItemID { get; set; }

        internal abstract string ItemName { get; set; }
    }
}
