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
        private PersonRepository _personRepository;
        private string _password = "TestPassword";

        [SetUp]
        public async Task Setup()
        {
            _personRepository = new PersonRepository(Configuration.CONNECTION_STRING);
            await CreateNewPerson();
        }

        [TearDown]
        public async Task CleanUp()
        {
            await _personRepository.DeletePersonAsync(_newPerson.Id);
        }

        private async Task<Person> CreateNewPerson()
        {
            Address a = new Address() { Street = "Dannebrogsgade", HouseNumber = "13", Zipcode = 9000, City = "Aalborg", Country = "Denmark" };
            _newPerson = new Person() {FirstName="Laco", LastName = "Cobolski",Email="laco@slovak.sk",PhoneNumber = "123456" ,Address = a};
            _newPerson.Id = await _personRepository.CreatePersonAsync(_newPerson, _password);
            return _newPerson;
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
            var loginWithNewPasswordOk = _personRepository.Login(_newPerson.Email, newPassword);
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
    }
}
