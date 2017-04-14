using System;
using Xunit;
using BorderEast.ArangoDB.Client;
using BorderEast.ArangoDB.Client.Database;
using BorderEast.ArangoDB.Client.Exception;
using System.Linq;
using BorderEast.ArangoDB.ClientTest.MockData;

namespace BorderEast.ArangoDB.ClientTest
{
    
    public class ArangoDBClientTest  {


        [Fact]
        public void DefaultClientBehavior() {
            var client = MockSetup.GetClient();

            // should always be available after SetDefaultDatabase
            Assert.NotNull(client.DB());

        }

        [Fact]
        public void CreateDatabase() {
            var client = MockSetup.GetClient();
            MockSetup newsetup = new MockSetup();
            var dbs = newsetup.settings;
            dbs.DatabaseName = "newtest";

            // non-existant database should be created and returned
            Assert.IsType<ArangoDatabase>(client.InitDB(dbs));

        }
    }
}
