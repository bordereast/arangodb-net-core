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

            Dictionary<string, string> databases = new Dictionary<string, string>
            {
                { "*", "rw" },
                { "saasy", "rw" }
            };
            var json = JsonConvert.SerializeObject(databases);

            var client = ArangoClient.Client();

            var user = client.DB().GetByKeyAsync<User>("1127162").Result;
            Console.WriteLine("user = " + user.Username);
            Console.ReadLine();
        }
    }
}