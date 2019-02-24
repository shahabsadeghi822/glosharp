using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using Glosharp.Helpers;
using Glosharp.Models;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Glosharp.Http
{
    /// <summary>
    /// A connection for making HTTP request against URI endpoints.
    /// </summary>
    public class Connection : IConnection
    {
        private static readonly Uri DefaultGloApiUrl = GloClient.GloApiUrl;
        private Configuration _configuration { get; set; }
        private HttpClient _httpClient;
        
        /// <inheritdoc />
        /// <summary>
        /// Creates a new connection instance used to make request of the Glo API.
        /// </summary>
        /// <remarks>
        /// This will connect using the default v1 Glo URI.
        /// </remarks>
        public Connection(Configuration configuration) : this(DefaultGloApiUrl, new HttpClient(), configuration)
        {
            
            if (File.Exists("config.json"))
            {
                var json = File.ReadAllText("config.json");
                var configJson = JsonConvert.DeserializeObject<Configuration>(json);
                
                _configuration.Token = configJson.Token;
                _configuration.ClientId = configJson.ClientId;
                _configuration.ClientSecret = configJson.ClientSecret;
                
            }
            else
            {
                var gloToken = Environment.GetEnvironmentVariable("GlosharpPat");
                var gloClientId = Environment.GetEnvironmentVariable("GlosharpClientId");
                var gloSecret = Environment.GetEnvironmentVariable("GlosharpSecret");

                _configuration.Token = gloToken;
                _configuration.ClientId = gloClientId;
                _configuration.ClientSecret = gloSecret;
            }
               
        }
        
        /// <summary>
        /// Create a new connection instance used to make request of the Glo API.
        /// </summary>
        /// <remarks>
        /// You shouldn't really call this unless, for some strange reason, you're not connecting
        /// to the standard Glo URI. You can use this if you are connecting to a self-hosted board.
        /// </remarks>
        /// <param name="baseAddress">
        /// The address to point this client to such as https://gloapi.gitkraken.com/v1/glo/ or the URL
        /// to a Glo self-hosted instance
        /// </param>
        /// <param name="httpClient">
        /// A raw <see cref="HttpClient"/> used to make requests.
        /// </param>
        /// <exception cref="ArgumentException"></exception>
        public Connection(Uri baseAddress, HttpClient httpClient, Configuration configuration)
        {
            Ensure.ArgumentNotNull(baseAddress, nameof(baseAddress));
            Ensure.ArgumentNotNull(httpClient, nameof(httpClient));
            
            if (baseAddress.IsAbsoluteUri == false)
            {
                throw new ArgumentException($"The base address {baseAddress} must be an absolute URI.", 
                    nameof(baseAddress));
            }
            
            
            BaseAddress = baseAddress;
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public Uri BaseAddress { get; }

        public Configuration Configuration => _configuration;
    }
}