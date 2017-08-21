using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TopShelfAPI.Helpers;

namespace TopShelfAPI.Network
{
    internal sealed class RequestHandler
    {
        internal RequestHandler(TSConfiguration configuration, TSCredential credentials)
        {
            this.Configuration = configuration;
            this.Credentials = credentials;
            this.RequestsToBeMade = new System.Collections.Concurrent.ConcurrentQueue<Basics.IRequest>();
            this.Responses = new System.Collections.Concurrent.ConcurrentDictionary<Guid, Basics.IResponse>();
            try
            {
                // Try to load the throttle data file, but if it can't be loaded (regardless of reason) just use the default data.
                this.Throttle = ThrottleHandler.LoadThrottleData(this.Configuration);
            }
            catch
            {
                this.Throttle = new ThrottleHandler(this.Configuration);
            }

            this.ThrottleDataSaveTimes = new System.Collections.Concurrent.ConcurrentQueue<DateTime>();
            this.ThrottleDataSaveTimes.Enqueue(DateTime.Now.Add(this.Configuration.ThrottleDataSaveFrequency));
            this.ThreadToSaveThrottleData = new Random().Next(0, this.Configuration.RequestLimit.MaxConcurrentCalls - 1);
            this.ProcessRequestThread = new System.Threading.Thread(() => this.ProcessRequestLoop())
            {
                IsBackground = true,
                Priority = System.Threading.ThreadPriority.Normal
            };
            this.ProcessRequestThread.Start();
        }

        private TSConfiguration Configuration { get; set; }

        private TSCredential Credentials { get; set; }

        private System.Collections.Concurrent.ConcurrentQueue<Basics.IRequest> RequestsToBeMade { get; set; }

        private System.Collections.Concurrent.ConcurrentDictionary<Guid, Basics.IResponse> Responses { get; set; }

        private System.Collections.Concurrent.ConcurrentQueue<DateTime> ThrottleDataSaveTimes { get; set; }

        private int ThreadToSaveThrottleData { get; set; }

        private ThrottleHandler Throttle { get; set; }

        private System.Threading.Thread ProcessRequestThread { get; set; }

        internal Basics.IResponse SendRequest(Basics.IRequest request)
        {
            Basics.IResponse Response = new TSResponse()
            {
                RequestID = request.RequestID
            };
            Task RequestTask = new Task(() =>
            {
                this.RequestsToBeMade.Enqueue(request);
                while (!Responses.ContainsKey(request.RequestID))
                    System.Threading.Thread.Sleep(1);
            });
            RequestTask.Start();
            if (!RequestTask.Wait(this.Configuration.RequestTimeout)) // The request has timed out
                throw new TimeoutException($"Request [{request.RequestID}] targeting [{request.Type}/{request.Target}] has timed out!");
            else if (this.Responses.ContainsKey(request.RequestID) && !this.Responses.TryRemove(request.RequestID, out Response))
                throw new InvalidOperationException($"The response for request [{request.RequestID}] targeting [{request.Type}/{request.Target}] could not be removed from the response dictionary!");
            if (Response.Exception != null)
                throw new InvalidOperationException($"Request [{request.RequestID}] targeting [{request.Type}/{request.Target}] has failed!", Response.Exception);

            return Response;
        }

