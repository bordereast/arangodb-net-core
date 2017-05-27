using Arango.VelocyPack;
using BorderEast.ArangoDB.Client;
using BorderEast.ArangoDB.Client.Database;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Arango.VelocyPack.Segments;

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

            var client = ArangoClient.Client();


            VelocyStream vs = new VelocyStream();
            vs.Connect("127.0.0.1", 8528);

            var stream = vs.Stream;
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes("VST/1.0\r\n\r\n");
            byte[] messageBytes = System.Text.Encoding.UTF8.GetBytes("[version: 1, type: 1, requestType 1, request: \"/_admin/echo\", parameter: {a: 1}]");

          //  Segment arraySegment = VPack.ToSegment(messageBytes);

            stream.Write(bytes, 0, bytes.Length);
            stream.Flush();
            stream.Write(messageBytes, 0, messageBytes.Length);
            stream.Flush();

            var data = new Byte[256];
            String responseData = String.Empty;

 

                // Read the first batch of the TcpServer response bytes.
            var inbytes = stream.Read(data, 0, data.Length);
            responseData = System.Text.Encoding.UTF8.GetString(data, 0, inbytes);
            Console.WriteLine("Received: {0}", responseData);

            //Role r = new Role()
            //{
            //    Name = "sysadmin",
            //    Permission = "RW"
            //};
            //Role r2 = new Role()
            //{
            //    Name = "author",
            //    Permission = "RW"
            //};

            //var uR1 = client.DB().InsertAsync<Role>(r).Result;
            //var uR2 = client.DB().InsertAsync<Role>(r2).Result;




            //var juser = new User()
            //{
            //    Username = "andrew",
            //    Password = "passcode",
            //    Roles = new List<Role>() { }
            //};


            //JsonSerializerSettings settings = new JsonSerializerSettings
            //{
            //    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Serialize,
            //    Formatting = Newtonsoft.Json.Formatting.Indented
            //};

            //string json = JsonConvert.SerializeObject(juser);

            //var s = json;
            ////var u1 = client.DB().InsertAsync<Role>(r2).Result;
            //var users = client.DB().GetAllAsync<User>();

            //var u = client.DB().GetByKeyAsync<User>("");

            //var token = JsonConvert.SerializeObject(juser, Formatting.Indented, new ArangoJsonConverter(typeof(User)));

            //Dictionary<string, object> databases = new Dictionary<string, object>
            //{
            //    { "*", "rw" },
            //    { "temp", 2 }
            //};
            //var json = JsonConvert.SerializeObject(databases);


            //var users = client.DB().GetAllAsync<User>().Result;
            //var users2 = client.DB().GetAllKeysAsync<User>().Result;

            //var result = client.DB().InsertAsync<User>(juser);
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