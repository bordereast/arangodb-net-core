using BorderEast.ArangoDB.Client.Database.Meta;
using BorderEast.ArangoDB.Client.Models.User;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BorderEast.ArangoDB.Client.Models {

    /// <summary>
    /// Represents the ArangoDB User with all known properties. Need to insert new
    /// Arango User via API.
    /// </summary>
    public class ArangoUserEntity : ArangoBaseEntity {

        /// <summary>
        /// Public constructor
        /// </summary>
        public ArangoUserEntity() {
            ConfigData = new Dictionary<string, string>();
            Databases = new Dictionary<string, string>();
        }

        [JsonProperty(PropertyName = "authData", NullValueHandling = NullValueHandling.Include)]
        [ArangoField(Name = "authData")]
        public AuthorizationData AuthData { get; set; }

        [JsonProperty(PropertyName = "configData", NullValueHandling = NullValueHandling.Include)]
        [ArangoField(Name = "configData")]
        public Dictionary<string, string> ConfigData { get; set; }

        [JsonProperty(PropertyName = "databases", NullValueHandling = NullValueHandling.Include)]
        [ArangoField(Name = "databases")]
        public Dictionary<string, string> Databases { get; set; }

        [JsonProperty(PropertyName = "user", NullValueHandling = NullValueHandling.Include)]
        [ArangoField(Name = "user")]
        public string User { get; set; }

        [JsonProperty(PropertyName = "userData", NullValueHandling = NullValueHandling.Include)]
        [ArangoField(Name = "userData")]
        public ExtraData UserData { get; set; }

    }
}
