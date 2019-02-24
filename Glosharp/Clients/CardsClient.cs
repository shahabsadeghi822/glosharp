using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Glosharp.Helpers;
using Glosharp.Http;
using Glosharp.Models.Request;
using Glosharp.Models.Response;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;

namespace Glosharp.Clients
{
    public class CardsClient : ApiClient, ICardsClient
    {
        private readonly IApiConnection _apiConnection;
        
        public CardsClient(IApiConnection apiConnection) : base(apiConnection)
        {
            _apiConnection = apiConnection;
        }
        
        public async Task<IReadOnlyList<Card>> GetAll()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(GloClient.GloApiUrl.ToString());
                client.DefaultRequestHeaders.Authorization = 
                    new AuthenticationHeaderValue("Bearer", _apiConnection.Configuration.Token);

                var options = new ApiOptions();
                var boardResponse = await client.GetAsync(ApiUrls.Boards(options));
                var boardResponseString = await boardResponse.Content.ReadAsStringAsync();

                var boardList = JsonConvert.DeserializeObject<IReadOnlyList<Board>>(boardResponseString);
                var cardsList = new List<Card>();

                foreach (var board in boardList)
                {
                    var cards = await GetAll(board.Id).ConfigureAwait(false);
                    cardsList.AddRange(cards);
                }

                return cardsList;
            }
        }
        
        public async Task<IReadOnlyList<Card>> GetAll(string boardId)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(GloClient.GloApiUrl.ToString());
                client.DefaultRequestHeaders.Authorization = 
                    new AuthenticationHeaderValue("Bearer", _apiConnection.Configuration.Token);

                var options = new ApiOptions();
                var response = await client.GetAsync(ApiUrls.GetCards(options, boardId));

                var responseString = await response.Content.ReadAsStringAsync();

                var cardList = JsonConvert.DeserializeObject<IReadOnlyList<Card>>(responseString);

                return cardList;
            }
        }

        public async Task<IReadOnlyList<Card>> GetAllAssigned(IReadOnlyList<Board> boards, User user)
        {
            var assignedCardList = new List<Card>();

            foreach (var board in boards)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(GloClient.GloApiUrl.ToString());
                    client.DefaultRequestHeaders.Authorization = 
                        new AuthenticationHeaderValue("Bearer", _apiConnection.Configuration.Token);

                    var options = new ApiOptions();
                    var response = await client.GetAsync(ApiUrls.GetCards(options, board.Id));

                    var responseString = await response.Content.ReadAsStringAsync();
                    var cardList = JsonConvert.DeserializeObject<IReadOnlyList<Card>>(responseString);

                    assignedCardList.AddRange(cardList);
                }
            }

            return assignedCardList;
        }


        // First test to test out restsharp.
        public async Task<Card> Create(Card card, string columnId, string boardId)
        {
            var client =  new RestClient(GloClient.GloApiUrl);
            var request = new RestRequest(ApiUrls.CreateCard(boardId));
            request.AddHeader("Bearer", _apiConnection.Configuration.Token);
            request.AddJsonBody(card);
            var returnCard = new Card();
            client.ExecuteAsync<Card>(request, response => { returnCard = response.Data; });
            return returnCard;
        }

    }
}