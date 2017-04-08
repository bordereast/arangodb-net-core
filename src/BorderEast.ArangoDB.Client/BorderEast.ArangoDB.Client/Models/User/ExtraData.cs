using BorderEast.ArangoDB.Client.Database.Meta;
using System.Collections.Generic;

namespace BorderEast.ArangoDB.Client.Models.User {
    public class ExtraData
    {
        public ExtraData() {
            Queries = new List<UserQuery>();
        }

        [ArangoField(Name = "name")]
        public string Name { get; set; }

        [ArangoField(Name = "queries")]
        public List<UserQuery> Queries { get; set; }
    }
}
