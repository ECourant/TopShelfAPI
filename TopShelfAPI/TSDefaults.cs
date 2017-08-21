using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopShelfAPI
{
    /// <summary>
    /// Represents the default variables for TopShelf.
    /// </summary>
    public static class TSDefaults
    {
        /// <summary>
        /// The default level of detail that will be returned when requesting inventory data.
        /// </summary>
        public const DetailLevel DefaultDetailLevel = DetailLevel.Max;

        /// <summary>
        /// The string provided from TopShelf's REST API if the DateTime object is not set.
        /// </summary>
        public const string NullDateTime = "0001-01-01T00:00:00";

        /// <summary>
        /// The name of the file that will be saved for all of the API's throttle data.
        /// </summary>
        public const string ThrottleDataFileName = "ThrottleData.json";

        /// <summary>
        /// The maximum number of items that can be returned from a single API call.
        /// </summary>
        public const int MaxPageSize = 100;

        /// <summary>
        /// The type of content that is sent to TopShelf with POST, PUT and DELETE requests.
        /// </summary>
        public const string MediaType = "application/json";

        /// <summary>
        /// The HTTP status code that is returned when something is deleted successfully.
        /// </summary>
        public const int SuccessfulDeleteCode = 204;
    }
}
