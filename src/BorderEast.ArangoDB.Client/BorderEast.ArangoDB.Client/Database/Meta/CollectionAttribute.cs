using System;
using System.Collections.Generic;
using System.Text;

namespace BorderEast.ArangoDB.Client.Database.Meta
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class CollectionAttribute : Attribute, ICollectionAttribute {

        public Boolean HasForeignKey { get; set; }
    }
}
