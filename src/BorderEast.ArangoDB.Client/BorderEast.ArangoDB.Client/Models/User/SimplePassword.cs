using BorderEast.ArangoDB.Client.Database.Meta;

namespace BorderEast.ArangoDB.Client.Models.User {
    public class SimplePassword
    {
        [ArangoField(Name = "hash")]
        public string Hash { get; set; }

        [ArangoField(Name = "method")]
        public string Method { get; set; }

        [ArangoField(Name = "salt")]
        public string Salt { get; set; }
    }
}
