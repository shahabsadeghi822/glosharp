using System;
using System.Collections.Generic;
using System.Net.Http;

namespace Glosharp.Internals
{
    public class Request : IRequest
    {
        public Request()
        {
            Headers = new Dictionary<string, string>();
            Parameters = new Dictionary<string, string>();
            Timeout = TimeSpan.FromSeconds(90);
        }
        
        public object Body { get; set; }
        
        public Dictionary<string, string> Headers { get; }
        
        public HttpMethod Method { get; set; }
        
        public Dictionary<string, string> Parameters { get; set; }
        
        public Uri BaseAddress { get; set; }
        
        public Uri EndPoint { get; set; }
        
        public TimeSpan Timeout { get; set; }
        
        public string ContentType { get; set; }
    }
}