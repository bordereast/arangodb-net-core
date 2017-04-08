using BorderEast.ArangoDB.Client.Database.Meta;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BorderEast.ArangoDB.Client.Database.AQLCursor
{
    public class AQLQuery
    {
        public AQLQuery() {
            Parameters = new Dictionary<string, object>();
        }

        [JsonProperty("query")]
        [ArangoField(Name ="query")]
        public string Query { get; set; }

        [JsonProperty(PropertyName = "bindVars", NullValueHandling = NullValueHandling.Ignore)]
        [ArangoField(Name = "bindVars")]
        public Dictionary<string, object> Parameters { get; set; }
    }
}
