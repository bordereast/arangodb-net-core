using BorderEast.ArangoDB.Client.Connection;
using BorderEast.ArangoDB.Client.Database.Meta;
using BorderEast.ArangoDB.Client.Models;
using BorderEast.ArangoDB.Client.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Linq;
using BorderEast.ArangoDB.Client.Database.AQLCursor;

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

        private ArangoQuery<T> Query<T>(AQLQuery query) {
            return new ArangoQuery<T>(query, connectionPool, this);
        }

        public async Task<List<T>> GetByExampleAsync<T>(dynamic parameters) {
            Type type = typeof(T);

            ForeignKey fk = HasForeignKey(type);

            var q = BuildFKQuery(fk, type, parameters);

            return await Query<T>(q).ToListAsync();

        }

        public async Task<T> GetByKeyAsync<T>(string key) {
            Type type = typeof(T);

            ForeignKey fk = HasForeignKey(type);

            if (fk.IsForeignKey) {
                var q = BuildFKQuery(fk, type, new { _key = key });

                var r = await Query<T>(q).ToListAsync();
                return r.FirstOrDefault();
            }

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

        
        public async Task<List<T>> GetAllAsync<T>() {
            Type t = typeof(T);

            ForeignKey fk = HasForeignKey(t);

            if (fk.IsForeignKey) {
                var q = BuildFKQuery(fk, t);

                return await Query<T>(q).ToListAsync();
            }

            return await Query<T>("for x in @@col return x", 
                new Dictionary<string, object>{{ "@col", typeof(T).Name }}).ToListAsync();
        }

        private AQLQuery BuildFKQuery(ForeignKey fk, Type baseType, dynamic parameters = null) {
            var q = new AQLQuery();
            var parms = new Dictionary<string, object>();
            var sb = new StringBuilder();
            Dictionary<string, object> dParams = null;
            if(parameters != null) {
                dParams = DynamicUtil.DynamicToDict(parameters);
            }
            

            sb.Append("for x1 in  " + baseType.Name);
            // parms.Add("@col", baseType.Name);

            if (fk.IsForeignKey) {
                for (var i = 0; i < fk.ForeignKeyTypes.Count; i++) {
                    sb.AppendFormat(" LET {0} = ( for x in x1.{1} for {0} in {2} FILTER x == {0}._key return {0}) ",
                        "a" + i, // {0}
                        fk.ForeignKeyTypes[i].Key,  // {1}
                        fk.ForeignKeyTypes[i].Value.Name);  // {2}
                }
            }

            // check for parameters
            if(dParams != null && dParams.Count > 0) {
                var dp = dParams.ToArray();
                for(var i = 0; i < dp.Length; i++) {
                    sb.AppendFormat(" FILTER x1.{0} == @{1} ", dp[i].Key, "pval" + i);
                    parms.Add("pval" + i, dp[i].Value);
                }
            }

            if (fk.IsForeignKey) {
                sb.Append(" return merge (x1, {");

                for (var i = 0; i < fk.ForeignKeyTypes.Count; i++) {
                    if (i > 0) {
                        sb.Append(", ");
                    }

                    sb.AppendFormat("{1}: {0}", // Roles: a1
                        "a" + i, // {0}
                        fk.ForeignKeyTypes[i].Key);  // {2}
                }

                sb.Append(" }) ");
            } else {
                sb.Append(" return x1 ");
            }

            q.Query = sb.ToString();

            if(parms.Count > 0) {
                q.Parameters = parms;
            }

            return q;
        }

        private ForeignKey HasForeignKey(Type t) {
            ForeignKey fk = new ForeignKey();
            var attribute = t.GetTypeInfo().GetCustomAttribute<CollectionAttribute>();
            if (attribute != null && attribute.HasForeignKey) {
                fk.ForeignKeyTypes = new List<KeyValuePair<string, Type>>();

                foreach (var p in t.GetProperties()) {
                    var jca = p.GetCustomAttribute<JsonConverterAttribute>();
                    if (jca != null) {
                        if (jca.ConverterType == typeof(ForeignKeyConverter)) {
                            var ta = p.PropertyType.GenericTypeArguments.FirstOrDefault();
                            fk.ForeignKeyTypes.Add(new KeyValuePair<string,Type>(p.Name, ta));
                        }
                    }
                }
                fk.IsForeignKey = true;
            } else {
                fk.IsForeignKey = false;
            }

            return fk;
        }

        public async Task<List<string>> GetAllKeysAsync<T>() {
            return await Query<string>("for x in @@col return x._key",
                new Dictionary<string, object> { { "@col", typeof(T).Name } }).ToListAsync();
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
