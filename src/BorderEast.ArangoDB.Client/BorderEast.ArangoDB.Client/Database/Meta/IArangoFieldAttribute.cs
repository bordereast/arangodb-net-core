using System;
using System.Collections.Generic;
using System.Text;

namespace BorderEast.ArangoDB.Client.Database.Meta
{
    public interface IArangoFieldAttribute
    {
        string Name { get; set; }

        bool SerializeIgnore { get; set; }

        string ForeignKeyTo { get; set; }

        NamingConvention NamingType { get; set; }

        ArangoField Field { get; set; }
    }

    public enum ArangoField {
        None = 0,
        Id = 1,
        Key = 2,
        Handle = 3,
        Revision = 4,
        EdgeFrom = 5,
        EdgeTo = 6
    }

    public enum NamingConvention {
        UnChanged = 0,
        ToCamelCase = 1
    }
}
