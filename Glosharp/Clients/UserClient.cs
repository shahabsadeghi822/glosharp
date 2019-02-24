using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Glosharp.Helpers;
using Glosharp.Http;
using Glosharp.Models.Response;
using Newtonsoft.Json;

namespace Glosharp.Clients
{
    public class UserClient : ApiClient, IUserClient
    {
        private readonly IApiConnection _apiConnection;
        
        public UserClient(IApiConnection apiConnection) : base(apiConnection)
        {
            _apiConnection = apiConnection;
        }

        public async Task<User> GetAllForCurrent()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(GloClient.GloApiUrl.ToString());
                client.DefaultRequestHeaders.Authorization = 
                    new AuthenticationHeaderValue("Bearer", _apiConnection.Configuration.Token);

                var response = await client.GetAsync(ApiUrls.User());
                response.EnsureSuccessStatusCode();

                var responseString = await response.Content.ReadAsStringAsync();
                var user = JsonConvert.DeserializeObject<User>(responseString);
                return user;
            }
        }

        public async Task<PartialUser> GetPartialForCurrent()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(GloClient.GloApiUrl.ToString());
                client.DefaultRequestHeaders.Authorization = 
                    new AuthenticationHeaderValue("Bearer", _apiConnection.Configuration.Token);

                var response = await client.GetAsync(ApiUrls.PartialUser());
                response.EnsureSuccessStatusCode();

                var responseString = await response.Content.ReadAsStringAsync();
                var user = JsonConvert.DeserializeObject<PartialUser>(responseString);
                return user;
            }
        }

        public async Task<PartialUserId> GetPartialIdForCurrent()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(GloClient.GloApiUrl.ToString());
                client.DefaultRequestHeaders.Authorization = 
                    new AuthenticationHeaderValue("Bearer", _apiConnection.Configuration.Token);

                var response = await client.GetAsync(ApiUrls.PartialUser());
                response.EnsureSuccessStatusCode();

                var responseString = await response.Content.ReadAsStringAsync();
                var user = JsonConvert.DeserializeObject<PartialUserId>(responseString);
                return user;
            }
        }
    }
}