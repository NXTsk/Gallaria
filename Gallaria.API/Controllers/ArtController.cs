using DataAccess.Repositories;
using Gallaria.API.Model;
using Gallaria.API.Converters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Gallaria.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtController : Controller
    {
        IConfiguration _config;
        IArtRepository _artRepository;

        public ArtController(IConfiguration config)
        {
            _config = config;
            _artRepository = new ArtRepository(_config["ConnectionStrings:MSSQLconnection"]);
        }

        // GET: api/<ArtController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ArtController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ArtController>
        [HttpPost]
        public async Task<ActionResult<int>> CreateArtAsync([FromBody] ArtDto newArtDto)
        {
            newArtDto.Image = System.IO.File.ReadAllBytes("C:/Users/Zythaar/Desktop/11.jpg");
            return Ok(await _artRepository.CreateArtAsync(newArtDto.FromDto()));
        }

        // PUT api/<ArtController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ArtController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
