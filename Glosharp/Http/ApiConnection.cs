using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Glosharp.Helpers;
using Glosharp.Models;
using Glosharp.Models.Request;

namespace Glosharp.Http
{
    public class ApiConnection: IApiConnection
    {
        
        public IConnection Connection { get; }
        public Configuration Configuration { get; }

        public ApiConnection(IConnection connection)
        {
            Connection = connection;
            Configuration = connection.Configuration;
        }
    }
}
