using Cat.Web.Models;
using Cat.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Cat.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICatService _catService;

        public HomeController(ILogger<HomeController> logger, ICatService catService)
        {
            _logger = logger;
            _catService = catService;
        }

        public async Task<IActionResult> Index()
        {
            var breeds = await _catService.GetBreeds();
            return View(breeds);
        }

        public async Task<IActionResult> SearchBreed(string breedName)
        {
            if (string.IsNullOrWhiteSpace(breedName))
            {
                var model = await _catService.GetBreeds();
                return PartialView(model);
            }

            var breeds = await _catService.SearchBreed(breedName);
            
            UpdateImagePath(breeds);

            return PartialView(breeds);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }

        private async void UpdateImagePath(IList<BreedModel> breeds)
        {
            var breedList = await _catService.GetBreeds();

            foreach (var breedModel in breeds)
            {
                breedModel.Image = breedList.FirstOrDefault(x => x.Name == breedModel.Name)?.Image;
            }
        }
    }

}

