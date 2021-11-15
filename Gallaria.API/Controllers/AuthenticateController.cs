using Gallaria.API.Model;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gallaria.API.Controllers
{
    public class AuthenticateController : BaseController
    {
        private IConfiguration _config;
        public AuthenticateController(IConfiguration config)
        {
            _config = config;
        }

        private string GenerateJSONWebToken(LoginModel userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              null,
              expires: DateTime.Now.AddMinutes(d),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        

        // This method is only for accessing the DataAccess and retrieving the existing user
        private async Task<LoginModel> AuthenticateUser(LoginModel login)
        {
            LoginModel user = null;

            //Validate the User Credentials         
            //TODO: Connect with DataAccess layer
            if (login.UserName == "Jay")
            {
                user = new LoginModel { UserName = "Jay", Password = "123456" };
            }
            return user;
        }


        [AllowAnonymous]
        [HttpPost(nameof(Login))]
        public async Task<IActionResult> Login([FromBody] LoginModel data)
        {
            IActionResult response = Unauthorized();
            var user = await AuthenticateUser(data);
            if (data != null)
            {
                var tokenString = GenerateJSONWebToken(user);
                response = Ok(new { Token = tokenString, Message = "Success" });
            }
            return response;
        }


        [HttpGet(nameof(Get))]
        public async Task<IEnumerable<string>> Get()
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");

            return new string[] { accessToken };
        }
    }
}
