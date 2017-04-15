using BorderEast.ArangoDB.Client.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTestApp
{
    public class Role : ArangoBaseEntity {

        [JsonProperty(PropertyName = "name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "permission", NullValueHandling = NullValueHandling.Ignore)]
        public string Permission { get; set; }
    }
}
