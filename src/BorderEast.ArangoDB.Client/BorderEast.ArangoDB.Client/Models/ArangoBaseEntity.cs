using BorderEast.ArangoDB.Client.Database.Meta;
using System;
using System.Collections.Generic;
using System.Text;

namespace BorderEast.ArangoDB.Client.Models
{
    public class ArangoBaseEntity
    {
        [ArangoField(Field = ArangoField.Id, Name = "_id", NamingType = NamingConvention.UnChanged)]
        public string Id { get; internal set; }

        [ArangoField(Field = ArangoField.Key, Name = "_key", NamingType = NamingConvention.UnChanged)]
        public string Key { get; set; }

        [ArangoField(Field = ArangoField.Revision, Name = "_rev", NamingType = NamingConvention.UnChanged)]
        public string Revision { get; set; }
    }
}
