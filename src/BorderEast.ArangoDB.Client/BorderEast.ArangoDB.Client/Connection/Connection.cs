using BorderEast.ArangoDB.Client.Database;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BorderEast.ArangoDB.Client.Connection
{
    public interface IConnection
    {
        Task<Result> GetAsync(Payload payload);


    }
}
