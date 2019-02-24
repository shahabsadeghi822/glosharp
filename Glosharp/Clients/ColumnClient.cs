using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Glosharp.Helpers;
using Glosharp.Http;
using Glosharp.Models.Response;
using Newtonsoft.Json;
using RestSharp;

namespace Glosharp.Clients
{
    public class ColumnClient : ApiClient, IColumnClient
    {
        private readonly IApiConnection _apiConnection;
        
        public ColumnClient(IApiConnection apiConnection) : base(apiConnection)
        {
            _apiConnection = apiConnection;
        }
        
        public async Task<Tuple<HttpStatusCode, string, List<Column>>> GetColumns(string boardId)
        {
            var client = new RestClient(GloClient.GloApiUrl);
            var request = new RestRequest(ApiUrls.GetColumns(boardId));

            request.AddHeader("Authorization", $"Bearer {_apiConnection.Configuration.Token}");
            var response = client.Get<List<Column>>(request);
            
            return new Tuple<HttpStatusCode, string, List<Column>>(response.StatusCode, response.StatusDescription,
                response.Data);
        }

        public async Task<Tuple<HttpStatusCode, string, Column>> Create(string boardId, Column column)
        {
            var client = new RestClient(GloClient.GloApiUrl);
            var request = new RestRequest(ApiUrls.CreateColumns(boardId));
            var json = JsonConvert.SerializeObject(column);
            
            // Add headers
            request.AddHeader("Authorization", $"Bearer {_apiConnection.Configuration.Token}");
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(json);

            // Make the call and return response
            var response = client.Post<Column>(request);
            return new Tuple<HttpStatusCode, string, Column>(response.StatusCode, response.StatusDescription,
                response.Data);
        }

        public async Task<Column> Update(string boardId, Column column)
        {
            var client = new RestClient(GloClient.GloApiUrl);
            var json = JsonConvert.SerializeObject(column);
            var request = new RestRequest(ApiUrls.UpdateColumn(boardId, column.Id));
            request.AddHeader("Authorization", $"Bearer {_apiConnection.Configuration.Token}");
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(json);

            var response = client.Post<Column>(request);

            return response.Data;

        }

        public async Task<HttpStatusCode> Delete(string boardId, string columnId)
        {
            var client = new RestClient(GloClient.GloApiUrl);
            var request = new RestRequest(ApiUrls.DeleteColumn(boardId, columnId));
            request.AddHeader("Authorization", $"Bearer {_apiConnection.Configuration.Token}");
            var response = client.Delete(request);

            return response.StatusCode;
        }
    }
}