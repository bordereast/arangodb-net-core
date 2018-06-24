using BorderEast.ArangoDB.Client.Database.Meta;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BorderEast.ArangoDB.Client.Models.Database
{
    public class DatabaseResult
    {

        [JsonProperty(PropertyName = "error", NullValueHandling = NullValueHandling.Ignore)]
        [ArangoField(Field = ArangoField.Id, Name = "error", NamingType = NamingConvention.UnChanged)]
        public bool Error { get; set; }

        [JsonProperty(PropertyName = "code", NullValueHandling = NullValueHandling.Ignore)]
        [ArangoField(Field = ArangoField.Id, Name = "code", NamingType = NamingConvention.UnChanged)]
        public int Code { get; set; }

        [JsonProperty(PropertyName = "result", NullValueHandling = NullValueHandling.Ignore)]
        [ArangoField(Field = ArangoField.Id, Name = "result", NamingType = NamingConvention.UnChanged)]
        public bool Result { get; set; }
    }
}
