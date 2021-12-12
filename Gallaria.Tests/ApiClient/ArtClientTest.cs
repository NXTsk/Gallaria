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
    class ArtClientTest
    {
        private IArtClient _artClient;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _artClient = new ArtClient(Configuration.API_URL);
        }

        [Test]
        public async Task TestCreateArt()
        {
            //Arrange
            ArtDto artToCreate = new()
            {
                AuthorId = 152,
                ArtistName = "Denisa",
                Title = "The best piece of art",
                Description = "This is most certainly the best piece of art you can ever see.",
                AvailableQuantity = 1,
                Category = "Anime",
                CreationDate = DateTime.Now,
                Price = 20000,
                Image = System.IO.File.ReadAllBytes("../../../testImages/11.jpg")
        };

            //Act
            int actualId = await _artClient.CreateArtAsync(artToCreate);

            //Assert
            Assert.IsTrue(actualId > 0, $"Failed to create art from artist with id: {artToCreate.AuthorId} and description: {artToCreate.Description}!");
        }

        [Test]
        public async Task TestGetArtByID()
        {
            //Arrange
            int id = 30; 

            //Act
            ArtDto artDto = await _artClient.GetArtByIDAsync(id);

            //Assert
            Assert.AreEqual(id, artDto.Id, $"Failed to retrieve art with id: {id}!");
        }

        [Test]
        public async Task TestGetAllArtsAsync()
        {
            //Arrange
            //Act
            IEnumerable<ArtDto> arts = await _artClient.GetAllArtsAsync();

            //Assert
            Assert.NotNull(arts.Any(), "List of arts is 0");
        }

        [TearDown]
        public async Task CleanUp()
        {
            await _artRepository.DeleteArtAsync(_newArt.Id);
        }
    }
}
