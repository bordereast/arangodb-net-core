using BorderEast.ArangoDB.Client.Database.Meta;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BorderEast.ArangoDB.Client.Models
{
    public class UpdatedDocument<T> : ArangoBaseEntity
    {

        [JsonProperty(PropertyName = "_oldRev", NullValueHandling = NullValueHandling.Ignore)]
        [ArangoField(Field = ArangoField.Id, Name = "_oldRev", NamingType = NamingConvention.UnChanged)]
        public string OldRevision { get; set; }

        [JsonProperty(PropertyName = "new", NullValueHandling = NullValueHandling.Ignore)]
        [ArangoField(Field = ArangoField.Id, Name = "new", NamingType = NamingConvention.UnChanged)]
        public T New { get; set; }
    }
}
