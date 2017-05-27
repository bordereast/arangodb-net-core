using BorderEast.ArangoDB.Client.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BorderEast.ArangoDB.ClientTest.MockData
{
    public class Book : ArangoBaseEntity
    {
        public string Name { get; set; }
    }
}
