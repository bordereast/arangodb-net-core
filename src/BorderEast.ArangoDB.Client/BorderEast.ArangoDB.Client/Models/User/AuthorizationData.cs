using BorderEast.ArangoDB.Client.Database.Meta;
using Newtonsoft.Json;

namespace BorderEast.ArangoDB.Client.Models.User {
    public class AuthorizationData
    {
        [JsonProperty(PropertyName = "active", NullValueHandling = NullValueHandling.Include)]
        [ArangoField(Name = "active")]
        public bool Active { get; set; }

        [JsonProperty(PropertyName = "changePassword", NullValueHandling = NullValueHandling.Include)]
        [ArangoField(Name = "changePassword")]
        public bool ChangePassword { get; set; }
    }
}
