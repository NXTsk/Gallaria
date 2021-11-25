using Gallaria.ApiClient.ApiResponses;
using Gallaria.ApiClient.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Gallaria.ApiClient
{
    public class ArtController

    {
        private const string ApiUrl = "https://localhost:44327/";

        public static async Task<CreateArtApiResponse> CreateArtAsync(ArtDto art)
        {
            var httpClient = new HttpClient();
            bool returnValue = false;
            CreateArtApiResponse createdArt = new CreateArtApiResponse();
            StringContent content = new StringContent(JsonConvert.SerializeObject(art), Encoding.Default, "application/json");

            var response = await httpClient.PostAsync(ApiUrl + "api/art", content);
            if (response.IsSuccessStatusCode)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                int createdResult = JsonConvert.DeserializeObject<int>(apiResponse);

                returnValue = true;
                createdArt.ArtId = createdResult;
            }

            createdArt.hasBeenCreated = returnValue;
            return createdArt;
        }

        public static async Task<ArtDto> GetArtByIDAsync(int id)
        {
            var httpClient = new HttpClient();
            ArtDto art = new ArtDto();

            var response = await httpClient.GetAsync(ApiUrl + "api/art/" + id);
            if (response.IsSuccessStatusCode)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                art = JsonConvert.DeserializeObject<ArtDto>(apiResponse);

            }

            return art;
        }
        public static byte[] ConvertBase64toByteArray(string pictureBase64String)
        {
            byte[] pictureByteArray = Convert.FromBase64String(pictureBase64String);
            MemoryStream memoryStream = new MemoryStream(pictureByteArray);
            memoryStream.Position = 0;

            memoryStream.Close();

            return pictureByteArray;
        }
    }
}
