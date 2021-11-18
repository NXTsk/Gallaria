using DataAccess.Repositories;
using Gallaria.API.Converters;
using Gallaria.API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
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

        // POST api/persons
        [HttpPost]
        public async Task<ActionResult<int>> CreatePerson([FromBody] PersonDto newPersonDto)
        {
            return Ok(await _personRepository.CreatePersonAsync(newPersonDto.FromDto(), newPersonDto.HashPassword));
        }
    }
}
