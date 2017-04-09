using BorderEast.ArangoDB.Client.Database.Meta;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BorderEast.ArangoDB.Client.Models.User {
    public class ExtraData
    {
        public ExtraData() {
            Queries = new List<UserQuery>();
        }

        [JsonProperty(PropertyName = "name", NullValueHandling = NullValueHandling.Include)]
        [ArangoField(Name = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "queries", NullValueHandling = NullValueHandling.Include)]
        [ArangoField(Name = "queries")]
        public List<UserQuery> Queries { get; set; }
    }
}
