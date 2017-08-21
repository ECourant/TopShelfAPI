using Newtonsoft.Json;

namespace TopShelfAPI.Network
{
    internal sealed class TopShelfException
    {
        internal TopShelfException()
        {
        }

        [JsonProperty("Message")]
        internal string Message { get; set; }

        [JsonProperty("MessageDetail")]
        internal string MessageDetail { get; set; }
    }
}
