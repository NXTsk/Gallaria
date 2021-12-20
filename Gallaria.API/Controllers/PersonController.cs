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

        // PUT api/<PersonController>/updatePerson
        [HttpPut]
        [Route("updatePerson")]
        public async Task<ActionResult<bool>> UpdatePersonAsync([FromBody] PersonDto personDtoToUpdate)
        {
            bool wasUpdated = await _personRepository.UpdatePersonAsync(personDtoToUpdate.FromDto());

            if (wasUpdated)
            {
                return Ok();
            }
            return NotFound();
        }

        // PUT api/<PersonController>/updateArtist
        [HttpPut]
        [Route("updateArtist")]
        public async Task<ActionResult<bool>> UpdateArtistAsync([FromBody] ArtistDto artistDtoToUpdate)
        {
            bool wasUpdated = await _personRepository.UpdateArtistAsync(artistDtoToUpdate.FromDto());

            if (wasUpdated)
            {
                return Ok();
            }
            return NotFound();
        }

        [HttpPut]
        [Route("password")]
        public async Task<ActionResult<bool>> UpdatePasswordAsync([FromBody] PersonDto personDto)
        {
            bool wasUpdated = await _personRepository.UpdatePasswordAsync(personDto.Email, personDto.HashPassword, personDto.NewPassword);

            if (wasUpdated)
            {
                return Ok();
            }
            return NotFound();
        }

        // GET api/<PersonController>/id
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonDto>> Get(int id)
        {
            var person = await _personRepository.GetPersonByIdAsync(id);
            if (person == null) { return NotFound(); }
            else 
            { 
                return Ok(person); 
            }
        }

        [HttpGet("getArtist/{id}")]
        public async Task<ActionResult<ArtistDto>> GetArtistAsync(int id)
        {
            var artist = await _personRepository.GetArtistByIdAsync(id);
            if (artist == null) { return NotFound(); }
            else 
            { 
                return Ok(artist);
            }
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
