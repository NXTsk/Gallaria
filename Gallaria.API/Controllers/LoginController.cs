using DataAccess.Repositories;
using Gallaria.API.Model;
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
    public class LoginController : Controller
    {
        IConfiguration _config;
        IPersonRepository personRepository;

        public LoginController(IConfiguration config)
        {
            _config = config;
            personRepository = new PersonRepository(_config["ConnectionStrings:MSSQLconnection"]);
        }


        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            int userId = personRepository.Login(model.Email, model.Password);

            if(userId == -1)
            {
                // User isn't authenticated
                return Unauthorized();
            }
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Issuer"],
                expires: DateTime.Now.AddDays(5),
                signingCredentials: new Microsoft.IdentityModel.Tokens.SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );
            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = token.ValidTo
            });

        }
    }
}
