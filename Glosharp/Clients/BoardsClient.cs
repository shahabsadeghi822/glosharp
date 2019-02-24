using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Glosharp.Helpers;
using Glosharp.Http;
using Glosharp.Models.Request;
using Glosharp.Models.Response;
using Newtonsoft.Json;

namespace Glosharp.Clients
{
    public class BoardsClient: ApiClient, IBoardsClient
    {
        private readonly IApiConnection _apiConnection;
        
        public BoardsClient(IApiConnection apiConnection) : base(apiConnection)
        {
            _apiConnection = apiConnection;
        }
        
        /// <summary>
        /// Gets all boards for the current user with default API options.
        /// </summary>
        /// <returns><list type="Board"></list></returns>
        public async Task<IReadOnlyList<Board>> GetAllForCurrent()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(GloClient.GloApiUrl.ToString());
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", _apiConnection.Configuration.Token);
                
                var options = new ApiOptions();
                var response = await client.GetAsync(ApiUrls.Boards(options));
                response.EnsureSuccessStatusCode();
                
                var responseString = await response.Content.ReadAsStringAsync();
                var boardList = JsonConvert.DeserializeObject<IReadOnlyList<Board>>(responseString);

                return boardList;
            }
        }
        
        /// <inheritdoc />
        /// <summary>
        /// Gets all boards for the current user with custom API options.
        /// </summary>
        /// <param name="options">
        /// A set of <see cref="T:Glosharp.Models.Request.ApiOptions" />
        /// </param>
        /// <returns><list type="Board"></list></returns>
        public async Task<IReadOnlyList<Board>> GetAllForCurrent(ApiOptions options)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(GloClient.GloApiUrl.ToString());
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", _apiConnection.Configuration.Token);
                
                var response = await client.GetAsync(ApiUrls.Boards(options));
                response.EnsureSuccessStatusCode();
                
                var responseString = await response.Content.ReadAsStringAsync();
                var boardList = JsonConvert.DeserializeObject<IReadOnlyList<Board>>(responseString);

                return boardList;
            }
        }

        public async Task<Board> GetAllForSingle(string boardId)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(GloClient.GloApiUrl.ToString());
                client.DefaultRequestHeaders.Authorization = 
                    new AuthenticationHeaderValue("Bearer", _apiConnection.Configuration.Token);
                var options = new ApiOptions();
                var response = await client.GetAsync(ApiUrls.Board(options, boardId));
                response.EnsureSuccessStatusCode();

                var responseString = await response.Content.ReadAsStringAsync();
                var board = JsonConvert.DeserializeObject<Board>(responseString);

                return board;
            }
        }

        public async Task<Board> GetAllForSingle(ApiOptions options, string boardId)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(GloClient.GloApiUrl.ToString());
                client.DefaultRequestHeaders.Authorization = 
                    new AuthenticationHeaderValue("Bearer", _apiConnection.Configuration.Token);
                
                var response = await client.GetAsync(ApiUrls.Board(options, boardId));
                response.EnsureSuccessStatusCode();

                var responseString = await response.Content.ReadAsStringAsync();
                var board = JsonConvert.DeserializeObject<Board>(responseString);

                return board;
            }
        }
    }
}
