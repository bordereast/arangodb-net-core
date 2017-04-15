using BorderEast.ArangoDB.Client.Database;
using BorderEast.ArangoDB.Client.Database.Meta;
using BorderEast.ArangoDB.Client.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTestApp
{
    [Collection(HasForeignKey = true)]
    public class User : ArangoBaseEntity
    {
        [JsonProperty(PropertyName = "userName", NullValueHandling = NullValueHandling.Ignore)]
        public string Username { get; set; }

        [JsonProperty(PropertyName = "passwd", NullValueHandling = NullValueHandling.Ignore)]
        public string Password { get; set; }

        [ArangoField(ForeignKeyTo = "Role")]
        [JsonConverter(typeof(ForeignKeyConverter))]
        public List<Role> Roles { get; set; }
        
    }
}
