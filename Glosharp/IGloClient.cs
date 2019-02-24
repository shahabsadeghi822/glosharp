using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Glosharp.Clients;
using Glosharp.Http;

namespace Glosharp
{
    public interface IGloClient
    {
        /// <summary>
        /// Provides a client connection to make rest requests to HTTP endpoints.
        /// </summary>
        IConnection Connection { get; }

        // TODO update the link 
        /// <summary>
        /// Access GitHub's Issue API.
        /// </summary>
        /// <remarks>
        /// Refer to the API documentation for more information: https://developer.github.com/v3/issues/
        /// </remarks>
        IBoardsClient Board { get; }
        
        // TODO: Better documentation :P
        /// <summary>
        /// Access User properties
        /// </summary>
        IUserClient User { get; }
    }
}
