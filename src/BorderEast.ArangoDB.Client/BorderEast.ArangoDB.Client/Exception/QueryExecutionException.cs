using System;
using System.Collections.Generic;
using System.Text;

namespace BorderEast.ArangoDB.Client.Exception
{
    public class QueryExecutionException : System.Exception
    {
        public QueryExecutionException(string message) : base(message)
        {

        }
    }
}