        private void ProcessRequestLoop()
        {
            Parallel.For(0, this.Configuration.RequestLimit.MaxConcurrentCalls, RequestProcessThread =>
            {
                while (true)
                {
                    try // The throttle data json saving is done in a seperate try-catch statement so that if it fails for whatever reason it will not hinder the processing of requests.
                    {
                        if (RequestProcessThread == this.ThreadToSaveThrottleData && !this.ThrottleDataSaveTimes.IsEmpty && this.ThrottleDataSaveTimes.TryPeek(out DateTime NextSave) && NextSave <= DateTime.Now) // If the current thread is the thread that is supposed to save the throttle json
                        {   // It's time to save the throttle json, add the next save time to the queue, dequeue the current one, save the file, and specify which thread will save the file next.
                            this.ThrottleDataSaveTimes.Enqueue(DateTime.Now.Add(this.Configuration.ThrottleDataSaveFrequency));
                            this.ThrottleDataSaveTimes.TryDequeue(out NextSave);
                            this.Throttle.SaveThrottleData();
                            this.ThreadToSaveThrottleData = new Random().Next(0, this.Configuration.RequestLimit.MaxConcurrentCalls - 1);
                        }
                    }
                    catch
                    {
                        // It's not necessary to handle exceptions for throttling, it's unlikely that multiple exceptions will be thrown in a row.
                    }

                    try
                    {
                        if (!this.RequestsToBeMade.IsEmpty)
                        {
#if DEBUG
                            Console.WriteLine($"[{DateTime.Now.ToLongTimeString()}] [{RequestProcessThread}] There are {this.RequestsToBeMade.Count} request(s) to be made!");
#endif
                            Task ProcessRequestTask = new Task(() =>
                            {
#if DEBUG
                                Console.WriteLine($"[{DateTime.Now.ToLongTimeString()}] [{RequestProcessThread}] Trying to grab request from queue.");
#endif
                                this.RequestsToBeMade.TryDequeue(out Basics.IRequest Request);
                                if (Request != null) // If the request object is null then it wasn't removed, don't do anything and let it try again 
                                {
#if DEBUG
                                    Console.WriteLine($"[{DateTime.Now.ToLongTimeString()}] [{RequestProcessThread}] Successfully retrieved request [{Request.RequestID}] targeting [{Request.Type}/{Request.Target}] processing now!");
#endif
                                    try
                                    {
                                        this.Throttle.ThrottleRequest();
                                        string RequestURL = $"{this.Configuration.EndpointURL}{Request.Target}{((Request.Filters ?? new Basics.IFilter[] { }).Count() > 0 ? $"?{string.Join("&", Request.Filters.Select(Filter => Filter.GetURLEncoded))}" : string.Empty)}";
#if DEBUG
                                        Console.WriteLine($"[{DateTime.Now.ToLongTimeString()}] [{RequestProcessThread}] Sending [{Request.Type}] To [{RequestURL}].");
#endif
                                        HttpClient Client = new HttpClient(new HttpClientHandler());
                                        Client.DefaultRequestHeaders.Add("Authorization", $"Basic {$"{this.Credentials.APIKey}:{this.Credentials.APISecret}".Base64Encode()}");
                                        StringContent Content = string.IsNullOrWhiteSpace(Request.Body) ? null : new StringContent(Request.Body, System.Text.Encoding.Default, TSDefaults.MediaType);
                                        HttpResponseMessage Response = null;
                                        switch (Request.Type)
                                        {
#if TESTING
                                            default:
                                                Console.WriteLine($"[{DateTime.Now.ToLongTimeString()}] [{RequestProcessThread}] URL: [{RequestURL}] Type: [{Request.Type}] Body: [{Request.Body ?? string.Empty}]");
                                                TSResponse TestResponseObject = new TSResponse()
                                                {
                                                    RequestID = Request.RequestID,
                                                    Body = string.Empty,
                                                    Code = 0,
                                                    Exception = null,
                                                    URL = RequestURL
                                                };
                                                Responses.TryAdd(Request.RequestID, TestResponseObject);
                                                break;
#else
                                            case Enums.RequestType.DELETE:
                                                Response = Client.DeleteAsync(RequestURL, Content).Result;
                                                break;
                                            case Enums.RequestType.GET:
                                                Response = Client.GetAsync(RequestURL).Result;
                                                break;
                                            case Enums.RequestType.POST:
                                                Response = Client.PostAsync(RequestURL, Content).Result;
                                                break;
                                            case Enums.RequestType.PUT:
                                                Response = Client.PutAsync(RequestURL, Content).Result;
                                                break;
#endif
                                        }

                                        Responses.TryAdd(
                                            Request.RequestID, 
                                            new TSResponse()
                                            {
                                                RequestID = Request.RequestID,
                                                Body = Response.Content.ReadAsStringAsync().Result,
                                                Code = (int)Response.StatusCode,
                                                Exception = null,
                                                URL = RequestURL
                                            });
                                    }
                                    catch (Exception e)
                                    {
                                        Responses.TryAdd(
                                            Request.RequestID, 
                                            new TSResponse()
                                            {
                                                RequestID = Request.RequestID,
                                                Body = string.Empty,
                                                Code = 0,
                                                Exception = e,
                                                URL = string.Empty
                                            });
                                    }
                                }
                            });
                            ProcessRequestTask.Start();
                            if (!ProcessRequestTask.Wait(this.Configuration.RequestTimeout.Add(this.Configuration.RequestTimeout))) // If it has taken longer than double the timeout to process a single request then exit the task, the request will have already timed out.
                                Console.WriteLine($"[{DateTime.Now.ToLongTimeString()}] [{RequestProcessThread}] It has taken longer than 2x the current timeout timespan to process request, reseting.");
                        }
                    }
                    catch
                    {
                        // TODO Add exception logging 
                    }

                    System.Threading.Thread.Sleep(1 + RequestProcessThread); // By adding + RequestProcessThread the loops will be slightly offset from each other, which should help concurrency problems, and help ensure that a request is not processed twice.
                }
            });
        }
    }
}
