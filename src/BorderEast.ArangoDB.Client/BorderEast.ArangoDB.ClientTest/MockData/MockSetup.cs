using BorderEast.ArangoDB.Client;
using BorderEast.ArangoDB.Client.Database;
using RichardSzalay.MockHttp;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace BorderEast.ArangoDB.ClientTest.MockData
{
    public  class MockSetup
    {
        public MockHttpMessageHandler mockHttp = new MockHttpMessageHandler();
        public ArangoClient client = ArangoClient.Client();
        public ClientSettings settings = new ClientSettings()
        {
            DatabaseName = "_system",
            Protocol = ProtocolType.HTTP,
            ServerAddress = "localhost",
            ServerPort = 8529,
            SystemCredential = new System.Net.NetworkCredential("root", Environment.GetEnvironmentVariable("USERNAME")),
            DatabaseCredential = new System.Net.NetworkCredential("client-test", "client-test"),
            AutoCreate = true,
            HTTPClient = null,
            IsDebug = true
        };

        public static ArangoClient GetClient() {
            MockSetup setup = new MockSetup();
            if (setup.settings.HTTPClient == null) {
                setup.SetupRoutes(setup.mockHttp);
                setup.settings.HTTPClient = new System.Net.Http.HttpClient(setup.mockHttp);
                setup.client.SetDefaultDatabase(setup.settings);
            }
            return setup.client;
        }
        
        private void SetupRoutes(MockHttpMessageHandler m) {
            m.When(HttpMethod.Post, "*/_api/document/User/?returnNew=true").
                Respond("application/json", "{\"_id\":\"User/1312460\",\"_key\":\"1312460\",\"_rev\":\"_U0xbgLu---\",\"new\":{\"_key\":\"1312460\",\"_id\":\"User/1312460\",\"_rev\":\"_U0xbgLu---\",\"userName\":\"jdoe\",\"passwd\":\"passcode\"}}");

            m.When(new HttpMethod("PATCH"), "*/_api/document/User/1312460?mergeObjects=false&returnNew=true").
               Respond("application/json", "{\"_id\":\"User/1312460\",\"_key\":\"1313328\",\"_rev\":\"_U0xo_h2---\",\"new\":{\"_key\":\"1312460\",\"_id\":\"User/1312460\",\"_rev\":\"_U0xo_h2---\",\"userName\":\"jdoe\",\"passwd\":\"newpass\"}}");

            m.When(HttpMethod.Delete, "*/_api/document/User/1127162?silent=true").
                Respond("application/json", "{\"_id\":\"User/1127162\",\"_key\":\"1127162\",\"_rev\":\"_U0x1Nem---\"}");

            m.When(HttpMethod.Get, "*/_api/document/User/1312460").
               Respond("application/json", "{\"_key\":\"1312460\",\"_id\":\"User/1312460\",\"_rev\":\"_U0xbgLu---\",\"userName\":\"andrew\",\"passwd\":\"passcode\"}");

            m.When(HttpMethod.Get, "*/_api/document/User/1234").
               Respond(System.Net.HttpStatusCode.NotFound);

            m.When(HttpMethod.Post, "*/_api/cursor?query=Zm9yIHUgaW4gVXNlciByZXR1cm4gdQ==").
                Respond("application/json", "{\"result\":[{\"_id\":\"User/1312460\",\"_key\":\"1312460\",\"_rev\":\"_U0xbgLu---\",\"passwd\":\"passcode\",\"userName\":\"andrew\"},{\"_id\":\"User/1314279\",\"_key\":\"1314279\",\"_rev\":\"_U0x1-he---\",\"passwd\":\"passcode\",\"userName\":\"andrew\"},{\"_id\":\"User/1313287\",\"_key\":\"1313287\",\"_rev\":\"_U0xnhJO---\",\"passwd\":\"passcode\",\"userName\":\"andrew\"},{\"_id\":\"User/1313328\",\"_key\":\"1313328\",\"_rev\":\"_U0xo_h2---\",\"passwd\":\"passcode\",\"userName\":\"andrew\"}],\"hasMore\":false,\"cached\":false,\"extra\":{\"stats\":{\"writesExecuted\":0,\"writesIgnored\":0,\"scannedFull\":4,\"scannedIndex\":0,\"filtered\":0,\"executionTime\":9.999275207519531e-4},\"warnings\":[]},\"error\":false,\"code\":201}");

            m.When(HttpMethod.Post, "*/_api/cursor?query=Zm9yIHggaW4gQEBjb2wgcmV0dXJuIHg=").
                Respond("application/json", "{\"result\":[{\"_id\":\"User/6489\",\"_key\":\"6489\",\"_rev\":\"_U02b8YG---\"},{\"_id\":\"User/6503\",\"_key\":\"6503\",\"_rev\":\"_U02cCh6---\"}],\"hasMore\":false,\"cached\":true,\"extra\":{},\"error\":false,\"code\":201}");

            m.When(HttpMethod.Post, "*/_api/cursor?query=Zm9yIHggaW4gQEBjb2wgcmV0dXJuIHguX2tleQ==").
                Respond("application/json", "{\"result\":[{\"_id\":\"User/1312460\",\"_key\":\"1312460\",\"_rev\":\"_U0xbgLu---\",\"passwd\":\"passcode\",\"userName\":\"andrew\"},{\"_id\":\"User/1314279\",\"_key\":\"1314279\",\"_rev\":\"_U0x1-he---\",\"passwd\":\"passcode\",\"userName\":\"andrew\"},{\"_id\":\"User/1313287\",\"_key\":\"1313287\",\"_rev\":\"_U0xnhJO---\",\"passwd\":\"passcode\",\"userName\":\"andrew\"},{\"_id\":\"User/1313328\",\"_key\":\"1313328\",\"_rev\":\"_U0xo_h2---\",\"passwd\":\"passcode\",\"userName\":\"andrew\"}],\"hasMore\":false,\"cached\":false,\"extra\":{\"stats\":{\"writesExecuted\":0,\"writesIgnored\":0,\"scannedFull\":4,\"scannedIndex\":0,\"filtered\":0,\"executionTime\":9.999275207519531e-4},\"warnings\":[]},\"error\":false,\"code\":201}");

            m.When(HttpMethod.Post, "*/_api/cursor").
                Respond("application/json", "{\"result\":[\"6489\",\"6503\"],\"hasMore\":false,\"cached\":false,\"extra\":{\"stats\":{\"writesExecuted\":0,\"writesIgnored\":0,\"scannedFull\":2,\"scannedIndex\":0,\"filtered\":0,\"executionTime\":0},\"warnings\":[]},\"error\":false,\"code\":201}");


        }

    }
}
