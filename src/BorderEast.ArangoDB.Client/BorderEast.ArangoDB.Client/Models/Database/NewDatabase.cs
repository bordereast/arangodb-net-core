using BorderEast.ArangoDB.Client.Database.Meta;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BorderEast.ArangoDB.Client.Models.Database
{
    public class NewDatabase
    {

        [JsonProperty(PropertyName = "name", NullValueHandling = NullValueHandling.Ignore)]
        [ArangoField(Field = ArangoField.Id, Name = "name", NamingType = NamingConvention.UnChanged)]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "users", NullValueHandling = NullValueHandling.Ignore)]
        [ArangoField(Field = ArangoField.Id, Name = "users", NamingType = NamingConvention.UnChanged)]
        public List<NewDatabaseUser> Users { get; set; }


    }
}
