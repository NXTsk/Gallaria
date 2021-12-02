using Gallaria.ApiClient.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Gallaria.ApiClient.Interfaces
{
    public interface IPersonClient
    {
        public string APIUrl { get; set; }
        public HttpClient HttpClient { get; set; }

        public Task<int> CreatePersonAsync(PersonDto person);
        public Task<int> CreateArtistAsync(ArtistDto artist);
        public Task<bool> IsArtistAsync(int id);
        public Task<PersonDto> GetPersonByIdAsync(int id);
    }
}
