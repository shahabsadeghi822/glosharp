using Newtonsoft.Json;

namespace Glosharp.Models
{
    /// <summary>
    /// Configuration
    /// </summary>
    public class Configuration
    {
        /// <summary>
        /// Personal Access Token
        /// </summary>
        /// <value></value>
        [JsonProperty(PropertyName = "token")]
        public string Token { get; set; }
        
        /// <summary>
        /// Client Secret
        /// </summary>
        [JsonProperty(PropertyName = "client_secret")]
        public string ClientSecret { get; set; }
        
        /// <summary>
        /// Client Id
        /// </summary>
        [JsonProperty(PropertyName = "client_id")]
        public string ClientId { get; set; }
    }
}