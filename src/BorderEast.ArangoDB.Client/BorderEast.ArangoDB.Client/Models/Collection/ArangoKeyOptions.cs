using System;
using System.Collections.Generic;
using System.Text;

namespace BorderEast.ArangoDB.Client.Models.Collection
{
    public class ArangoKeyOptions
    {
        public bool AllowUserKeys { get; set; }
        public string Type { get; set; }
        public int Increment { get; set; }
        public int Offset { get; set; }
    }
}
