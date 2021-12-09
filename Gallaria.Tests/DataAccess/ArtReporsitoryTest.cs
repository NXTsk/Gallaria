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
        private Art _newArt;

        [SetUp]
        public async Task Setup()
        {
            _artRepository = new ArtRepository(Configuration.CONNECTION_STRING);
            await CreateNewArt();
        }

        private async Task<Art> CreateNewArt()
        {
            byte[] bytes = System.IO.File.ReadAllBytes("../../../testImages/11.jpg");
            _newArt = new Art() { AuthorId = 152, Title = "New art", Description = "hello", Image = bytes, Price = 10, AvailableQuantity = 20, Category = "Nature", CreationDate= new DateTime(2021,11,20)};
            _newArt.Id = await _artRepository.CreateArtAsync(_newArt);

            return _newArt;
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
            //Arragne
            //Act
            Art art = await _artRepository.GetArtByIDAsync(33);

            //Assert
            Assert.NotNull(art, "Art with ID 33 was not found");
            Assert.IsTrue(art.Id == 33, $"Actual ID of art was {art.Id} not 33");
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

            _newArt.Title = updatedTitle;
            _newArt.Description = updatedDescription;
            _newArt.Price = updatedPrice;
            _newArt.Category = updatedCategory;

            //Act 
            await _artRepository.UpdateArtAsync(_newArt);

            //Assert
            var refoundArt = await _artRepository.GetArtByIDAsync(_newArt.Id);
            Assert.IsTrue(refoundArt.Title == updatedTitle && refoundArt.Price == updatedPrice && refoundArt.Description == updatedDescription && refoundArt.Category == updatedCategory, "Art was not deleted");
        }


        [TearDown]
        public async Task CleanUp()
        { 
            await _artRepository.DeleteArtAsync(_newArt.Id);
        }
    }
}
