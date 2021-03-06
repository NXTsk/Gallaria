using Gallaria.ApiClient.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Gallaria.ApiClient.Interfaces
{
    public interface IArtClient
    {
        public string APIUrl { get; set; }
        public HttpClient HttpClient { get; set; }


        public Task<int> CreateArtAsync(ArtDto art);
        public Task<ArtDto> GetArtByIDAsync(int id);
        public Task<IEnumerable<ArtDto>> GetAllArtsAsync();
        public Task<IEnumerable<ArtDto>> GetAllAvailableArtsAsync();
        public Task<bool> DeleteArtAsync(int id);
        public byte[] ConvertBase64toByteArray(string pictureBase64String);
    }
}
