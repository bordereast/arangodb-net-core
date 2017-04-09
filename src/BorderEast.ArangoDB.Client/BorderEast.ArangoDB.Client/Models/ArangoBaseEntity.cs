using BorderEast.ArangoDB.Client.Database.Meta;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BorderEast.ArangoDB.Client.Models
{
    public class ArangoBaseEntity {

        [JsonProperty(PropertyName = "_id", NullValueHandling = NullValueHandling.Ignore)]
        [ArangoField(Field = ArangoField.Id, Name = "_id", NamingType = NamingConvention.UnChanged)]
        public string Id { get; internal set; }

        [JsonProperty(PropertyName = "_key", NullValueHandling = NullValueHandling.Ignore)]
        [ArangoField(Field = ArangoField.Key, Name = "_key", NamingType = NamingConvention.UnChanged)]
        public string Key { get; set; }

        [JsonProperty(PropertyName = "_rev", NullValueHandling = NullValueHandling.Ignore)]
        [ArangoField(Field = ArangoField.Revision, Name = "_rev", NamingType = NamingConvention.UnChanged)]
        public string Revision { get; set; }
    }
}
