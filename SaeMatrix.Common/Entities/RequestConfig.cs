using Newtonsoft.Json;

namespace SaeMatrix.Common.Entities
{
    public class RequestConfig
    {
        public RequestConfig()
        {
            Body = new Dictionary<string, string>();
            Headers = new Dictionary<string, string>();
            QueryParams = new Dictionary<string, string>();
        }

        [JsonProperty("url")]
        public string URL { get; set; }
        [JsonProperty("queryParams")]
        public Dictionary<string, string> QueryParams { get; set; }
        [JsonProperty("headers")]
        public Dictionary<string, string> Headers { get; set; }
        [JsonProperty("body")]
        public Dictionary<string, string> Body { get; set; }

        [JsonProperty("BaseAddress")]
        public string BaseAddress { get; set; }
    }
}

