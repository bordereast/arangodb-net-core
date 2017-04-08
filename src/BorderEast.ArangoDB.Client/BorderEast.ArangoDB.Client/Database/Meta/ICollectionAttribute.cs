using System;
using System.Collections.Generic;
using System.Text;

namespace BorderEast.ArangoDB.Client.Database.Meta
{
    public interface ICollectionAttribute
    {
        string Name { get; set; }

        NamingConvention NamingType { get; set; }
    }
}
