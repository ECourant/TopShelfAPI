using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopShelfAPI.Basics;
using TopShelfAPI.Enums;

namespace TopShelfAPI.Network
{
    internal class TSAdvancedRequest<T> : Basics.IRequest where T : Basics.ITopShelfObject
    {
        internal TSAdvancedRequest(params T[] items)
        {
            this.RequestID = Guid.NewGuid();
            if (items.Count() == 0)
                throw new ArgumentException("Error, you cannot create a request body with 0 items!");
            this.Body = Newtonsoft.Json.JsonConvert.SerializeObject(new JsonTemplates.JsonRequest<T>(items));
        }

        public Guid RequestID { get; set; }

        public string Target { get; set; }

        public RequestType Type { get; set; }

        public IFilter[] Filters { get; set; }

        public string Body { get; set; }
    }
}
