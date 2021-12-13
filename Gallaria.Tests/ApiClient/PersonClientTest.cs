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

        private ArtistDto artist;
        private PersonDto person;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _personClient = new PersonClient(Configuration.API_URL);
        }

        [SetUp]
        public async Task SetUp()
        {
            await CreatePersonAsync();
            await CreateArtistAsync();
        }

        public async Task CreatePersonAsync()
        {
            person = new()
            {
                Email = "dandapanda@seznam.cz",
                FirstName = "Danda",
                LastName = "Panda",
                HashPassword = "123456789",
                PhoneNumber = "50689874",
                Address = new() { City = "Aarhus", Country = "Denmark", HouseNumber = "145", Street = "Danstrosgade", Zipcode = "96500" }
            };
            person.Id = await _personClient.CreatePersonAsync(person);
        }

        public async Task CreateArtistAsync()
        {
            artist = new()
            {
                Email = "galantniadam@gmail.com",
                FirstName = "Adam",
                LastName = "Galantni",
                HashPassword = "123456789",
                PhoneNumber = "68598487",
                ProfileDescription = "I am the king in a north.",
                Address = new() { City = "Copenhagen", Country = "Denmark", HouseNumber = "154", Street = "Slotsgade", Zipcode = "84536" }
            };

            artist.Id = await _personClient.CreateArtistAsync(artist);
        }

        [Test]
        public async Task TestCreatePerson()
        {
            //Arrange & Act is done in Setup()
            //Assert
            Assert.IsTrue(person.Id > 0, $"Failed to create person with name: {person.FirstName} {person.LastName}!");
        }

        [Test]
        public async Task TestCreateArtist()
        {
            //Arrange & Act is done in Setup()
            //Assert
            Assert.IsTrue(artist.Id > 0, $"Failed to create person with name: {artist.FirstName} {artist.LastName}!");
        }

        [Test]
        public async Task TestIfPersonWasUpdated()
        {
            //Arrange
            string updatedFirstName = "Martin";
            string updatedLastName = "Vláčil";
            string updatedEmail = "martinvlacil@gmail.com";
            string updatedPhoneNumber = "5012312310";
            string updatedStreet = "Dannebrogsgade";
            string updatedHouseNumber = "13";
            string updatedZipcode = "9000";
            string updatedCity = "Aalborg";
            string updatedCountry = "Denmark";

            person.FirstName = updatedFirstName;
            person.LastName = updatedLastName;
            person.Email = updatedEmail;
            person.PhoneNumber = updatedPhoneNumber;
            person.Address.Street = updatedStreet;
            person.Address.HouseNumber = updatedHouseNumber;
            person.Address.Zipcode = updatedZipcode;
            person.Address.City = updatedCity;
            person.Address.Country = updatedCountry;

            //Act
            bool wasUpdated = await _personClient.UpdatePersonAsync(person);

            //Assert
            Assert.IsTrue(wasUpdated, "Person was not updated");
        }

        [Test]
        public async Task TestIfArtistWasUpdated()
        {
            //Arrange
            string updatedProfileDescription = "My profile description is the best!";

            artist.ProfileDescription = updatedProfileDescription;

            //Act
            bool wasUpdated = await _personClient.UpdateArtistAsync(artist);

            //Assert
            Assert.IsTrue(wasUpdated, "Artist was not updated");
        }

        [Test]
        public async Task TestIfPasswordWasUpdated()
        {
            //Arrange
            string newPassword = "123456";

            person.NewPassword = newPassword;

            //Act
            bool wasUpdated = await _personClient.UpdatePasswordAsync(person);

            //Assert
            Assert.IsTrue(wasUpdated, "Password was not updated");
            //Assert.IsTrue(person.HashPassword == newPassword, "Passwords don't match so password was not updated");
        }

        [Test]
        public async Task TestIsArtist()
        {
            //Arrange - artist ID
            int id = artist.Id;

            //Act
            bool isArtist = await _personClient.IsArtistAsync(id);

            //Assert
            Assert.IsTrue(isArtist, $"The person with id: {id} is not an artist.");
        }

        [Test]
        public async Task TestGetPersonById()
        {
            //Arrange
            int id = person.Id;

            //Act
            PersonDto personDto = await _personClient.GetPersonByIdAsync(id);

            //Assert
            Assert.AreEqual(id, personDto.Id, $"Recieved person wasn't with id {id}");
        }

        [TearDown]
        public async Task CleanUp()
        {
            await _personClient.DeleteArtistAsync(artist.Id);
            await _personClient.DeletePersonAsync(artist.Id);
            await _personClient.DeletePersonAsync(person.Id);
        }
    }
}
