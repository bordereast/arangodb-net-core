using BorderEast.ArangoDB.Client;
using BorderEast.ArangoDB.Client.Database;
using BorderEast.ArangoDB.ClientTest.MockData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace BorderEast.ArangoDB.ClientTest
{
    public class MethodsTest
    {
        private ArangoClient client = ArangoClient.Client();
        private DatabaseSettings settings = new DatabaseSettings()
        {
            DatabaseName = "client-test",
            Protocol = ProtocolType.HTTP,
            ServerAddress = "localhost",
            ServerPort = 8529,
            SystemCredential = new System.Net.NetworkCredential("root", Environment.GetEnvironmentVariable("USERNAME")),
            DatabaseCredential = new System.Net.NetworkCredential("client-test", "client-test"),
            AutoCreate = true
        };

        [Fact]
        public void AQLSelectEntity() {


            client.SetDefaultDatabase(settings);

            var user = client.DB().Query<User>("for u in User return u").ToList().Result.First();

            Assert.IsType<User>(user);

        }

    }
}
