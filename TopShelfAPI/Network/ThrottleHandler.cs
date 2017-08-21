using System;
using System.Linq;
using Newtonsoft.Json;

namespace TopShelfAPI.Network
{
    internal class ThrottleHandler
    {
        internal ThrottleHandler(TSConfiguration configuration)
        {
            this.Configuration = configuration;
            this.PerMinuteThrottling = new System.Collections.Concurrent.ConcurrentDictionary<int, System.Collections.Concurrent.ConcurrentBag<byte>>();
            this.PerDayThrottling = new System.Collections.Concurrent.ConcurrentDictionary<int, System.Collections.Concurrent.ConcurrentBag<byte>>();
            this.LastRequestMade = new System.Collections.Concurrent.ConcurrentStack<DateTime>();
            this.LastRequestMade.Push(DateTime.Now.Add(-this.Configuration.RequestLimit.MinDelayBetweenRequests));
        }

        private ThrottleHandler()
        {
            return;
        }

        [JsonIgnore]
        private int CurrentThrottleMinuteKey => Convert.ToInt32(DateTime.Now.ToString("yyMMddHHmm"));

        [JsonIgnore]
        private int CurrentThrottleDayKey => Convert.ToInt32(DateTime.Now.ToString("yyMMdd"));

        [JsonIgnore]
        private int NextThrottleMinuteKey => Convert.ToInt32(DateTime.Now.AddMinutes(1).ToString("yyMMddHHmm"));

        [JsonIgnore]
        private int NextThrottleDayKey => Convert.ToInt32(DateTime.Now.AddDays(1).ToString("yyMMdd"));

        [JsonIgnore]
        private TSConfiguration Configuration { get; set; }

        [JsonProperty("PerMinuteRequests")]
        private System.Collections.Concurrent.ConcurrentDictionary<int, System.Collections.Concurrent.ConcurrentBag<byte>> PerMinuteThrottling { get; set; }

        [JsonProperty("PerDayRequests")]
        private System.Collections.Concurrent.ConcurrentDictionary<int, System.Collections.Concurrent.ConcurrentBag<byte>> PerDayThrottling { get; set; }

        [JsonProperty("LastRequestMade")]
        private System.Collections.Concurrent.ConcurrentStack<DateTime> LastRequestMade { get; set; }

        internal static ThrottleHandler LoadThrottleData(TSConfiguration configuration) => LoadThrottleData(configuration, TSDefaults.ThrottleDataFileName);

        internal static ThrottleHandler LoadThrottleData(TSConfiguration configuration, string path)
        {
            ThrottleHandler Temp = Newtonsoft.Json.JsonConvert.DeserializeObject<ThrottleHandler>(System.IO.File.ReadAllText(path));
            Temp.Configuration = configuration;
            return Temp;
        }

