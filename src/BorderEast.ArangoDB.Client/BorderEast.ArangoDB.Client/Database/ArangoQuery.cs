using BorderEast.ArangoDB.Client.Connection;
using BorderEast.ArangoDB.Client.Database.AQLCursor;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace BorderEast.ArangoDB.Client.Database
{

    public class ArangoQuery<T>
    {
        private AQLQuery query;
        private ConnectionPool<IConnection> connectionPool;
        private ArangoDatabase database;

        public ArangoQuery(string queryStr, ConnectionPool<IConnection> connectionPool, ArangoDatabase database) {
            this.connectionPool = connectionPool;
            this.database = database;
            query = new AQLQuery()
            {
                Query = queryStr
            };
        }

        public ArangoQuery(string queryStr, Dictionary<string, object> parameters, 
            ConnectionPool<IConnection> connectionPool, ArangoDatabase database) 
        {
            this.connectionPool = connectionPool;
            this.database = database;
            query = new AQLQuery()
            {
                Query = queryStr,
                Parameters = parameters
            };
        }

        public ArangoQuery<T> WithParameters(Dictionary<string, object> parameters) {
            this.query.Parameters = parameters;
            return this;
        }

        public async Task<List<T>> ToList() {
            
            Payload payload = new Payload()
            {
                Content = JsonConvert.SerializeObject(query),
                Method = HttpMethod.Post,
                Path = "_api/cursor"
            };

            if (database.databaseSettings.IsDebug) {
                payload.Path += "?query=" + Convert.ToBase64String(Encoding.UTF8.GetBytes(query.Query));
            }

            var result = await database.GetResultAsync(payload);
            if (result == null) {
                return null;
            }

            var json = JsonConvert.DeserializeObject<AQLResult<T>>(result.Content);
            return json.Result;
        }


    }  
}
