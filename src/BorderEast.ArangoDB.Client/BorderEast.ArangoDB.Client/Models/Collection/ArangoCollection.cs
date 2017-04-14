using BorderEast.ArangoDB.Client.Database.Meta;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace BorderEast.ArangoDB.Client.Models.Collection
{
    public class ArangoCollection
    {


        public static ArangoCollection GetBasicDocumentType(string name) {
            return new ArangoCollection()
            {
                Name = name,
                Type = CollectionType.Document
            };
        }

        public static ArangoCollection GetBasicEdgeType(string name) {
            return new ArangoCollection()
            {
                Name = name,
                Type = CollectionType.Edge
            };
        }
        public static ArangoCollection GetAutoIncrementCollection(string name, CollectionType _type, int incrementBy, int initialOffsetValue, bool allowUserKeys) {
            return new ArangoCollection()
            {
                Name = name,
                Type = _type,
                KeyOptions = new ArangoKeyOptions()
                {
                    Type = "autoincrement",
                    Increment = incrementBy,
                    Offset = initialOffsetValue,
                    AllowUserKeys = allowUserKeys
                }
            };
        }

        public enum CollectionType {
            Document = 2,
            Edge = 3
        }

        public ArangoCollection() {

        }


        [JsonProperty(PropertyName = "name", NullValueHandling = NullValueHandling.Include)]
        [ArangoField(Name = "name")]
        public int JournalSize { get; set; }

        [JsonProperty(PropertyName = "name", NullValueHandling = NullValueHandling.Include)]
        [ArangoField(Name = "name")]
        public int ReplicationFactor { get; set; }

        [JsonProperty(PropertyName = "name", NullValueHandling = NullValueHandling.Include)]
        [ArangoField(Name = "name")]
        public ArangoKeyOptions KeyOptions { get; set; }

        [JsonProperty(PropertyName = "name", NullValueHandling = NullValueHandling.Include)]
        [ArangoField(Name = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "name", NullValueHandling = NullValueHandling.Include)]
        [ArangoField(Name = "name")]
        public bool WaitForSync { get; set; }

        [JsonProperty(PropertyName = "name", NullValueHandling = NullValueHandling.Include)]
        [ArangoField(Name = "name")]
        public bool DoCompact { get; set; }

        [JsonProperty(PropertyName = "name", NullValueHandling = NullValueHandling.Include)]
        [ArangoField(Name = "name")]
        public bool IsVolatile { get; set; }

        [JsonProperty(PropertyName = "name", NullValueHandling = NullValueHandling.Include)]
        [ArangoField(Name = "name")]
        public string[] ShardKeys { get; set; }

        [JsonProperty(PropertyName = "name", NullValueHandling = NullValueHandling.Include)]
        [ArangoField(Name = "name")]
        public int NumberOfShards { get; set; }

        [JsonProperty(PropertyName = "name", NullValueHandling = NullValueHandling.Include)]
        [ArangoField(Name = "name")]
        public bool IsSystem { get; set; }

        [JsonProperty(PropertyName = "name", NullValueHandling = NullValueHandling.Include)]
        [ArangoField(Name = "name")]
        public CollectionType Type { get; set; }

        [JsonProperty(PropertyName = "name", NullValueHandling = NullValueHandling.Include)]
        [ArangoField(Name = "name")]
        public int IndexBuckets { get; set; }

    }
}
