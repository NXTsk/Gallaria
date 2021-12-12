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
    class PersonClientTest
    {
        private IPersonClient _personClient;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {

            _personClient = new PersonClient(Configuration.API_URL);
        }

        [Test]
        public async Task TestCreatePerson()
        {
            //Arrange
            PersonDto personToCreate = new()
            {
                Email = "dandapanda@seznam.cz",
                FirstName = "Danda",
                LastName = "Panda",
                HashPassword = "123456789",
                ConfirmPassword = "123456789",
                PhoneNumber = "50689874",
                Address = new() { City = "Aarhus", Country = "Denmark", HouseNumber = "145", Street = "Danstrosgade", Zipcode = "96500" }
            };

            //Act
            int actualId = await _personClient.CreatePersonAsync(personToCreate);

            //Assert
            Assert.IsTrue(actualId > 0, $"Failed to create person with name: {personToCreate.FirstName} {personToCreate.LastName}!");
        }

        [Test]
        public async Task TestCreateArtist()
        {
            //Arrange
            ArtistDto artistToCreate = new()
            {
                Email = "galantniadam@gmail.com",
                FirstName = "Adam",
                LastName = "Galantni",
                HashPassword = "123456789",
                ConfirmPassword = "123456789",
                PhoneNumber = "68598487",
                ProfileDescription = "I am the king in a north.",
                Address = new() { City = "Copenhagen", Country = "Denmark", HouseNumber = "154", Street = "Slotsgade", Zipcode = "84536" }
            };

            //Act
            int actualId = await _personClient.CreateArtistAsync(artistToCreate);

            //Assert
            Assert.IsTrue(actualId > 0, $"Failed to create person with name: {artistToCreate.FirstName} {artistToCreate.LastName}!");
        }

        [Test]
        public async Task TestIsArtist()
        {
            //Arrange - artist ID
            int id = 152;
            //Act
            bool isArtist = await _personClient.IsArtistAsync(id);

            //TODO: Assert
            Assert.IsTrue(isArtist, $"The person with id: {id} is not an artist.");
        }

        [Test]
        public async Task TestGetPersonById()
        {
            //Arrange
            int id = 152;
            //Act
            PersonDto personDto = await _personClient.GetPersonByIdAsync(id);

            //TODO: Assert

            Assert.AreEqual(id, personDto.Id, $"Recieved person wasn't with id {id}");
        }
    }
}
