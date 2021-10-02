using Cat.Web.Models;
using Cat.Web.Services;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Cat.Tests
{
    public class CatServiceTest
    {
        [Fact]
        public async Task GetBreeds()
        {
            //arrange
            var breedList = new List<BreedModel>() {new BreedModel() {Name = "b1"}, new BreedModel() {Name = "b2"}};

            var catService = new Mock<ICatService>();
            catService.Setup(x => x.GetBreeds()).ReturnsAsync(() => breedList);

            //act
            var breeds = await catService.Object.GetBreeds();

            //assert
            Assert.NotNull(breeds);
            Assert.True(breeds.Count == 2);
        }

        [Fact]
        public async Task SearchBreed()
        {
            //arrange
            var breedList = new List<BreedModel>() {new BreedModel() {Name = "b1"}, new BreedModel() {Name = "b2"}};

            var catService = new Mock<ICatService>();
            catService.Setup(x => x.SearchBreed(It.IsAny<string>())).ReturnsAsync((string breedName) => breedList);

            //act
            var breeds = await catService.Object.SearchBreed(It.IsAny<string>());

            //assert
            Assert.NotNull(breeds);
            Assert.True(breeds.Count == 2);
        }
    }
}
