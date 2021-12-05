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
        public async Task Setup()
        {
            _personRepository = new PersonRepository(Configuration.CONNECTION_STRING);
            await CreateNewPerson();
            await CreateNewArtist();
        }

        

        private async Task<Person> CreateNewPerson()
        {
            Address a = new Address() {Street = "Dannebrogsgade", HouseNumber = "13", Zipcode = "9000", City = "Aalborg", Country = "Denmark"};
            _newPerson = new Person() {FirstName="Laco", LastName = "Cobolski",Email="laco@slovak.sk",PhoneNumber = "123456" ,Address = a};
            _newPerson.Id = await _personRepository.CreatePersonAsync(_newPerson, _password);
            return _newPerson;
        }

        private async Task<Artist> CreateNewArtist()
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
            Assert.IsTrue(_newPerson.Id > 0, "Created author ID not returned");
        }

        [Test]
        public async Task GettingPersonWithSpecificId()
        {
            //Arrange
            //Act
            Person person = await _personRepository.GetPersonByIdAsync(87);

            //Assert
            Assert.NotNull(person, "Person with ID 87 was not found");
        }

        [Test]
        public async Task UpdatePersonPasswordAndLoginAsync()
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
