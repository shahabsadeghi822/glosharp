using System;
using Newtonsoft.Json;

namespace Glosharp.Models.Response
{
    /// <summary>
    /// Label Class
    /// </summary>
    /// <remarks>
    /// Inherits the PartialLabel class
    /// </remarks>
    public class Label : PartialLabel
    {
        [JsonProperty(PropertyName = "color")]
        public LabelColor Color {get;set;}

        [JsonProperty(PropertyName = "created_date")]
        public DateTime CreatedDate {get;set;}

        [JsonProperty(PropertyName = "created_by")]
        public PartialUser CreatedBy {get;set;}
    }
}