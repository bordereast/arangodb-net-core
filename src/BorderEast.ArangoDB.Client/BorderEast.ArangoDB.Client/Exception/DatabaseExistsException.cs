using System;
using System.Collections.Generic;
using System.Text;

namespace BorderEast.ArangoDB.Client.Exception
{
    public class DatabaseExistsException : System.Exception
    {
        public DatabaseExistsException(string message) : base(message) {

        }
    }
}
