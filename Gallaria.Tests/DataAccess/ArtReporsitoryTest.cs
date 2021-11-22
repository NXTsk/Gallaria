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
        private Art _newArt;
        private ArtRepository _artRepository;

        [SetUp]
        public async Task Setup()
        {
            _artRepository = new ArtRepository(Configuration.CONNECTION_STRING);
            await CreateNewArt();
        }

        [TearDown]
        public async Task CleanUp()
        {
           // await _artRepository.DeleteArtAsync(_newArt.Id);
        }

        private async Task<Art> CreateNewArt()
        {
            byte[] bytes = System.IO.File.ReadAllBytes("C:/Users/Zythaar/Desktop/11.jpg");
            _newArt = new Art() { AuthorName = "Laco Cobolski", Title = "New art", Description = "hello", Image = bytes, Price = 10, AvailableQuantity = 20, Category = "Nature", CreationDate= new DateTime(2021,11,20)};
            _newArt.Id = await _artRepository.CreateArtAsync(_newArt);
            return _newArt;
        }
        [Test]
        public void CreateArt()
        {
            //ARRANGE & ACT is done in Setup()
            //ASSERT

            Assert.IsTrue(_newArt.Id > 0, "Created art ID not returned");
        }
    }
}
