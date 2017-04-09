using BorderEast.ArangoDB.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ConsoleTestApp {
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Environment.GetEnvironmentVariable("USERNAME"));
            ArangoClient.Client().SetDefaultDatabase(new BorderEast.ArangoDB.Client.Database.DatabaseSettings() {
                DatabaseName = "_system",
                Protocol = BorderEast.ArangoDB.Client.Database.ProtocolType.HTTP,
                ServerAddress = "localhost",
                ServerPort = 8529,
                SystemCredential = new System.Net.NetworkCredential("root", Environment.GetEnvironmentVariable("USERNAME")),
                DatabaseCredential = new System.Net.NetworkCredential("root", Environment.GetEnvironmentVariable("USERNAME")),
                AutoCreate = true
            });

            Dictionary<string, object> databases = new Dictionary<string, object>
            {
                { "*", "rw" },
                { "temp", 2 }
            };
            var json = JsonConvert.SerializeObject(databases);

            var client = ArangoClient.Client();

            //var q = client.DB().Query<User>("", new { _key = 1235});

            //var u = client.DB().Query<User>("for r in User return r").ToList().Result;

            var user = client.DB().GetByKeyAsync<User>("1127162").Result;

            Console.WriteLine("user = " + user.Username);

            user.Username = "andrew";

            var updated = client.DB().Update("1127162", user).Result;
            user = updated.New;

            Console.WriteLine("user = " + user.Username);

            Console.ReadLine();
        }
    }
}