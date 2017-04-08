using System;
using System.Collections.Generic;
using System.Text;

namespace BorderEast.ArangoDB.Client.Database
{

    public class ArangoQuery<T>
    {
        private string query;

        public ArangoQuery(string query) {

        }

        public List<T> ToList() {
            return new List<T>();
        }


    }  
}
