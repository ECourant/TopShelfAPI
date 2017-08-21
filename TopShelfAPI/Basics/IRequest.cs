using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopShelfAPI.Basics
{
    internal interface IRequest
    {
        Guid RequestID { get; set; }

        string Target { get; set; }

        Enums.RequestType Type { get; set; }

        IFilter[] Filters { get; set; }

        string Body { get; set; }
    }
}
