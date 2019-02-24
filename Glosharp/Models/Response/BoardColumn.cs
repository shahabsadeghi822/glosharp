using Newtonsoft.Json;

namespace Glosharp.Models.Response
{
    public class BoardColumn
    {
        [JsonProperty(PropertyName = "id")]
        public string Id {get;set;}

        [JsonProperty(PropertyName = "name")]
        public string Name {get;set;}

        [JsonProperty(PropertyName = "archived_date")]
        public string ArchivedDate {get;set;}

        [JsonProperty(PropertyName = "created_date")]
        public string CreatedDate {get;set;}
    }
}