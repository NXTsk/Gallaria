 using DataAccess.Model;
using DataAccess.Repositories;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gallaria.Tests.DataAccess
{
    class ArtReporsitoryTest
    {
        private IArtRepository _artRepository;
        private IPersonRepository _personRepository;
        private Art _newArt;
        private Artist _newArtist;
        private string _testPassword = "123";

        [SetUp]
        public async Task Setup()
        {
            _artRepository = new ArtRepository(Configuration.CONNECTION_STRING);
            _personRepository = new PersonRepository(Configuration.CONNECTION_STRING);
            await CreateNewArtistAsync();
            await CreateNewArtAsync();
        }

        private async Task<Art> CreateNewArtAsync()
        {
            byte[] bytes = System.IO.File.ReadAllBytes("../../../testImages/11.jpg");
            _newArt = new Art() { AuthorId = _newArtist.Id, Title = "New art", Description = "hello", Image = bytes, Price = 10, AvailableQuantity = 20, Category = "Nature", CreationDate= new DateTime(2021,11,20)};
            _newArt.Id = await _artRepository.CreateArtAsync(_newArt);

            return _newArt;
        }

        private async Task<Artist> CreateNewArtistAsync()
        {
            Address a = new Address() { Street = "Nibevej", HouseNumber = "12", Zipcode = "9200", City = "Aalborg", Country = "Denmark" };
            _newArtist = new Artist() { FirstName = "Petronela", LastName = "Lakatosova", Email = "petronela@slovak.sk", PhoneNumber = "123123", Address = a, ProfileDescription = "I am a digital artist." };
            _newArtist.ArtistId = await _personRepository.CreateArtistAsync(_newArtist, _testPassword);

            return _newArtist;
        }

        [Test]
        public void CreateArt()
        {
            //Arrange & Act is done in Setup()
            //Assert
            Assert.IsTrue(_newArt.Id > 0, "Art was not created");
        }

        [Test]
        public async Task GettingArtBySpecificIdReturnArt()
        {
            //Arrange
            //Act
            Art art = await _artRepository.GetArtByIDAsync(_newArt.Id);

            //Assert
            Assert.NotNull(art, "Art with ID 33 was not found");
            Assert.IsTrue(art.Id == _newArt.Id, $"Actual ID of art was {art.Id} not {_newArt.Id}");
        }

        [Test]
        public async Task GettingAllArtsReturnsListOfArt()
        {
            //Arrange
            //Act
            IEnumerable<Art> arts = await _artRepository.GetAllArtsAsync();

            //Assert
            Assert.NotNull(arts.Any(), "List of arts is 0");
        }

        [Test]
        public async Task GettingAllArtsByAuthorIdReturnsListOfArt()
        {
            //Arrange is done in Setup()
            //Act
            IEnumerable<Art> arts = await _artRepository.GetAllArtsThatByAuthorIdAsync(_newArtist.Id);

            //Assert
            Assert.NotNull(arts.Any(), "List of arts is 0");
        }

        [Test]
        public async Task DeleteArt()
        {
            //Arrange is done in Setup()
            //Act 
            bool deleted = await _artRepository.DeleteArtAsync(_newArt.Id);

            //Assert
            Assert.IsTrue(deleted, "Art was not deleted");
        }

        [Test]
        public async Task UpdateArtWithSpecificId()
        {
            //Arrange
            string updatedTitle = "New updated art";
            decimal updatedPrice = 15;
            string updatedDescription = "hello updated art";
            string updatedCategory = "Abstract";
            int updatedQuantity = 10;

            _newArt.Title = updatedTitle;
            _newArt.Description = updatedDescription;
            _newArt.Price = updatedPrice;
            _newArt.Category = updatedCategory;

            //Act 
            await _artRepository.UpdateArtAsync(_newArt);
            await _artRepository.UpdateArtQuantityById(_newArt.Id, updatedQuantity);

            //Assert
            var refoundArt = await _artRepository.GetArtByIDAsync(_newArt.Id);
            Assert.IsTrue(refoundArt.Title == updatedTitle && refoundArt.Price == updatedPrice && refoundArt.Description == updatedDescription && refoundArt.Category == updatedCategory && refoundArt.AvailableQuantity == updatedQuantity, "Art was not updated");
        }

        [TearDown]
        public async Task CleanUp()
        {
            await _artRepository.DeleteArtAsync(_newArt.Id);
            await _personRepository.DeleteArtistAsync(_newArtist.Id);
            await _personRepository.DeletePersonAsync(_newArtist.Id);
        }
    }
}
