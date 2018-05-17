using System;
using System.Collections.Generic;
using System.Text;

namespace BorderEast.ArangoDB.Client.Exception
{
    public class QueryExecutionException : System.Exception
    {
        public int ErrorNumber { get; private set; }
        public QueryExecutionException(string message, int errorNum) : base(message)
        {
            ErrorNumber = errorNum;
        }
    }
}
