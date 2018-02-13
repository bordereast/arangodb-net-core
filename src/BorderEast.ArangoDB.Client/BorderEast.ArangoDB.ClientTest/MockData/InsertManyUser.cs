using BorderEast.ArangoDB.Client.Models;
using Newtonsoft.Json;

namespace BorderEast.ArangoDB.ClientTest.MockData
{
    public class InsertManyUser: ArangoBaseEntity {
        [JsonProperty(PropertyName = "userName", NullValueHandling = NullValueHandling.Ignore)]
        public string Username { get; set; }

        [JsonProperty(PropertyName = "passwd", NullValueHandling = NullValueHandling.Ignore)]
        public string Password { get; set; }
    }
}
