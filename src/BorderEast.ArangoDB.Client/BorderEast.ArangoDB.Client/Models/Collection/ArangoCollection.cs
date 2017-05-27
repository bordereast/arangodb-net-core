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
            JournalSize = 1048576;
            ReplicationFactor = 1;
            KeyOptions = new ArangoKeyOptions
            {
                AllowUserKeys = true,
                Type = "traditional"
            };
            WaitForSync = false;
            DoCompact = true;
            IsVolatile = false;
            ShardKeys = new[] { "_key" };
            NumberOfShards = 1;
            Type = CollectionType.Document;
            IndexBuckets = 16;

        }


        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int JournalSize { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int ReplicationFactor { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public ArangoKeyOptions KeyOptions { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool WaitForSync { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool DoCompact { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool IsVolatile { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string[] ShardKeys { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int NumberOfShards { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool IsSystem { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public CollectionType Type { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int IndexBuckets { get; set; }

    }
}
