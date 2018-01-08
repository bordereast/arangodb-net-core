using BorderEast.ArangoDB.Client.Database.Meta;
using BorderEast.ArangoDB.Client.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BorderEast.ArangoDB.ClientTest.MockData
{
    public class User: ArangoBaseEntity {
        [JsonProperty(PropertyName = "userName", NullValueHandling = NullValueHandling.Ignore)]
        public string Username { get; set; }

        [JsonProperty(PropertyName = "passwd", NullValueHandling = NullValueHandling.Ignore)]
        public string Password { get; set; }


    }
}
