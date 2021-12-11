using Gallaria.ApiClient.DTOs;
using Gallaria.ApiClient.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Gallaria.ApiClient
{
    public class ArtClient : IArtClient
    {
        public string APIUrl { get; set; }
        public HttpClient HttpClient { get; set; }

        public ArtClient(string _APIUrl)
        {
            APIUrl = _APIUrl;
            HttpClient = new HttpClient();
        }

        public async Task<int> CreateArtAsync(ArtDto art)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(art), Encoding.Default, "application/json");
            int returnValue = -1;

            var response = await HttpClient.PostAsync(APIUrl + "api/art", content);
            if (response.IsSuccessStatusCode)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                returnValue = JsonConvert.DeserializeObject<int>(apiResponse);
            }

            return returnValue;
        }

        public async Task<ArtDto> GetArtByIDAsync(int id)
        {
            ArtDto art = new ArtDto();

            var response = await HttpClient.GetAsync(APIUrl + "api/art/" + id);

            if (response.IsSuccessStatusCode)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                art = JsonConvert.DeserializeObject<ArtDto>(apiResponse);
            }

            return art;
        }

        public async Task<IEnumerable<ArtDto>> GetAllArtsAsync()
        {
            IEnumerable<ArtDto> artDtos = null;

            var response = await HttpClient.GetAsync(APIUrl + "api/art");
            if (response.IsSuccessStatusCode)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                artDtos = JsonConvert.DeserializeObject<IEnumerable<ArtDto>>(apiResponse);
            }
            else
            {
                throw new Exception("Error retrieving all arts");
            }
            return artDtos;
        }

        public async Task<IEnumerable<ArtDto>> GetAllArtsThatByAuthorIdAsync(int authorId)
        {
            IEnumerable<ArtDto> artDtos = null;

            var response = await HttpClient.GetAsync(APIUrl + "api/art/artistsArts/" + authorId) ;
            if (response.IsSuccessStatusCode)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                artDtos = JsonConvert.DeserializeObject<IEnumerable<ArtDto>>(apiResponse);
            }
            else
            {
                throw new Exception("Error retrieving all arts that belong to specific artist");
            }
            return artDtos;
        }

        public async Task<IEnumerable<ArtDto>> GetAllAvailableArtsAsync()
        {
            IEnumerable<ArtDto> artDtos = null;

            var response = await HttpClient.GetAsync(APIUrl + "api/art/available");
            if (response.IsSuccessStatusCode)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                artDtos = JsonConvert.DeserializeObject<IEnumerable<ArtDto>>(apiResponse);
            }
            else
            {
                throw new Exception("Error retrieving all arts");
            }

            return artDtos;
        }

        public async Task<bool> UpdateArtAsync(ArtDto artDto)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(artDto), Encoding.Default, "application/json");
            var response = await HttpClient.PutAsync(APIUrl + "api/art/", content);

            if (response.IsSuccessStatusCode)
            {   
                //Changed this DAN
                return true;
            }
            else
            {
                throw new Exception($"Error updating art");
            }
        }

        public byte[] ConvertBase64toByteArray(string pictureBase64String)
        {
            byte[] pictureByteArray = Convert.FromBase64String(pictureBase64String);
            MemoryStream memoryStream = new MemoryStream(pictureByteArray);
            memoryStream.Position = 0;

            memoryStream.Close();

            return pictureByteArray;
        }
    }
}
