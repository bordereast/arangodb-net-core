using BorderEast.ArangoDB.Client.Database.Meta;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BorderEast.ArangoDB.Client.Models.Collection
{
    public class CollectionResult
    {
        [JsonProperty(PropertyName = "id", NullValueHandling = NullValueHandling.Include)]
        [ArangoField(Name = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "name", NullValueHandling = NullValueHandling.Include)]
        [ArangoField(Name = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "waitForSync", NullValueHandling = NullValueHandling.Include)]
        [ArangoField(Name = "waitForSync")]
        public bool WaitForSync { get; set; }

        [JsonProperty(PropertyName = "isVolatile", NullValueHandling = NullValueHandling.Include)]
        [ArangoField(Name = "isVolatile")]
        public bool IsVolatile { get; set; }

        [JsonProperty(PropertyName = "isSystem", NullValueHandling = NullValueHandling.Include)]
        [ArangoField(Name = "isSystem")]
        public bool IsSystem { get; set; }

        [JsonProperty(PropertyName = "status", NullValueHandling = NullValueHandling.Include)]
        [ArangoField(Name = "status")]
        public int Status { get; set; }

        [JsonProperty(PropertyName = "type", NullValueHandling = NullValueHandling.Include)]
        [ArangoField(Name = "type")]
        public ArangoCollection.CollectionType Type { get; set; }

        [JsonProperty(PropertyName = "error", NullValueHandling = NullValueHandling.Include)]
        [ArangoField(Name = "error")]
        public bool Error { get; set; }

        [JsonProperty(PropertyName = "code", NullValueHandling = NullValueHandling.Include)]
        [ArangoField(Name = "code")]
        public int StatusCode { get; set; }
    }
}
