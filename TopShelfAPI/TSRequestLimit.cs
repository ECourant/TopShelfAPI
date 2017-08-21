using System;

namespace TopShelfAPI
{
    /// <summary>
    /// The request limits that will be used to throttle requests to your account. 
    /// </summary>
    public class TSRequestLimit
    {
        /// <summary>
        /// Creates a new <see cref="TSRequestLimit"/> with the specified limits.
        /// </summary>
        /// <param name="maxCallsPerMinute">The maximum number of requests that will be sent to TopShelf in 60 seconds.</param>
        /// <param name="maxCallsPerDay">The maximum number of requests that will be sent to TopShelf in 24 hours.</param>
        /// <exception cref="ArgumentOutOfRangeException">Will be thrown if <paramref name="maxCallsPerDay"/> or <paramref name="maxCallsPerMinute"/> is less than or equal to 0.</exception> 
        public TSRequestLimit(int maxCallsPerMinute, int maxCallsPerDay)
        {
            this.MaxCallsPerMinute = maxCallsPerMinute;
            this.MaxCallsPerDay = maxCallsPerDay;
        }

        /// <summary>
        /// <para>Gets or sets the maximum number of requests that will be sent to TopShelf in 60 seconds.</para>
        /// <para>You can set this to any non 0 positive number, but it is recommended that you keep this between 1 and 10 requests per minute to avoid possible errors.</para>
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">Will be thrown if the value provided is less than or equal to 0.</exception>
        public int MaxCallsPerMinute
        {
            get => this._MaxCallsPerMinute;
            set => this._MaxCallsPerMinute = value <= 0 ? throw new ArgumentOutOfRangeException("value", "MaxCallsPerMinute must be greater than 0") : value;
        }

        /// <summary>
        /// <para>Gets or sets the maximum number of requests that will be sent to TopShelf in 24 hours.</para>
        /// <para>You can set this to any non 0 positive number, but this will vary depending on your account. Contact support@scoutsft.com to get information on your daily request limit.</para>
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">Will be thrown if the value provided is less than or equal to 0.</exception> 
        public int MaxCallsPerDay
        {
            get => this._MaxCallsPerDay;
            set => this._MaxCallsPerDay = value <= 0 ? throw new ArgumentOutOfRangeException("value", "MaxCallsPerDay must be greater than 0") : value;
        }

        /// <summary>
        /// <para>Gets or sets the maximum number of concurrent requests that can be sent to TopShelf.</para>
        /// <para>It is recommended that this be left at 1, concurrent requests to TopShelf can cause deadlock errors. But if it is changed, it is recommended that you do not set it to be higher than the number of threads available - 1.</para>
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">Will be thrown if the value provided is less than or equal to 0.</exception>
        public int MaxConcurrentCalls
        {
            get => this._MaxConcurrentCalls;
            set => this._MaxConcurrentCalls = value <= 0 ? throw new ArgumentOutOfRangeException("value", "MaxConcurrentCalls must be greater than 0") : value;
        }

        /// <summary>
        /// <para>Gets or sets the minimum amount of time to pause between requests, regardless of the current throttle, or the number of concurrent requests being made. The default value is 2 seconds.</para>
        /// <para>It is recommended that you have atleast 2 seconds between requests, if you are making a lot of very large requests then you should allow for more time in-between each request. Setting this to 0 seconds might cause errors.</para>
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">Will be thrown if the <see cref="TimeSpan"/> provided is less than 0 seconds.</exception>
        public TimeSpan MinDelayBetweenRequests
        {
            get => this._MinDelayBetweenRequests;
            set => this._MinDelayBetweenRequests = value < TimeSpan.FromSeconds(0) ? throw new ArgumentOutOfRangeException("value", "MinDelayBetweenRequests must be greater than or equal to 0 seconds.") : value;
        }

        private int _MaxCallsPerMinute { get; set; } = 1;

        private int _MaxCallsPerDay { get; set; } = 1;

        private int _MaxConcurrentCalls { get; set; } = 1;

        private TimeSpan _MinDelayBetweenRequests { get; set; } = TimeSpan.FromSeconds(2);
    }
}
