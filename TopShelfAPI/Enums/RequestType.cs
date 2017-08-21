using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopShelfAPI.Enums
{
    /// <summary>
    /// Request types to be used with <see cref="Network.RequestHandler"/>
    /// </summary>
    internal enum RequestType
    {
        /// <summary>
        /// Http GET Request
        /// </summary>
        GET,

        /// <summary>
        /// Http POST Request
        /// </summary>
        POST,

        /// <summary>
        /// Http PUT Request
        /// </summary>
        PUT,

        /// <summary>
        /// Http DELETE Request, NOTE: I have not yet programmed sending a delete request with a body.
        /// </summary>
        DELETE
    }
}
