using DataAccess.Repositories;
using Gallaria.API.DTOs;
using Gallaria.API.Converters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Model;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Gallaria.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtController : Controller
    {
        IArtRepository _artRepository;

        public ArtController(IArtRepository artRepository)
        {
            _artRepository = artRepository;
        }

        // GET: api/<ArtController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArtDto>>> GetAllAsync()
        {
            IEnumerable<Art> arts;
            arts = await _artRepository.GetAllArtsAsync();
            return Ok(arts.ToDtos());
        }

        // GET: api/<ArtController>
        [HttpGet]
        [Route("artistArts/{authorId}")]
        public async Task<ActionResult<IEnumerable<ArtDto>>> GetAllArtsThatByAuthorIdAsync(int authorId)
        {
            IEnumerable<Art> arts;
            arts = await _artRepository.GetAllArtsThatByAuthorIdAsync(authorId);
            return Ok(arts.ToDtos());
        }

        // GET: api/<ArtController>
        [HttpGet]
        [Route("available")]
        public async Task<ActionResult<IEnumerable<ArtDto>>> GetAllAvailableAsync()
        {
            IEnumerable<Art> arts;
            arts = await _artRepository.GetAllAvailableArtsAsync();
            return Ok(arts.ToDtos());
        }

        // GET api/<ArtController>/50
        [HttpGet("{id}")]
        public async Task<ActionResult<ArtDto>> Get(int id)
        {
            var art = await _artRepository.GetArtByIDAsync(id);
            if (art == null) { return NotFound(); }
            else { return Ok(art); }
        }

        // POST api/<ArtController>
        [HttpPost]
        public async Task<ActionResult<int>> CreateArtAsync([FromBody] ArtDto newArtDto)
        {
            return Ok(await _artRepository.CreateArtAsync(newArtDto.FromDto()));
        }

        // PUT api/<ArtController>/35
        [HttpPut]
        public async Task<ActionResult<bool>> UpdateArtAsync([FromBody] ArtDto artDtoToUpdate)
        {
            bool wasUpdated = await _artRepository.UpdateArtAsync(artDtoToUpdate.FromDto());

            if (wasUpdated) 
            {
                return Ok(); 
            }
            return NotFound(); 
        }

        // DELETE api/<ArtController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
