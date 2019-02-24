using Newtonsoft.Json;

namespace Glosharp.Models.Response
{
    public class BoardMember
    {
        [JsonProperty(PropertyName = "id")]
        public string Id {get;set;}

        [JsonProperty(PropertyName = "role")]
        public string Role {get;set;}

        [JsonProperty(PropertyName = "username")]
        public string Username {get;set;}
    }
}