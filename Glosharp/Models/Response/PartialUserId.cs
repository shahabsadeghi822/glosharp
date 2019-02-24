using Newtonsoft.Json;

namespace Glosharp.Models.Response
{
    public class PartialUserId
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
    }
}