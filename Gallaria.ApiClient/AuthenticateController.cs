using Gallaria.ApiClient.ApiResponses;
using Gallaria.ApiClient.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Gallaria.ApiClient
{
    public class AuthenticateController
    {
        private const string ApiUrl = "";

        public static async Task<AuthenticatedUserData> Login(User user)
        {
            AuthenticatedUserData authenticatedData = new AuthenticatedUserData();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync(ApiUrl + "login/login", content))
                {
                    // TODO: check for response != Unauthorized
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    authenticatedData = JsonConvert.DeserializeObject<AuthenticatedUserData>(apiResponse);
                }
            }
            return authenticatedData;
        }
    }
}
