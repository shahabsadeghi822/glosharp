using System;
using System.Collections.Generic;
using System.Net.Http;

namespace Glosharp.Internals
{
    // TODO: DOCUMENT THIS CODE ---->
    public interface IRequest
    {
        object Body { get; set; }
        
        Dictionary<string, string> Headers { get; }
        
        HttpMethod  Method { get; }
        
        Dictionary<string, string> Parameters { get; set; }
        
        Uri BaseAddress { get; }
        
        Uri EndPoint { get; }
        
        TimeSpan Timeout { get; }
        
        string ContentType { get; }
    }
}