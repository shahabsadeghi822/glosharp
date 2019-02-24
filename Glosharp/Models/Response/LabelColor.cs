using Newtonsoft.Json;

namespace Glosharp.Models.Response
{
    public class LabelColor
    {
        [JsonProperty(PropertyName = "r")]
        public string R {get;set;}

        [JsonProperty(PropertyName = "g")]
        public string G {get;set;}

        [JsonProperty(PropertyName = "b")]
        public string B {get;set;}

        [JsonProperty(PropertyName = "a")]
        public string A {get;set;}
    }
}