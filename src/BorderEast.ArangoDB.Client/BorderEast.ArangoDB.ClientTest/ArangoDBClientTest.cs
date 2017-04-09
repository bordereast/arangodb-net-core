using System;
using Xunit;
using BorderEast.ArangoDB.Client;
using BorderEast.ArangoDB.Client.Database;
using BorderEast.ArangoDB.Client.Exception;

namespace BorderEast.ArangoDB.ClientTest
{
    
    public class ArangoDBClientTest  {

        private ArangoClient client = ArangoClient.Client();
        private DatabaseSettings settings = new DatabaseSettings()
        {
            DatabaseName = "_system",
            Protocol = ProtocolType.HTTP,
            ServerAddress = "localhost",
            ServerPort = 8529,
            SystemCredential = new System.Net.NetworkCredential("root", Environment.GetEnvironmentVariable("USERNAME")),
            DatabaseCredential = new System.Net.NetworkCredential("client-test", "client-test"),
            AutoCreate = true
        };


        [Fact]
        public void DefaultClientBehavior()
        {
            // should fail before a call to SetDefaultDatabase
            Assert.Throws<DatabaseNotFoundException>(() => client.DB()); 

            client.SetDefaultDatabase(settings);

            // should always be available after SetDefaultDatabase
            Assert.NotNull( client.DB()); 

            settings.DatabaseName = "default";

            // never more than one default database
            Assert.Throws<DatabaseExistsException>(() => client.InitDB(settings)); 

            // reset for other tests
            settings.DatabaseName = "_system";
        }

        [Fact]
        public void CreateDatabase() {
            settings.DatabaseName = "new";

            // non-existant database should be created and returned
            Assert.IsType<ArangoDatabase>(client.InitDB(settings));

            // reset for other tests
            settings.DatabaseName = "_system"; 
        }
    }
}
