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
        private HttpClient client;
        private ClientSettings databaseSettings;

        public HttpConnection(ClientSettings databaseSettings) {

            this.databaseSettings = databaseSettings;

            bool isSystem = databaseSettings.DatabaseName == "_system";

            if (databaseSettings.HTTPClient != null ) {
                client = databaseSettings.HTTPClient;
            } else {
                client = new HttpClient();
            }

            if(client.BaseAddress == null) {
                client.BaseAddress = new Uri((databaseSettings.Protocol == ProtocolType.HTTPS ? "https" : "http") +
                        "://" + databaseSettings.ServerAddress + ":" + databaseSettings.ServerPort + "/"
                        + (isSystem ? string.Empty : string.Format("_db/{0}/", databaseSettings.DatabaseName)));
            }


        }

        private void AddHeaders(HttpRequestMessage message) {
            message.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            if (databaseSettings.DatabaseCredential != null) {
                message.Headers.Add(
                    "Authorization",
                    "Basic " + Convert.ToBase64String(
                        Encoding.UTF8.GetBytes(databaseSettings.DatabaseCredential.UserName + ":" + databaseSettings.DatabaseCredential.Password)));
            }
        }
        
        public async Task<Result> GetAsync(Payload payload) {
            var message = new HttpRequestMessage(payload.Method, client.BaseAddress + payload.Path);

            AddHeaders(message);

            if (!string.IsNullOrEmpty(payload.Content)) {
                message.Content = new StringContent(payload.Content, Encoding.UTF8, "application/json");
            }

            var responseTask = await client.SendAsync(message);

            if(responseTask.StatusCode == System.Net.HttpStatusCode.NotFound) {
                return null;
            }

            Result result = new Result()
            {
                StatusCode = responseTask.StatusCode,
                Content = await responseTask.Content.ReadAsStringAsync()
            };
            return result;
        }


    }
}
