using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;

namespace PhysioCam.Data
{
    class ApiClient
    {
        private HttpClient client;
        public static readonly Uri uri = new Uri("https://fast-castle-50377.herokuapp.com/");


        public async Task<HttpClient> GetClientAsync(string identifier = "student", string password = "Student1234")
        {
            if (client == null)
            {
                await SetupClient(identifier, password);
            }

            return client;
        }

        private async Task SetupClient(string identifier, string password)
        {
            client = new HttpClient();
            UserItem userItem = new UserItem() { Identifier = identifier, Password = password };
            StringContent content = new StringContent(JsonConvert.SerializeObject(userItem), Encoding.UTF8, "application/json");
            HttpResponseMessage responseMessage = await client.PostAsync(uri.AbsoluteUri + "auth/local", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                string responseContent = await responseMessage.Content.ReadAsStringAsync();
                JsonConvert.PopulateObject(responseContent, userItem);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", userItem.Jwt);
            } else
            {
                client = null;
                throw new Exception(await responseMessage.Content.ReadAsStringAsync());
            }
        }

        private class UserItem
        {
            [JsonProperty("identifier")]
            public string Identifier { get; set; }
            [JsonProperty("password")]
            public string Password { get; set; }
            [JsonProperty("jwt")]
            public string Jwt { get; set; }
        }



    }
}
