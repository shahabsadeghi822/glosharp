using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Glosharp.Models;

namespace Glosharp.Http
{
    public interface IConnection
    {
        
        /// <summary>
        /// Base address for the connection.
        /// </summary>
        Uri BaseAddress { get; }
        
        /// <summary>
        /// Base configuration for the connection.
        /// </summary>
        Configuration Configuration { get; }
    }
}
