using System;
using System.Collections.Generic;
using System.Text;

namespace BorderEast.ArangoDB.Client.Database.Meta
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class ArangoFieldAttribute : Attribute, IArangoFieldAttribute {

        public string Name { get; set; }

        public bool SerializeIgnore { get; set; }

        public string ForeignKeyTo { get; set; }

        public NamingConvention NamingType { get; set; }

        public ArangoField Field { get; set; }
    }
}
