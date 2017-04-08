using BorderEast.ArangoDB.Client.Database.Meta;
using System.Collections.Generic;

namespace BorderEast.ArangoDB.Client.Models.User {
    public class UserQuery
    {
        public UserQuery() {
            Parameter = new Dictionary<string, string>();
        }

        [ArangoField(Name = "name")]
        public string Name { get; set; }

        [ArangoField(Name = "parameter")]
        public Dictionary<string, string> Parameter { get; set; }

        [ArangoField(Name = "value")]
        public string Value { get; set; }
    }
}
