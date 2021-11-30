using Gallaria.ApiClient.ApiResponses;
using Gallaria.ApiClient.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Gallaria.ApiClient
{
    public class PersonController
    {
        private const string ApiUrl = "https://localhost:44327/";

        public static async Task<CreatePersonApiResponse> CreatePersonAsync(PersonDto person)
        {
            var httpClient = new HttpClient();
            bool returnValue = false;
            CreatePersonApiResponse createdPerson = new CreatePersonApiResponse();
            StringContent content = new StringContent(JsonConvert.SerializeObject(person), Encoding.Default, "application/json");

            var response = await httpClient.PostAsync(ApiUrl + "api/person", content);
            if (response.IsSuccessStatusCode)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                int createdResult = JsonConvert.DeserializeObject<int>(apiResponse);    

                returnValue = true;
                createdPerson.UserId = createdResult;
            }

            createdPerson.hasBeenCreated = returnValue;
            return createdPerson;
        }

        public static async Task<CreatePersonApiResponse> CreateArtistAsync(ArtistDto artist)
        {
            var httpClient = new HttpClient();
            bool returnValue = false;
            CreatePersonApiResponse createdArtist = new CreatePersonApiResponse();
            StringContent content = new StringContent(JsonConvert.SerializeObject(artist), Encoding.Default, "application/json");

            var response = await httpClient.PostAsync(ApiUrl + "api/Person/artist", content);
            if (response.IsSuccessStatusCode)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                int createdResult = JsonConvert.DeserializeObject<int>(apiResponse);

                returnValue = true;
                createdArtist.UserId = createdResult;
            }

            createdArtist.hasBeenCreated = returnValue;
            return createdArtist;
        }

        public static async Task<bool> IsArtistAsync(int id)
        {
            var httpClient = new HttpClient();
            bool returnValue = false;

            var response = await httpClient.GetAsync(ApiUrl + "api/Person/isArtist/" + id);
            if (response.IsSuccessStatusCode)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                returnValue = JsonConvert.DeserializeObject<bool>(apiResponse);
            }

            return returnValue;
        }

        public static async Task<PersonDto> GetPersonByIdAsync(int id)
        {
            var httpClient = new HttpClient();
            PersonDto person = new PersonDto();

            var response = await httpClient.GetAsync(ApiUrl + "api/Person/" + id);
            if (response.IsSuccessStatusCode)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                person = JsonConvert.DeserializeObject<PersonDto>(apiResponse);

            }

            return person;
        }
    }
}
