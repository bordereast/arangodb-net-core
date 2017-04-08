using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace BorderEast.ArangoDB.Client.Database
{
    public class DatabaseSettings {

        public DatabaseSettings() { }

        public DatabaseSettings(string serverAddress, int serverPort, ProtocolType protocolType, 
            string systemPassword, string databaseName, string databaseUsername, string databasePassword, bool autoCreate) 
        {
            ServerAddress = serverAddress;
            ServerPort = serverPort;
            Protocol = protocolType;
            DatabaseName = databaseName;
            SystemCredential = new NetworkCredential("root", systemPassword);
            DatabaseCredential = new NetworkCredential(databaseUsername, databasePassword);
            AutoCreate = autoCreate;
        }

        public string ServerAddress { get; set; }

        public int ServerPort {get;set;}

        public ProtocolType Protocol { get; set; }

        public string DatabaseName { get; set; }

        public NetworkCredential SystemCredential { get; set; }

        public NetworkCredential DatabaseCredential { get; set; }

        public bool AutoCreate { get; set; }
    }
}
