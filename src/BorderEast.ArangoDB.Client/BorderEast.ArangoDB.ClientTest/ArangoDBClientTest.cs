using System;
using Xunit;
using BorderEast.ArangoDB.Client;
using BorderEast.ArangoDB.Client.Database;
using BorderEast.ArangoDB.Client.Exception;

namespace BorderEast.ArangoDB.ClientTest
{
    
    public class ArangoDBClientTest  {

        
        //[Fact]
        //public void DefaultClientBehavior()
        //{
        //    var client = MockData.MockSetup.GetClient();
            
        //    if(client.DB() == null) {
        //        client.SetDefaultDatabase(settings);
        //    }

        //    // should always be available after SetDefaultDatabase
        //    Assert.NotNull( client.DB()); 

        //    settings.DatabaseName = "default";

        //    // never more than one default database
        //    Assert.Throws<DatabaseExistsException>(() => client.InitDB(settings)); 

        //    // reset for other tests
        //    settings.DatabaseName = "_system";
        //}

        //[Fact]
        //public void CreateDatabase() {
        //    settings.DatabaseName = "new";

        //    // non-existant database should be created and returned
        //    Assert.IsType<ArangoDatabase>(client.InitDB(settings));

        //    // reset for other tests
        //    settings.DatabaseName = "_system"; 
        //}
    }
}
