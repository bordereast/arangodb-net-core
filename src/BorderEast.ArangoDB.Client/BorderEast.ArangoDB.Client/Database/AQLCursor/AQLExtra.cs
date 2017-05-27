using BorderEast.ArangoDB.Client.Database.Meta;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BorderEast.ArangoDB.Client.Database.AQLCursor {
    public class AQLExtra {

        [JsonProperty(PropertyName = "stats", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, object> Stats { get; set; }

        [JsonProperty(PropertyName = "warnings", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Warnings { get; set; }
    }
}