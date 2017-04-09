using BorderEast.ArangoDB.Client.Database.Meta;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BorderEast.ArangoDB.ClientTest.MockData
{
    public class User {
        [JsonProperty(PropertyName = "userName", NullValueHandling = NullValueHandling.Ignore)]
        [ArangoField(Field = ArangoField.Id, Name = "userName", NamingType = NamingConvention.UnChanged)]
        public string Username { get; set; }

        [JsonProperty(PropertyName = "passwd", NullValueHandling = NullValueHandling.Ignore)]
        [ArangoField(Field = ArangoField.Id, Name = "passwd", NamingType = NamingConvention.UnChanged)]
        public string Password { get; set; }


    }
}
