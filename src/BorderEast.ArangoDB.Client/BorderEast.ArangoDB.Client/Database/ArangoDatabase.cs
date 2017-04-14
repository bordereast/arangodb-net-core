using BorderEast.ArangoDB.Client.Connection;
using BorderEast.ArangoDB.Client.Models;
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
        internal ClientSettings databaseSettings;
        private ConnectionPool<IConnection> connectionPool;

        public ArangoDatabase(ClientSettings databaseSettings, ConnectionPool<IConnection> connectionPool) {
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
                Path = string.Format("_api/document/{0}/{1}", type.Name, key)
            };
            
            var result = await GetResultAsync(payload);

            if(result == null) {
                return default(T);
            }

            var json = JsonConvert.DeserializeObject<T>(result.Content);
            return json;
        }

        public async Task<List<T>> GetAll<T>(AllResultType type = AllResultType.Full) {
            switch (type) {
                case AllResultType.Id:
                    return await Query<T>(string.Format("for x in {0} return x._id", typeof(T).Name), null).ToList();
                case AllResultType.Key:
                    return await Query<T>(string.Format("for x in {0} return x._key", typeof(T).Name), null).ToList();
                case AllResultType.Full:
                default:
                    return await Query<T>(string.Format("for x in {0} return x", typeof(T).Name), null).ToList();
            }
            
        }

        public async Task<UpdatedDocument<T>> UpdateAsync<T>(string key, T item) {
            Type type = typeof(T);

            HttpMethod method = new HttpMethod("PATCH");

            Payload payload = new Payload()
            {
                Content = JsonConvert.SerializeObject(item),
                Method = method,
                Path = string.Format("_api/document/{0}/{1}?mergeObjects=false&returnNew=true", type.Name, key)
            };

            var result = await GetResultAsync(payload);
            
            var json = JsonConvert.DeserializeObject<UpdatedDocument<T>>(result.Content);
            return json;
        }

        public async Task<bool> DeleteAsync<T>(string key) {
            Type type = typeof(T);
            
            Payload payload = new Payload()
            {
                Content = string.Empty,
                Method = HttpMethod.Delete,
                Path = string.Format("_api/document/{0}/{1}?silent=true", type.Name, key)
            };

            var result = await GetResultAsync(payload);

            if(result.StatusCode == System.Net.HttpStatusCode.OK || 
                result.StatusCode == System.Net.HttpStatusCode.Accepted) 
            {
                return true;
            } else {
                return false;
            }
                
        }

        public async Task<UpdatedDocument<T>> InsertAsync<T>(T item) {
            Type type = typeof(T);

            Payload payload = new Payload()
            {
                Content = JsonConvert.SerializeObject(item),
                Method = HttpMethod.Post,
                Path = string.Format("_api/document/{0}/?returnNew=true", type.Name)
            };

            var result = await GetResultAsync(payload);

            var json = JsonConvert.DeserializeObject<UpdatedDocument<T>>(result.Content);
            return json;
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
