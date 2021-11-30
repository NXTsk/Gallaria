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
        private PersonRepository _personRepository;
        private string _password = "TestPassword";

        [SetUp]
        public async Task Setup()
        {
            _personRepository = new PersonRepository(Configuration.CONNECTION_STRING);
            await CreateNewPerson();
            await CreateNewArtist();
        }

        [TearDown]
        public async Task CleanUp()
        {
            await _personRepository.DeletePersonAsync(_newPerson.Id);

            await _personRepository.DeleteArtistAsync(_newArtist.ArtistId);
            await _personRepository.DeletePersonAsync(_newArtist.Id);
        }

        private async Task<Person> CreateNewPerson()
        {
            Address a = new Address() { Street = "Dannebrogsgade", HouseNumber = "13", Zipcode = "9000", City = "Aalborg", Country = "Denmark" };
            _newPerson = new Person() {FirstName="Laco", LastName = "Cobolski",Email="laco@slovak.sk",PhoneNumber = "123456" ,Address = a};
            _newPerson.Id = await _personRepository.CreatePersonAsync(_newPerson, _password);
            return _newPerson;
        }

        private async Task<Artist> CreateNewArtist()
        {
            Address a = new Address() { Street = "Nibevej", HouseNumber = "12", Zipcode = "9200", City = "Aalborg", Country = "Denmark" };
            _newArtist = new Artist() { FirstName = "Petronela", LastName = "Lakatosova", Email = "petronela@slovak.sk", PhoneNumber = "123123", Address = a, ProfileDescription = "I am a digital artist." };
            _newArtist.ArtistId = await _personRepository.CreateArtistAsync(_newArtist, _password);

            return _newArtist;
        }

        [Test]
        public void CreatePerson()
        {
            //ARRANGE & ACT is done in Setup()

            //ASSERT  
            Assert.IsTrue(_newPerson.Id > 0, "Created author ID not returned");
        }

        [Test]
        public async Task UpdatePersonPasswordAndLoginAsync()
        {
            //ARRANGE
            var newPassword = "TestNewPassword";

            //ACT
            var updateSuccess = await _personRepository.UpdatePasswordAsync(_newPerson.Email, _password, newPassword);

            //ASSERT
            var loginWithNewPasswordOk = await _personRepository.LoginAsync(_newPerson.Email, newPassword);
            Assert.IsTrue(updateSuccess, "Person not updated");
            Assert.IsTrue(loginWithNewPasswordOk > 0, "Unable to login with Person's updated password");
        }

        [Test]
        public async Task DeletePerson()
        {
            //ARRANGE is done in Setup()

            //ACT 
            bool deleted = await _personRepository.DeletePersonAsync(_newPerson.Id);

            //ASSERT
            Assert.IsTrue(deleted, "Person not deleted");
        }

        [Test]
        public void CreateArtist()
        {
            //ARRANGE & ACT is done in Setup()

            //ASSERT
            Assert.IsTrue(_newArtist.Id > 0, "Created artist ID not returned");
        }

        [Test]
        public async Task DeleteArtist()
        {
            //ARRANGE is done in Setup()

            //ACT 
            bool deleted = await _personRepository.DeleteArtistAsync(_newArtist.ArtistId);

            //ASSERT
            Assert.IsTrue(deleted, "Artist not deleted");
        }
    }
}
