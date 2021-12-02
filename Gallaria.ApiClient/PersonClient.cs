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
    public class PersonClient : IPersonClient
    {

        public string APIUrl { get; set; }
        public HttpClient HttpClient { get; set; }

        public PersonClient(string _APIUrl)
        {
            APIUrl = _APIUrl;
            HttpClient = new HttpClient();
        }

        //public static async Task<CreatePersonApiResponse> CreatePersonAsync(PersonDto person)
        //{
        //    var httpClient = new HttpClient();
        //    bool returnValue = false;
        //    CreatePersonApiResponse createdPerson = new CreatePersonApiResponse();
        //    StringContent content = new StringContent(JsonConvert.SerializeObject(person), Encoding.Default, "application/json");

        //    var response = await httpClient.PostAsync(ApiUrl + "api/person", content);
        //    if (response.IsSuccessStatusCode)
        //    {
        //        string apiResponse = await response.Content.ReadAsStringAsync();
        //        int createdResult = JsonConvert.DeserializeObject<int>(apiResponse);    

        //        returnValue = true;
        //        createdPerson.UserId = createdResult;
        //    }

        //    createdPerson.hasBeenCreated = returnValue;
        //    return createdPerson;
        //}

        //public static async Task<CreatePersonApiResponse> CreateArtistAsync(ArtistDto artist)
        //{
        //    var httpClient = new HttpClient();
        //    bool returnValue = false;
        //    CreatePersonApiResponse createdArtist = new CreatePersonApiResponse();
        //    StringContent content = new StringContent(JsonConvert.SerializeObject(artist), Encoding.Default, "application/json");

        //    var response = await httpClient.PostAsync(ApiUrl + "api/Person/artist", content);
        //    if (response.IsSuccessStatusCode)
        //    {
        //        string apiResponse = await response.Content.ReadAsStringAsync();
        //        int createdResult = JsonConvert.DeserializeObject<int>(apiResponse);

        //        returnValue = true;
        //        createdArtist.UserId = createdResult;
        //    }

        //    createdArtist.hasBeenCreated = returnValue;
        //    return createdArtist;
        //}

        //public static async Task<bool> IsArtistAsync(int id)
        //{
        //    var httpClient = new HttpClient();
        //    bool returnValue = false;

        //    var response = await httpClient.GetAsync(ApiUrl + "api/Person/isArtist/" + id);
        //    if (response.IsSuccessStatusCode)
        //    {
        //        string apiResponse = await response.Content.ReadAsStringAsync();
        //        returnValue = JsonConvert.DeserializeObject<bool>(apiResponse);
        //    }

        //    return returnValue;
        //}

        //public static async Task<PersonDto> GetPersonByIdAsync(int id)
        //{
        //    var httpClient = new HttpClient();
        //    PersonDto person = new PersonDto();

        //    var response = await httpClient.GetAsync(ApiUrl + "api/Person/" + id);
        //    if (response.IsSuccessStatusCode)
        //    {
        //        string apiResponse = await response.Content.ReadAsStringAsync();
        //        person = JsonConvert.DeserializeObject<PersonDto>(apiResponse);

        //    }

        //    return person;
        //}



        public async Task<int> CreatePersonAsync(PersonDto person)
        {
            int returnValue = -1;

            StringContent content = new StringContent(JsonConvert.SerializeObject(person), Encoding.Default, "application/json");
            var response = await HttpClient.PostAsync(APIUrl + "api/person", content);

            if (response.IsSuccessStatusCode)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                returnValue = JsonConvert.DeserializeObject<int>(apiResponse);
            }

            
            return returnValue;
        }

        public async Task<int> CreateArtistAsync(ArtistDto artist)
        {
            int returnValue = -1;

            StringContent content = new StringContent(JsonConvert.SerializeObject(artist), Encoding.Default, "application/json");
            var response = await HttpClient.PostAsync(APIUrl + "api/Person/artist", content);

            if (response.IsSuccessStatusCode)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                returnValue = JsonConvert.DeserializeObject<int>(apiResponse);

            }

            return returnValue;
        }

        public async Task<bool> IsArtistAsync(int id)
        {
            bool returnValue = false;

            var response = await HttpClient.GetAsync(APIUrl + "api/Person/isArtist/" + id);

            if (response.IsSuccessStatusCode)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                returnValue = JsonConvert.DeserializeObject<bool>(apiResponse);
            }

            return returnValue;
        }

        public async Task<PersonDto> GetPersonByIdAsync(int id)
        {
            PersonDto person = new PersonDto();

            var response = await HttpClient.GetAsync(APIUrl + "api/Person/" + id);

            if (response.IsSuccessStatusCode)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                person = JsonConvert.DeserializeObject<PersonDto>(apiResponse);
            }

            return person;
        }
    }
}
