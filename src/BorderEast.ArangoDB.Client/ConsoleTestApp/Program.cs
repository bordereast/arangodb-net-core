using BorderEast.ArangoDB.Client;
using BorderEast.ArangoDB.Client.Database;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleTestApp {
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Environment.GetEnvironmentVariable("USERNAME"));
            ArangoClient.Client().SetDefaultDatabase(new BorderEast.ArangoDB.Client.Database.ClientSettings() {
                DatabaseName = "_system",
                Protocol = BorderEast.ArangoDB.Client.Database.ProtocolType.HTTP,
                ServerAddress = "localhost",
                ServerPort = 8529,
                SystemCredential = new System.Net.NetworkCredential("root", Environment.GetEnvironmentVariable("USERNAME")),
                DatabaseCredential = new System.Net.NetworkCredential("root", Environment.GetEnvironmentVariable("USERNAME")),
                AutoCreate = true,
                HTTPClient = new System.Net.Http.HttpClient(),
                IsDebug = true
            });

            var juser = new User()
            {
                Username = "andrew",
                Password = "passcode"
            };

            //var token = JsonConvert.SerializeObject(juser, Formatting.Indented, new ArangoJsonConverter(typeof(User)));

            //Dictionary<string, object> databases = new Dictionary<string, object>
            //{
            //    { "*", "rw" },
            //    { "temp", 2 }
            //};
            //var json = JsonConvert.SerializeObject(databases);

            var client = ArangoClient.Client();
            var users = client.DB().GetAllAsync<User>().Result;
            var users2 = client.DB().GetAllKeysAsync<User>().Result;

            // var result = client.DB().InsertAsync<User>(juser);
            //var user = client.DB().Query<User>("for u in User return u").ToList().Result.First();
            //var user = client.DB().GetByKeyAsync<User>("1312460").Result;
            //var q = client.DB().Query<User>("", new { _key = 1235});

            //var u = client.DB().Query<User>("for r in User return r").ToList().Result;

            // var user = client.DB().GetByKeyAsync<User>("1127162").Result;

            //Console.WriteLine("user = " + user.Username);

            ////user.Username = "andrew";
            //var user = result.Result.New;
            //user.Password = "new";
            //var updated = client.DB().UpdateAsync("1127162", user).Result;
            //var result2 = client.DB().DeleteAsync<User>("1127162");
            //user = updated.New;

            //Console.WriteLine("user = " + user.Username);

            Console.ReadLine();
        }
    }
}