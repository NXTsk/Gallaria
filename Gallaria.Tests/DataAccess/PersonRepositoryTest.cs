using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Model;
using DataAccess.Repositories;

namespace Gallaria.Tests.DataAccess
{
    class PersonRepositoryTest
    {
        private Person _newPerson;
        private Artist _newArtist;
        private IPersonRepository _personRepository;
        private string _password = "TestPassword";

        [SetUp]
        public async Task SetupAsync()
        {
            _personRepository = new PersonRepository(Configuration.CONNECTION_STRING);
            await CreateNewPersonAsync();
            await CreateNewArtistAsync();
        }

        private async Task<Person> CreateNewPersonAsync()
        {
            Address a = new Address() {Street = "Dannebrogsgade", HouseNumber = "13", Zipcode = "9000", City = "Aalborg", Country = "Denmark"};
            _newPerson = new Person() {FirstName="Laco", LastName = "Cobolski",Email="laco@slovak.sk",PhoneNumber = "123456" ,Address = a};
            _newPerson.Id = await _personRepository.CreatePersonAsync(_newPerson, _password);
            return _newPerson;
        }

        private async Task<Artist> CreateNewArtistAsync()
        {
            Address a = new Address() {Street = "Nibevej", HouseNumber = "12", Zipcode = "9200", City = "Aalborg", Country = "Denmark"};
            _newArtist = new Artist() {FirstName = "Petronela", LastName = "Lakatosova", Email = "petronela@slovak.sk", PhoneNumber = "123123", Address = a, ProfileDescription = "I am a digital artist."};
            _newArtist.ArtistId = await _personRepository.CreateArtistAsync(_newArtist, _password);

            return _newArtist;
        }

        [Test]
        public void CreatePerson()
        {
            //Arrange & Act is done in Setup()
            //Assert
            Assert.IsTrue(_newPerson.Id > 0, "Created person ID not returned");
        }

        [Test]
        public async Task GettingPersonWithSpecificId()
        {
            //Arrange
            //Act
            Person person = await _personRepository.GetPersonByIdAsync(_newPerson.Id);

            //Assert
            Assert.NotNull(person, $"Person with ID {_newPerson.Id} was not found");
        }

        [Test]
        public async Task UpdatePersonWithSpecificId()
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

            _newPerson.FirstName = updatedFirstName;
            _newPerson.LastName = updatedLastName;
            _newPerson.Email = updatedEmail;
            _newPerson.PhoneNumber = updatedPhoneNumber;
            _newPerson.Address.Street = updatedStreet;
            _newPerson.Address.HouseNumber = updatedHouseNumber;
            _newPerson.Address.Zipcode = updatedZipcode;
            _newPerson.Address.City = updatedCity;
            _newPerson.Address.Country = updatedCountry;
            
            //Act 
            await _personRepository.UpdatePersonAsync(_newPerson);

            //Assert
            var refoundPerson = await _personRepository.GetPersonByIdAsync(_newPerson.Id);
            Assert.IsTrue(refoundPerson.FirstName == updatedFirstName && refoundPerson.LastName == refoundPerson.LastName 
                && refoundPerson.Email == updatedEmail && refoundPerson.PhoneNumber == updatedPhoneNumber 
                && refoundPerson.Address.Street == updatedStreet && refoundPerson.Address.HouseNumber == updatedHouseNumber 
                && refoundPerson.Address.Zipcode == updatedZipcode && refoundPerson.Address.City == updatedCity 
                && refoundPerson.Address.Country == updatedCountry, "Person was not updated");
        }

        [Test]
        public async Task UpdateArtistWithSpecificId()
        {
            //Arrange
            string updatedProfileDescription = "My profile description is the best!";

            _newArtist.ProfileDescription = updatedProfileDescription;

            //Act 
            await _personRepository.UpdateArtistAsync(_newArtist);

            //Assert
            var refoundPerson = await _personRepository.GetArtistByIdAsync(_newArtist.Id);
            Assert.IsTrue(refoundPerson.ProfileDescription == updatedProfileDescription, "Artist was not updated");
        }

        [Test]
        public async Task UpdatePersonPasswordAndLogin()
        {
            //Arrange
            var newPassword = "TestNewPassword";

            //Act
            var updateSuccess = await _personRepository.UpdatePasswordAsync(_newPerson.Email, _password, newPassword);

            //Assert
            var loginWithNewPasswordOk = await _personRepository.LoginAsync(_newPerson.Email, newPassword);
            Assert.IsTrue(updateSuccess, "Person not updated");
            Assert.IsTrue(loginWithNewPasswordOk > 0, "Unable to login with Person's updated password");
        }

        [Test]
        public async Task DeletePerson()
        {
            //Arrange is done in Setup()
            //Act
            bool deleted = await _personRepository.DeletePersonAsync(_newPerson.Id);

            //Assert
            Assert.IsTrue(deleted, "Person not deleted");
        }

        [Test]
        public void CreateArtist()
        {
            //Arrange & Act is done in Setup()
            //Assert
            Assert.IsTrue(_newArtist.Id > 0, "Created artist ID not returned");
        }

        [Test]
        public async Task DeleteArtist()
        {
            //Arrange is done in Setup()
            //Act
            bool deleted = await _personRepository.DeleteArtistAsync(_newArtist.ArtistId);

            //Assert
            Assert.IsTrue(deleted, "Artist not deleted");
        }

        [Test]
        public async Task CheckIfPeronIsArtist()
        {
            //Arrange is done in Setup()
            //Act 
            bool isArtist = await _personRepository.IsArtistAsync(_newArtist.Id);

            //Assert 
            Assert.IsTrue(isArtist, $"Person with{_newArtist.Id} is not an artist");
        }

        [TearDown]
        public async Task CleanUp()
        {
            await _personRepository.DeletePersonAsync(_newPerson.Id);
            await _personRepository.DeleteArtistAsync(_newArtist.ArtistId);
            await _personRepository.DeletePersonAsync(_newArtist.Id);
        }
    }
}
