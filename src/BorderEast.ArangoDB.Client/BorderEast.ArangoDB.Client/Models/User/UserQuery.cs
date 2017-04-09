using BorderEast.ArangoDB.Client.Database.Meta;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BorderEast.ArangoDB.Client.Models.User {
    public class UserQuery
    {
        public UserQuery() {
            Parameter = new Dictionary<string, string>();
        }

        [JsonProperty(PropertyName = "name", NullValueHandling = NullValueHandling.Include)]
        [ArangoField(Name = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "parameter", NullValueHandling = NullValueHandling.Include)]
        [ArangoField(Name = "parameter")]
        public Dictionary<string, string> Parameter { get; set; }

        [JsonProperty(PropertyName = "value", NullValueHandling = NullValueHandling.Include)]
        [ArangoField(Name = "value")]
        public string Value { get; set; }
    }
}
