using BorderEast.ArangoDB.Client.Database.Meta;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BorderEast.ArangoDB.Client.Models.Database
{
    public class NewDatabaseUser
    {

        [JsonProperty(PropertyName = "username", NullValueHandling = NullValueHandling.Ignore)]
        [ArangoField(Field = ArangoField.Id, Name = "username", NamingType = NamingConvention.UnChanged)]
        public string Username { get; set; }

        [JsonProperty(PropertyName = "passwd", NullValueHandling = NullValueHandling.Ignore)]
        [ArangoField(Field = ArangoField.Id, Name = "passwd", NamingType = NamingConvention.UnChanged)]
        public string Password { get; set; }

        [JsonProperty(PropertyName = "active", NullValueHandling = NullValueHandling.Ignore)]
        [ArangoField(Field = ArangoField.Id, Name = "active", NamingType = NamingConvention.UnChanged)]
        public bool Active { get; set; }
    }
}
