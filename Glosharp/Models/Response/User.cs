using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Glosharp.Models.Response
{
    /// <summary>
    /// User class
    /// </summary>
    /// <remarks>
    /// Inherits the PartialUser class
    /// </remarks>
    public class User
    {
        
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "username")]
        public string Username { get; set; }
        
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }
        
        [JsonProperty(PropertyName = "created_date")]
        public string CreatedDate { get; set; }

    }
}