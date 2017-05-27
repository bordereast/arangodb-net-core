using BorderEast.ArangoDB.Client.Database.Meta;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BorderEast.ArangoDB.Client.Database.AQLCursor {
    public class AQLResult<T> {

        [JsonProperty(PropertyName = "id", NullValueHandling = NullValueHandling.Ignore)]
        public string CursorId { get; set; }

        [JsonProperty(PropertyName = "result", NullValueHandling = NullValueHandling.Ignore)]
        public List<T> Result { get; set; }

        [JsonProperty(PropertyName = "hasMore", NullValueHandling = NullValueHandling.Ignore)]
        public bool HasMore { get; set; }

        [JsonProperty(PropertyName = "extra", NullValueHandling = NullValueHandling.Ignore)]
        public AQLExtra Extra { get; set; }

        [JsonProperty(PropertyName = "error", NullValueHandling = NullValueHandling.Ignore)]
        public bool Error { get; set; }

        [JsonProperty(PropertyName = "code", NullValueHandling = NullValueHandling.Ignore)]
        public int Code { get; set; }

        [JsonProperty(PropertyName = "errorNum", NullValueHandling = NullValueHandling.Ignore)]
        public int ErrorNumber { get; set; }

        [JsonProperty(PropertyName = "errorMessage", NullValueHandling = NullValueHandling.Ignore)]
        public string ErrorMessage { get; set; }

        [JsonProperty(PropertyName = "cached", NullValueHandling = NullValueHandling.Ignore)]
        public bool Cached { get; set; }
    }
}
