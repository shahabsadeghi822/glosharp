using System;
using System.Net.Http.Headers;
using Glosharp.Clients;
using Glosharp.Helpers;
using Glosharp.Http;
using Glosharp.Models.Response;

namespace Glosharp
{
    public class GloClient : IGloClient
    {
        public static readonly Uri GloApiUrl = new Uri("https://gloapi.gitkraken.com/v1/glo/");
        public IConnection Connection { get; }
        public IBoardsClient Board { get; }
        public IUserClient User { get; }
        
        public ICardsClient Card { get; }
        
        public IColumnClient Column { get; }

        
        /// <summary>
        /// Create a new instance of the Glo API v1 client using the specified connection.
        /// </summary>
        /// <param name="connection"></param>
        public GloClient(IConnection connection)
        {
            Ensure.ArgumentNotNull(connection, nameof(connection));

            Connection = connection;
            var apiConnection = new ApiConnection(connection);
            Board = new BoardsClient(apiConnection);
            User = new UserClient(apiConnection);
            Card = new CardsClient(apiConnection);
            Column = new ColumnClient(apiConnection);
            
        }

        /// <summary>
        /// Base address to call.
        /// </summary>
        /// <remarks>
        /// Example: https://gloapi.gitkraken.com/v1/glo/
        /// </remarks>
        public Uri BaseAddress => Connection.BaseAddress;
    }
}