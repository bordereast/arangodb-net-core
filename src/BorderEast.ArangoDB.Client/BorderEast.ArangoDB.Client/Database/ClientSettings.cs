using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;

namespace BorderEast.ArangoDB.Client.Database
{
    public class ClientSettings {

        public ClientSettings() {
            JsonSettings = new JsonSerializerSettings
            {
                ContractResolver = new ArangoDBContractResolver(),
                DateTimeZoneHandling = DateTimeZoneHandling.Utc,
                NullValueHandling = NullValueHandling.Include,
                DefaultValueHandling = DefaultValueHandling.Include,
                StringEscapeHandling = StringEscapeHandling.Default,
                Formatting = Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };
        }

        public ClientSettings(string serverAddress, int serverPort, ProtocolType protocolType, 
            string systemPassword, string databaseName, string databaseUsername, string databasePassword, 
            bool autoCreate, bool isDebug = false) 
        {
            ServerAddress = serverAddress;
            ServerPort = serverPort;
            Protocol = protocolType;
            DatabaseName = databaseName;
            SystemCredential = new NetworkCredential("root", systemPassword);
            DatabaseCredential = new NetworkCredential(databaseUsername, databasePassword);
            AutoCreate = autoCreate;


            JsonSettings = new JsonSerializerSettings
            {
                ContractResolver = new ArangoDBContractResolver(),
                DateTimeZoneHandling = DateTimeZoneHandling.Utc,
                NullValueHandling = NullValueHandling.Include,
                DefaultValueHandling = DefaultValueHandling.Include,
                StringEscapeHandling = StringEscapeHandling.Default,
                Formatting = Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };


            IsDebug = isDebug;
        }

        public JsonSerializerSettings JsonSettings { get; set; }

        public string ServerAddress { get; set; }

        public int ServerPort {get;set;}

        public ProtocolType Protocol { get; set; }

        public HttpClient HTTPClient { get; set; }

        public string DatabaseName { get; set; }

        public NetworkCredential SystemCredential { get; set; }

        public NetworkCredential DatabaseCredential { get; set; }

        public bool AutoCreate { get; set; }

        public bool IsDebug { get; set; }
    }
}
