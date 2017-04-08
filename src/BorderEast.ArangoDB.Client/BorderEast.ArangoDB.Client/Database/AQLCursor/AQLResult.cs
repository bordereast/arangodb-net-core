using BorderEast.ArangoDB.Client.Database.Meta;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BorderEast.ArangoDB.Client.Database.AQLCursor {
    public class AQLResult<T> {

        [JsonProperty(PropertyName = "result", NullValueHandling = NullValueHandling.Ignore)]
        [ArangoField(Name = "result")]
        public List<T> Result { get; set; }

        [JsonProperty(PropertyName = "hasMore", NullValueHandling = NullValueHandling.Ignore)]
        [ArangoField(Name = "hasMore")]
        public bool HasMore { get; set; }

        [JsonProperty(PropertyName = "extra", NullValueHandling = NullValueHandling.Ignore)]
        [ArangoField(Name = "extra")]
        public AQLExtra Extra { get; set; }

        [JsonProperty(PropertyName = "error", NullValueHandling = NullValueHandling.Ignore)]
        [ArangoField(Name = "error")]
        public bool Error { get; set; }

        [JsonProperty(PropertyName = "code", NullValueHandling = NullValueHandling.Ignore)]
        [ArangoField(Name = "code")]
        public int Code { get; set; }

        [JsonProperty(PropertyName = "errorNum", NullValueHandling = NullValueHandling.Ignore)]
        [ArangoField(Name = "errorNum")]
        public int ErrorNumber { get; set; }

        [JsonProperty(PropertyName = "errorMessage", NullValueHandling = NullValueHandling.Ignore)]
        [ArangoField(Name = "errorMessage")]
        public string ErrorMessage { get; set; }
    }
}
