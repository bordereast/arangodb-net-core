using BorderEast.ArangoDB.Client.Database.Meta;
using Newtonsoft.Json;

namespace BorderEast.ArangoDB.Client.Models.User {
    public class SimplePassword {

        [JsonProperty(PropertyName = "hash", NullValueHandling = NullValueHandling.Include)]
        [ArangoField(Name = "hash")]
        public string Hash { get; set; }

        [JsonProperty(PropertyName = "method", NullValueHandling = NullValueHandling.Include)]
        [ArangoField(Name = "method")]
        public string Method { get; set; }

        [JsonProperty(PropertyName = "salt", NullValueHandling = NullValueHandling.Include)]
        [ArangoField(Name = "salt")]
        public string Salt { get; set; }
    }
}
