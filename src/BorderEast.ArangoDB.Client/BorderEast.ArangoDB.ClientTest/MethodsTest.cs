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


            if (client.DB() == null) {
                client.SetDefaultDatabase(settings);
            }

            var user = client.DB().Query<User>("for u in User return u").ToList().Result.First();

            Assert.IsType<User>(user);

        }

        [Fact]
        public void CRUDMethods() {
            if (client.DB() == null) {
                client.SetDefaultDatabase(settings);
            }
            client.InitDB(settings);

            var guid = Guid.NewGuid().ToString();
            var user = new User()
            {
                Password = "passcode",
                Username = guid
            };

            var inserted = client.DB("client-test").InsertAsync(user).Result;

            var insertUser = inserted.New;

            Assert.IsType<User>(user);
            Assert.Equal(guid, insertUser.Username);
            Assert.Equal("passcode", insertUser.Password);

            insertUser.Password = "1234";

            var updated = client.DB("client-test").UpdateAsync(inserted.Key, insertUser).Result;
            var updatedUser = updated.New;

            Assert.IsType<User>(user);
            Assert.Equal(inserted.Key, updated.Key);
            Assert.Equal(guid, updatedUser.Username);
            Assert.Equal("1234", updatedUser.Password);

            Assert.True(client.DB("client-test").DeleteAsync<User>(updated.Key).Result);

            Assert.Null(client.DB("client-test").GetByKeyAsync<User>(updated.Key).Result);

        }

    }
}