        internal void ThrottleRequest()
        {
#if DEBUG
            int CallsToday = this.PerDayThrottling.ContainsKey(this.CurrentThrottleDayKey) ? this.PerDayThrottling[this.CurrentThrottleDayKey].Count : 0;
            int CallsThisMinute = this.PerMinuteThrottling.ContainsKey(this.CurrentThrottleMinuteKey) ? this.PerMinuteThrottling[this.CurrentThrottleMinuteKey].Count : 0;
            if (!this.LastRequestMade.TryPeek(out DateTime TempLastRequestTimestamp))
                throw new InvalidOperationException("Request cannot be completed because the last request time could not be retrieved.");
            Console.WriteLine($"[{DateTime.Now.ToLongTimeString()}] Throttle: Starting to throttle request, Stats; CallsToday\\CallsThisMinute\\LastCall, {CallsToday}\\{CallsThisMinute}\\{TempLastRequestTimestamp.ToString()}");
#endif
            ResetThrottle: // this will be done if it waits for a new day or for the next minute.
            this.CleanupOldThrottleData();
            int CurrentDayKey = this.CurrentThrottleDayKey;
            if (this.PerDayThrottling.ContainsKey(CurrentDayKey))
            {
                if (this.PerDayThrottling[CurrentDayKey].Count >= this.Configuration.RequestLimit.MaxCallsPerDay) // there is no else for this because if its less than the max calls per day then it doesnt need to throttle for this.
                    if (this.GetThrottleDayKey(DateTime.Now.Add(this.Configuration.RequestTimeout)) >= this.NextThrottleDayKey)
                    {
                        // it will be a new day before the request would timeout, wait for it.
                        int NextThrottleDay = this.NextThrottleDayKey;
                        while (this.CurrentThrottleDayKey < NextThrottleDay)
                            System.Threading.Thread.Sleep(1000);
                        goto ResetThrottle;
                    }
                    else if (this.Configuration.TimeoutRequestsIfLimitIsReached) // The request will not be able to be processed within the timeout time. Too many requests have been made in the past 24 hours.
                        throw new OverflowException($"Request cannot be completed within the specified timeout time because too many requests have been made in the past 24 hours!");
            } 
            else
                this.PerDayThrottling.TryAdd(CurrentDayKey, new System.Collections.Concurrent.ConcurrentBag<byte>());

            int CurrentMinuteKey = this.CurrentThrottleMinuteKey;
            if (this.PerMinuteThrottling.ContainsKey(CurrentMinuteKey))
            {
                if (this.PerMinuteThrottling[CurrentMinuteKey].Count >= this.Configuration.RequestLimit.MaxCallsPerMinute)
                    if (this.GetThrottleMinuteKey(DateTime.Now.Add(this.Configuration.RequestTimeout)) >= this.NextThrottleMinuteKey)
                    {
                        int NextThrottleMinute = this.NextThrottleMinuteKey;
                        while (this.GetThrottleMinuteKey(DateTime.Now) < NextThrottleMinute) // If the max number of requests for this minute have already been made, then wait for the next minute. Assuming the request will not timeout before then.
                            System.Threading.Thread.Sleep(1000);
                        goto ResetThrottle;
                    }
                    else if (this.Configuration.TimeoutRequestsIfLimitIsReached) // The timeout is set too low, and as a result the request will almost certainly timeout BEFORE the next minute and the request will not be able to be made in time.
                        throw new InvalidOperationException($"Request cannot be completed because the request will time out before the request can be completed, try increasing your request timeout!");
            }
            else
                this.PerMinuteThrottling.TryAdd(CurrentMinuteKey, new System.Collections.Concurrent.ConcurrentBag<byte>());

            CurrentDayKey = this.CurrentThrottleDayKey;
            CurrentMinuteKey = this.CurrentThrottleMinuteKey;

            if (!this.PerDayThrottling.ContainsKey(CurrentDayKey))
                this.PerDayThrottling.TryAdd(CurrentDayKey, new System.Collections.Concurrent.ConcurrentBag<byte>());
            this.PerDayThrottling[CurrentDayKey].Add(0);

            if (!this.PerMinuteThrottling.ContainsKey(CurrentMinuteKey))
                this.PerMinuteThrottling.TryAdd(CurrentMinuteKey, new System.Collections.Concurrent.ConcurrentBag<byte>());
            this.PerMinuteThrottling[CurrentMinuteKey].Add(0);

            if (!this.LastRequestMade.TryPeek(out DateTime LastRequestTimestamp))
                throw new InvalidOperationException("Request cannot be completed because the last request time could not be retrieved.");
            if (LastRequestTimestamp.Add(this.Configuration.RequestLimit.MinDelayBetweenRequests) > DateTime.Now)
                while (DateTime.Now < LastRequestTimestamp.Add(this.Configuration.RequestLimit.MinDelayBetweenRequests)) // If the last request was made before the minimum amount of time between requests has past, then wait.
                    System.Threading.Thread.Sleep(1);
            this.LastRequestMade.Push(DateTime.Now);
#if DEBUG
            Console.WriteLine($"[{DateTime.Now.ToLongTimeString()}] Throttle: Sending Request Now!");
#endif
        }

        internal void SaveThrottleData() => this.SaveThrottleData(TSDefaults.ThrottleDataFileName);

        internal void SaveThrottleData(string path) => System.IO.File.WriteAllText(path, Newtonsoft.Json.JsonConvert.SerializeObject(this, Formatting.Indented));

        private int GetThrottleMinuteKey(DateTime timestamp) => Convert.ToInt32(timestamp.ToString("yyMMddHHmm"));

        private int GetThrottleDayKey(DateTime timestamp) => Convert.ToInt32(timestamp.ToString("yyMMdd"));

        private void CleanupOldThrottleData()
        {
            int CurrentKey = -1;
            if (this.PerDayThrottling.Count > 0)
            {
                CurrentKey = this.CurrentThrottleDayKey;
                foreach (var Key in this.PerDayThrottling.Keys.Where(Key => Key < CurrentKey))
                    this.PerDayThrottling.TryRemove(Key, out System.Collections.Concurrent.ConcurrentBag<byte> Temp);
            }

            if (this.PerMinuteThrottling.Count > 0)
            {
                CurrentKey = this.CurrentThrottleMinuteKey;
                foreach (var Key in this.PerMinuteThrottling.Keys.Where(Key => Key < CurrentKey))
                    this.PerMinuteThrottling.TryRemove(Key, out System.Collections.Concurrent.ConcurrentBag<byte> Temp);
            }
        }
    }
}
