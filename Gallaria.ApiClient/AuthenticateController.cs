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
        private const string ApiUrl = "https://localhost:44327/";

        public static async Task<AuthenticatedUserData> Login(User user)
        {
            AuthenticatedUserData authenticatedData = new AuthenticatedUserData();
            var httpClient = new HttpClient();
            StringContent content = new StringContent(JsonConvert.SerializeObject(user), Encoding.Default, "application/json");

            var response = await httpClient.PostAsync(ApiUrl + "api/Login", content);

            if (response.IsSuccessStatusCode)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                authenticatedData = JsonConvert.DeserializeObject<AuthenticatedUserData>(apiResponse);
                authenticatedData.isUserAuthenticated = true;
            }
            else if(response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                authenticatedData.isUserAuthenticated = false;
            }                

            return authenticatedData;
        }
    }
}
