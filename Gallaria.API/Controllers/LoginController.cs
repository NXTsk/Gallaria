using DataAccess.Repositories;
using Gallaria.API.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Gallaria.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        IConfiguration _config;
        IPersonRepository _personRepository;

        public LoginController(IConfiguration config, IPersonRepository personRepository)
        {
            _config = config;
            _personRepository = personRepository;
        }


        [HttpPost]
        public async Task<IActionResult> LoginAsync([FromBody] LoginModel model)
        {
            int userId = await _personRepository.LoginAsync(model.Email, model.Password);

            if(userId == -1)
            {
                // User isn't authenticated
                return Unauthorized();
            }

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtInfo:Key"]));
            var token = new JwtSecurityToken(
                issuer: _config["JwtInfo:Issuer"],
                audience: _config["JwtInfo:Audience"],
                expires: DateTime.Now.AddDays(5),
                signingCredentials: new Microsoft.IdentityModel.Tokens.SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );
            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = token.ValidTo,
                userId = userId
            });
        }
    }
}
