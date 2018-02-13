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

    public class MethodsTest {

        [Fact]
        public void AQLSelectEntity() {

            var client = MockSetup.GetClient();
            var user = client.DB().Query<User>("for u in User return u").ToListAsync().Result.First();
            
            Assert.IsType<User>(user);
        }

        [Fact]
        public void GetAll() {
            var client = MockSetup.GetClient();
            var users = client.DB().GetAllAsync<User>().Result;
            Assert.Equal(4, users.Count());
        }

        public void GetAllKeys() {
            var client = MockSetup.GetClient();
            var users = client.DB().GetAllKeysAsync<User>().Result;
            Assert.Equal(2, users.Count());
        }

        [Fact]
        public void CRUDMethods() {
            var client = MockSetup.GetClient();

            var id = "1312460";
            var user = new User()
            {
                Password = "passcode",
                Username = "jdoe"
            };

            var inserted = client.DB().InsertAsync(user).Result;

            var insertUser = inserted.New;

            Assert.IsType<User>(user);
            Assert.Equal("jdoe", insertUser.Username);
            Assert.Equal("passcode", insertUser.Password);
            Assert.Equal(id, inserted.Key);           

        }

        [Fact]
        public void InsertManyAsyncTest()
        {
            var client = MockSetup.GetClient();

            var id1 = "8633435";
            var id2 = "8633439";

            var listOfUsers = new List<InsertManyUser>
            {
                new InsertManyUser()
                {
                    Password = "passcode1",
                    Username = "jdoe1"
                },
                new InsertManyUser()
                {
                    Password = "passcode2",
                    Username = "jdoe2"
                },
            };

            var inserted = client.DB().InsertManyAsync(listOfUsers).Result;

            Assert.Equal(inserted.Count(), listOfUsers.Count());

            var insertUser1 = inserted.First();
            var insertUser2 = inserted.Last();

            Assert.Equal("jdoe1", insertUser1.New.Username);
            Assert.Equal("passcode1", insertUser1.New.Password);
            Assert.Equal(id1, insertUser1.Key);

            Assert.Equal("jdoe2", insertUser2.New.Username);
            Assert.Equal("passcode2", insertUser2.New.Password);
            Assert.Equal(id2, insertUser2.Key);
        }

        [Fact]
        public void UpdateAsync() {

            var client = MockSetup.GetClient();

            var id = "1312460";
            var user = new User()
            {
                Password = "passcode",
                Username = "newpass"
            };

            var updated = client.DB().UpdateAsync(id, user).Result;
            var updatedUser = updated.New;

            Assert.IsType<User>(user);
            Assert.Equal("newpass", updatedUser.Password);
        }

        [Fact]
        public void GetByNullKeyAsync() {
            var client = MockSetup.GetClient();
            Assert.Null(client.DB().GetByKeyAsync<User>("1234").Result);
        }

        [Fact]
        public void GetByKeyAsync() {
            var client = MockSetup.GetClient();
            Assert.NotNull(client.DB().GetByKeyAsync<User>("1312460").Result);
        }

        [Fact]
        public void DeleteAsync() {
            var client = MockSetup.GetClient();
            Assert.True(client.DB().DeleteAsync<User>("1127162").Result);
        }
    }
}
