using System;
using System.Collections.Generic;
using BorderEast.ArangoDB.Client.Database;
using BorderEast.ArangoDB.Client.Connection;
using BorderEast.ArangoDB.Client.Exception;

namespace BorderEast.ArangoDB.Client
{
    /// <summary>
    /// Entry point for interacting with ArangoDB. You only need one instance of this class, 
    /// even if working with multiple databases, hence the Singleton pattern.
    /// </summary>
    public class ArangoClient : IArangoClient {
        private readonly string DEFAULT = Res.Msg.Default;
        private static ArangoClient _client = new ArangoClient();
        internal readonly IDictionary<string, ClientSettings> databases = new SortedDictionary<string, ClientSettings>();
        internal readonly IDictionary<string, ConnectionPool<IConnection>> pools = new SortedDictionary<string, ConnectionPool<IConnection>>();

        private ArangoClient() { }

        /// <summary>
        /// Get the client instance
        /// </summary>
        /// <returns></returns>
        public static ArangoClient Client() {
            return _client;
        }

        /// <summary>
        /// Setup your default database
        /// </summary>
        /// <param name="defaultConnection"></param>
        public void SetDefaultDatabase(ClientSettings defaultConnection) {
            if (databases.ContainsKey(DEFAULT)) {
                return;
            }
            databases.Add(DEFAULT, defaultConnection);
            pools.Add(DEFAULT, new ConnectionPool<IConnection>(() => new HttpConnection(defaultConnection)));
        }

        /// <summary>
        /// Convience method to get the default database.
        /// </summary>
        /// <returns></returns>
        public ArangoDatabase DB() {
            if (!databases.ContainsKey(DEFAULT)) {
                return null;
            }
            
            return new ArangoDatabase(databases[DEFAULT], pools[DEFAULT]);
        }

        /// <summary>
        /// Get database by name
        /// </summary>
        /// <param name="database"></param>
        /// <returns></returns>
        public ArangoDatabase DB(string database) {
            if (!databases.ContainsKey(database)) {
                throw new DatabaseNotFoundException(Res.Msg.ArangoDbNotFound);
            }
            return new ArangoDatabase(databases[database], pools[database]);
        }

        /// <summary>
        /// Initialize a new database, does not actually create the db in Arango
        /// </summary>
        /// <param name="databaseSettings"></param>
        /// <returns></returns>
        public ArangoDatabase InitDB(ClientSettings databaseSettings) {
            if (databases.ContainsKey(databaseSettings.DatabaseName)) {
                throw new DatabaseExistsException(Res.Msg.ArangoDbAlreadyExists);
            }
            databases.Add(databaseSettings.DatabaseName, databaseSettings);
            pools.Add(databaseSettings.DatabaseName, new ConnectionPool<IConnection>(() => new HttpConnection(databaseSettings)));
            return new ArangoDatabase(databases[databaseSettings.DatabaseName], pools[databaseSettings.DatabaseName]);
        }
    }
}
