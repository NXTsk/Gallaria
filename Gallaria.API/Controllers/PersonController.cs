 using DataAccess.Repositories;
using Gallaria.API.Converters;
using Gallaria.API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace Gallaria.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : Controller
    {
        IConfiguration _config;
        IPersonRepository _personRepository;

        public PersonController(IConfiguration config)
        {
            _config = config;
            _personRepository = new PersonRepository(_config["ConnectionStrings:MSSQLconnection"]);
        }

        // POST api/person
        [HttpPost]
        public async Task<ActionResult<int>> CreatePerson([FromBody] PersonDto newPersonDto)
        {
            return Ok(await _personRepository.CreatePersonAsync(newPersonDto.FromDto(), newPersonDto.HashPassword));
        }

        // POST api/artist
        [HttpPost]
        [Route("artist")]
        public async Task<ActionResult<int>> CreateArtist([FromBody] ArtistDto newArtistDto)
        {
            return Ok(await _personRepository.CreateArtistAsync(newArtistDto.FromDto(), newArtistDto.HashPassword));
        }

        [HttpGet]
        [Route("isArtist/{id}")]
        public async Task<ActionResult<bool>> IsArtistAsync(int id)
        {
            return Ok(await _personRepository.IsArtist(id));
        }
    }
}
