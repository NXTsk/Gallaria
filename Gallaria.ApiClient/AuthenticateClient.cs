using Gallaria.ApiClient.DTOs;
using Gallaria.ApiClient.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Gallaria.ApiClient
{
    public class AuthenticateClient : IAuthenticateClient
    {
        public string APIUrl { get; set; }
        public HttpClient HttpClient { get; set; }

        public AuthenticateClient(string _APIUrl)
        {
            APIUrl = _APIUrl;
            HttpClient = new HttpClient();
        }

        public async Task<AuthUserDto> LoginAsync(UserDto user)
        {
            AuthUserDto authenticatedData = new AuthUserDto();
            StringContent content = new StringContent(JsonConvert.SerializeObject(user), Encoding.Default, "application/json");

            var response = await HttpClient.PostAsync(APIUrl + "api/Login", content);

            if (response.IsSuccessStatusCode)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                authenticatedData = JsonConvert.DeserializeObject<AuthUserDto>(apiResponse);
                authenticatedData.IsUserAuthenticated = true;
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                authenticatedData.IsUserAuthenticated = false;
            }

            return authenticatedData;
        }
    }
}
