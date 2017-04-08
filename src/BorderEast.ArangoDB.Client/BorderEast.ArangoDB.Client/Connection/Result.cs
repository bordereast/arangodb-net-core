using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace BorderEast.ArangoDB.Client.Connection
{
    public class Result
    {
        public string Content { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
}
