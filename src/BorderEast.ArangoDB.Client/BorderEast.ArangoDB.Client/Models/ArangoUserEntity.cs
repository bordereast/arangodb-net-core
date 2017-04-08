using BorderEast.ArangoDB.Client.Database.Meta;
using BorderEast.ArangoDB.Client.Models.User;
using System.Collections.Generic;

namespace BorderEast.ArangoDB.Client.Models {
    public class ArangoUserEntity : ArangoBaseEntity {

        public ArangoUserEntity() {
            ConfigData = new Dictionary<string, string>();
            Databases = new Dictionary<string, string>();
        }

        [ArangoField(Name = "authData")]
        public AuthorizationData AuthData { get; set; }

        [ArangoField(Name = "configData")]
        public Dictionary<string, string> ConfigData { get; set; }

        [ArangoField(Name = "databases")]
        public Dictionary<string, string> Databases { get; set; }

        [ArangoField(Name = "user")]
        public string User { get; set; }

        [ArangoField(Name = "userData")]
        public ExtraData UserData { get; set; }

    }
}
