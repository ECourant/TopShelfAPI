using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopShelfAPI.Basics
{
    internal interface IResponse
    {
        Guid RequestID { get; set; }

        string URL { get; set; }

        int Code { get; set; }

        Exception Exception { get; set; }

        string Body { get; set; }
    }
}
