using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using BorderEast.ArangoDB.Client.Database;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace BorderEast.ArangoDB.Client.Connection
{
    public class HttpConnection : IConnection
    {
        private HttpClient client = new HttpClient();
        private DatabaseSettings databaseSettings;

        public HttpConnection(DatabaseSettings databaseSettings) {
            this.databaseSettings = databaseSettings;

            client.BaseAddress = new Uri((databaseSettings.Protocol == ProtocolType.HTTPS ? "https" : "http") + 
                "://" + databaseSettings.ServerAddress + ":" + databaseSettings.ServerPort + "/");

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            
        }



        public async Task<Result> GetAsync(Payload payload) {
            if (databaseSettings.DatabaseCredential != null) {
                client.DefaultRequestHeaders.Add(
                    "Authorization",
                    "Basic " + Convert.ToBase64String(
                        Encoding.ASCII.GetBytes(databaseSettings.DatabaseCredential.UserName + ":" + databaseSettings.DatabaseCredential.Password)));
            }

            var message = new HttpRequestMessage(payload.Method, payload.Path);

            if (!string.IsNullOrEmpty(payload.Content)) {
                message.Content = new StringContent(payload.Content, Encoding.UTF8, "application/json");
            }

            var responseTask = await client.SendAsync(message);

            Result result = new Result()
            {
                StatusCode = responseTask.StatusCode,
                Content = await responseTask.Content.ReadAsStringAsync()
            };
            return result;
        }


    }
}
