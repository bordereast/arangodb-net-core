using BorderEast.ArangoDB.Client.Connection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BorderEast.ArangoDB.Client.Database
{
    public class ArangoDatabase
    {
        private DatabaseSettings databaseSettings;
        private IConnection connection;

        public ArangoDatabase(DatabaseSettings databaseSettings, IConnection connection) {
            this.databaseSettings = databaseSettings;
            this.connection = connection;
        }

        public ArangoQuery<T> Query<T>(string query) {
            return new ArangoQuery<T>(query);
        }

        public async Task<T> GetByKeyAsync<T>(string key) {
            Type type = typeof(T);
            Payload payload = new Payload() {
                Content = string.Empty,
                Method = HttpMethod.Get,
                Path = string.Format("/_api/document/{0}/{1}", type.Name, key)
            };
            var result = await connection.GetAsync(payload);
            var json = JsonConvert.DeserializeObject<T>(result.Content);
            return json;
        }

        public T Update<T>(string key, Object item) {
            return (T)(new Object());
        }


    }
}
