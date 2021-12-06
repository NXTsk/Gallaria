using Gallaria.ApiClient;
using Gallaria.ApiClient.DTOs;
using Gallaria.ApiClient.Interfaces;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gallaria.Tests.ApiClient
{
    class AuthenticateClientTest
    {
        private IAuthenticateClient _authenticateClient;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _authenticateClient = new AuthenticateClient(Configuration.API_URL);
        }

        [Test]
        public async Task TestLoginPerson()
        {
            //Arrange
            UserDto userDto = new() { Email = "denisacreative@gmail.com", Password = "1234567" };

            //Act
            AuthUserDto authUserDto = await _authenticateClient.LoginAsync(userDto);

            //Assert
            Assert.IsTrue(authUserDto.isUserAuthenticated, $"Failed to login as a person with an email: {userDto.Email}!");
        }
    }
}
