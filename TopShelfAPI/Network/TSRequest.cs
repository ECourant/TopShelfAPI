using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopShelfAPI.Basics;
using TopShelfAPI.Enums;

namespace TopShelfAPI.Network
{
    internal class TSRequest : Basics.IRequest
    {
        internal TSRequest()
        {
            this.RequestID = Guid.NewGuid();
        }

        public Guid RequestID { get; set; }

        public string Target { get; set; }

        public RequestType Type { get; set; }

        public IFilter[] Filters { get; set; }

        public string Body { get; set; }
    }
}
