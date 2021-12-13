 using DataAccess.Repositories;
using Gallaria.API.Converters;
using Gallaria.API.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace Gallaria.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : Controller
    {
        
        IPersonRepository _personRepository;

        public PersonController(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
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
            return Ok(await _personRepository.IsArtistAsync(id));
        }

        // GET api/<PersonController>/id
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonDto>> Get(int id)
        {
            var person = await _personRepository.GetPersonByIdAsync(id);
            if (person == null) { return NotFound(); }
            else { return Ok(person); }
        }

        [HttpGet("getArtist/{id}")]
        public async Task<ActionResult<ArtistDto>> GetArtistAsync(int id)
        {
            var artist = await _personRepository.GetArtistByIdAsync(id);
            if (artist == null) { return NotFound(); }
            else { return Ok(artist); }
        }

        [HttpDelete]
        [Route("deleteArtist/{id}")]
        public async Task<ActionResult> DeleteArtistAsync(int id)
        {
            bool result = await _personRepository.DeleteArtistAsync(id);
            if (result)
            {
                return Ok();
            }

            return NotFound();
        }

        [HttpDelete]
        [Route("deletePerson/{id}")]
        public async Task<ActionResult> DeletePersonAsync(int id)
        {
            bool result = await _personRepository.DeletePersonAsync(id);
            if (result)
            {
                return Ok();
            }

            return NotFound();
        }
    }
}
