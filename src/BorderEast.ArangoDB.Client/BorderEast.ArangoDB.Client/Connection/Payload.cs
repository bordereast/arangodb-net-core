using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace BorderEast.ArangoDB.Client.Connection
{
    public class Payload
    {
        public string Content { get; set; }

        public HttpMethod Method { get; set; }

        public string Path { get; set; }
    }
}
