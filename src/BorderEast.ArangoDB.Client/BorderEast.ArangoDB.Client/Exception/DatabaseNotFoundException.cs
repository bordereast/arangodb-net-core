using System;
using System.Collections.Generic;
using System.Text;


namespace BorderEast.ArangoDB.Client.Exception
{
    public class DatabaseNotFoundException : System.Exception
    {
        public DatabaseNotFoundException(string message) :base(message) {

        }
    }
}
