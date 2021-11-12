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
        public void Setup()
        {
            _personRepository = new PersonRepository(Configuration.CONNECTION_STRING);
            CreateNewPersonAsync();
        }

        //[TearDown]
        //public void CleanUp()
        //{
        //    _personRepository.DeleteAsync(_newPerson.Id);
        //}

        private Person CreateNewPersonAsync()
        {
            Address a = new Address() { Street = "Dannebrogsgade", HouseNumber = "13", Zipcode = 9000, City = "Aalborg", Country = "Denmark" };
            _newPerson = new Person() {FirstName="Laco", LastName = "Cobolski",Email="laco@slovak.sk",PhoneNumber = "123456" ,Address = a};
            _newPerson.Id =  _personRepository.CreatePerson(_newPerson, _password);
            return _newPerson;
        }

        [Test]
        public void CreatePerson()
        {
            //ARRANGE & ACT is done in Setup()
            //ASSERT
            
            Assert.IsTrue(_newPerson.Id > 0, "Created author ID not returned");
        }
    }
}
