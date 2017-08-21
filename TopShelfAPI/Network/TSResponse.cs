using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopShelfAPI.Network
{
    internal class TSResponse : Basics.IResponse
    {
        public Guid RequestID { get; set; }

        public string URL { get; set; }

        public int Code { get; set; }

        public Exception Exception { get; set; }

        public string Body { get; set; }
    }
}
