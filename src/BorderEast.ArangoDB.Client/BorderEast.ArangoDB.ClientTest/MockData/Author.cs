using BorderEast.ArangoDB.Client.Database;
using BorderEast.ArangoDB.Client.Database.Meta;
using BorderEast.ArangoDB.Client.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BorderEast.ArangoDB.ClientTest.MockData
{
    [Collection(HasForeignKey = true)]
    public class Author : ArangoBaseEntity {
        public string Name { get; set; }

        [JsonConverter(typeof(ForeignKeyConverter))]
        public List<Book> Books { get; set; }
    }
}
