using BorderEast.ArangoDB.Client.Connection;
using BorderEast.ArangoDB.Client.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BorderEast.ArangoDB.Client.Database
{
    public class ArangoDatabase
    {
        private DatabaseSettings databaseSettings;
        private ConnectionPool<IConnection> connectionPool;

        public ArangoDatabase(DatabaseSettings databaseSettings, ConnectionPool<IConnection> connectionPool) {
            this.databaseSettings = databaseSettings;
            this.connectionPool = connectionPool;
        }

        public ArangoQuery<T> Query<T>(string query) {
            return Query<T>(query, null);
        }

        public ArangoQuery<T> Query<T>(string query, dynamic parameters) {
            Dictionary<string, object> dParams = DynamicUtil.DynamicToDict(parameters);
            return Query<T>(query, dParams);
        }

        private ArangoQuery<T> Query<T>(string query, Dictionary<string, object> parameters) {
            
            return new ArangoQuery<T>(query, parameters, connectionPool, this);
        }

        public async Task<T> GetByKeyAsync<T>(string key) {
            Type type = typeof(T);

            Payload payload = new Payload() {
                Content = string.Empty,
                Method = HttpMethod.Get,
                Path = string.Format("/_api/document/{0}/{1}", type.Name, key)
            };
            
            var result = await GetResultAsync(payload);

            var json = JsonConvert.DeserializeObject<T>(result.Content);
            return json;
        }

        public T Update<T>(string key, Object item) {
            return (T)(new Object());
        }

        internal async Task<Result> GetResultAsync(Payload payload) {
            // Get connection just before we use it
            IConnection connection = connectionPool.GetConnection();
            Result result = await connection.GetAsync(payload);
            // Put connection back immediatly after use
            connectionPool.PutConnection(connection);
            return result;
        }

    }
}
