using BorderEast.ArangoDB.Client.Database.Meta;

namespace BorderEast.ArangoDB.Client.Models.User {
    public class AuthorizationData
    {
        [ArangoField(Name = "active")]
        public bool Active { get; set; }

        [ArangoField(Name = "changePassword")]
        public bool ChangePassword { get; set; }
    }
}
