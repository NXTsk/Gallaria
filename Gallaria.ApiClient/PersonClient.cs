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

        public async Task<bool> UpdatePersonAsync(PersonDto personDto)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(personDto), Encoding.Default, "application/json");
            var response = await HttpClient.PutAsync(APIUrl + "api/person/updatePerson", content);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> UpdateArtistAsync(ArtistDto artistDto)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(artistDto), Encoding.Default, "application/json");
            var response = await HttpClient.PutAsync(APIUrl + "api/person/updateArtist", content);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
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

        public async Task<ArtistDto> GetArtistByIdAsync(int id)
        {
            ArtistDto artist = new ArtistDto();

            var response = await HttpClient.GetAsync(APIUrl + "api/Person/getArtist/" + id);

            if (response.IsSuccessStatusCode)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                artist = JsonConvert.DeserializeObject<ArtistDto>(apiResponse);
            }

            return artist;
        }

        public async Task<bool> DeletePersonAsync(int id)
        {
            var response = await HttpClient.DeleteAsync(APIUrl + "api/Person/deletePerson/" + id);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> DeleteArtistAsync(int id)
        {
            var response = await HttpClient.DeleteAsync(APIUrl + "api/Person/deleteArtist/" + id);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }
    }
}
