using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Glosharp.Models;

namespace Glosharp.Http
{
    public interface IApiConnection
    {
        /// <summary>
        /// The underlying connection.
        /// </summary>
        IConnection Connection { get; }
        
        /// <summary>
        /// The underlying configuration.
        /// </summary>
        Configuration Configuration { get; }

    }
}
