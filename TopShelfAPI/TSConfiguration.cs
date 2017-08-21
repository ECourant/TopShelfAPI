using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopShelfAPI
{
    /// <summary>
    /// Represents a configuration object used to define settings for communicating with TopShelf's REST API.
    /// </summary>
    public sealed class TSConfiguration
    {
        /// <summary>
        /// Get or sets TopShelf's REST API URL, the default value is "https://api.scoutsft.com/"
        /// </summary>
        /// <exception cref="ArgumentException">Is thrown if the url provided is null or blank.</exception>
        public string EndpointURL
        {
            get => this._EndpointURL;

            // TODO add regex verification of urls provided
            set => this._EndpointURL = string.IsNullOrWhiteSpace(value) ? throw new ArgumentException("EndpointURL cannot be null or white space!") : value;
        }

        /// <summary>
        /// Gets or sets the amount of time that will pass without a response after making a request.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">Is thrown if the <see cref="TimeSpan"/> provided is less than or equal to 0 milliseconds.</exception>
        public TimeSpan RequestTimeout
        {
            get => this._RequestTimeout;
            set => this._RequestTimeout = value <= TimeSpan.FromMilliseconds(0) ? throw new ArgumentOutOfRangeException("RequestTimeout timespan cannot be 0 or less!") : value;
        }

        /// <summary>
        /// <para>Gets or sets how timeouts and reaching API limits is handled, if this is set to true then when an API limit is reached and the request cannot be made before the limit would reset, then a <see cref="TimeoutException"/> would be thrown. If it is set to false then the request will wait until the API limit allows for the request to be made.</para>
        /// <para>However, at the moment because there are multiple timeouts in place, the request timeout itself that is controled when you call the method will still throw an exception if it takes too long to retrieve the data.</para>
        /// </summary>
        public bool TimeoutRequestsIfLimitIsReached
        {
            get => this._TimeoutRequestsIfLimitIsReached;
            set => this._TimeoutRequestsIfLimitIsReached = value;
        }

        /// <summary>
        /// <para>Gets or sets the amount of time between each save of the throttle data json file. This file stores the number of requests made and when so that request limits will not be exceded even if the program is stopped and started.</para>
        /// <para>The default is every minute.</para>
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">Is thrown if the <see cref="TimeSpan"/> provided is less than 500 milliseconds.</exception>
        public TimeSpan ThrottleDataSaveFrequency
        {
            get => this._ThrottleDataSaveFrequency;
            set => this._ThrottleDataSaveFrequency = value < TimeSpan.FromMilliseconds(500) ? throw new ArgumentOutOfRangeException("ThrottleDataSaveFrequency must not be less than 500 milliseconds!") : value;
        }

        /// <summary>
        /// <para>Gets or sets your account's license type, this will affect the default request limits defined in <see cref="RequestLimit"/>. The request limits can be changed regardless of the license specified.</para>
        /// </summary>
        public TopShelfLicense License
        {
            get => this._License;
            set
            {
                if (this._License != value)
                {
                    this._License = value;
                    switch (this._License)
                    {
                        case TopShelfLicense.Advanced:
                            this._RequestLimit = new TSRequestLimit(10, 200);
                            break;
                        case TopShelfLicense.Enterprise:
                            this._RequestLimit = new TSRequestLimit(10, 500);
                            break;
                        case TopShelfLicense.Other:
                            this._RequestLimit = new TSRequestLimit(10, 10000);
                            break;
                        case TopShelfLicense.Unleashed:
                            this._RequestLimit = new TSRequestLimit(10, 1000);
                            break;
                        default:
                            goto case TopShelfLicense.Other;
                    }
                }
            }
        }

        /// <summary>
        /// Gets the current request limits defined for your connection. See <see cref="TSRequestLimit"/>.
        /// </summary>
        public TSRequestLimit RequestLimit => this._RequestLimit;

        private string _EndpointURL { get; set; } = "https://api.scoutsft.com/";

        private TopShelfLicense _License { get; set; } = TopShelfLicense.Other;

        private TSRequestLimit _RequestLimit { get; set; } = new TSRequestLimit(10, 10000);

        private TimeSpan _RequestTimeout { get; set; } = TimeSpan.FromMinutes(10);

        private bool _TimeoutRequestsIfLimitIsReached { get; set; } = true;

        private TimeSpan _ThrottleDataSaveFrequency { get; set; } = TimeSpan.FromMinutes(1);
    }
}
