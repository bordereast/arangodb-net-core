using System;
using System.Collections.Generic;
using System.Text;

namespace BorderEast.ArangoDB.Client.Database.Meta
{
    internal class ForeignKey
    {
        internal bool IsForeignKey { get; set; }
        internal List<KeyValuePair<string,Type>> ForeignKeyTypes { get; set; }
        
    }
}
