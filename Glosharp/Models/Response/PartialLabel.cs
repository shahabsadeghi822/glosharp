using Newtonsoft.Json;

namespace Glosharp.Models.Response
{
    public class PartialLabel
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }
}
