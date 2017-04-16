using BorderEast.ArangoDB.Client.Database;

namespace BorderEast.ArangoDB.Client {

    /// <summary>
    /// Entry point for interacting with ArangoDB. You only need one instance of this class, 
    /// even if working with multiple databases, hence the Singleton pattern.
    /// </summary>
    public interface IArangoClient {

        /// <summary>
        /// Convience method to get the default database.
        /// </summary>
        /// <returns></returns>
        ArangoDatabase DB();

        /// <summary>
        /// Get database by name
        /// </summary>
        /// <param name="database"></param>
        /// <returns></returns>
        ArangoDatabase DB(string database);

        /// <summary>
        /// Initialize a new database, does not actually create the db in Arango
        /// </summary>
        /// <param name="databaseSettings"></param>
        /// <returns></returns>
        ArangoDatabase InitDB(ClientSettings databaseSettings);

        /// <summary>
        /// Setup your default database
        /// </summary>
        /// <param name="defaultConnection"></param>
        void SetDefaultDatabase(ClientSettings defaultConnection);
    }
}