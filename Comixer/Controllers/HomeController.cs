using Comixer.Core.Contracts;
using Comixer.Models;
using Comixer.Models.Home;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Comixer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public readonly IComicService comicService;

        public HomeController(ILogger<HomeController> logger, IComicService _comicService)
        {
            _logger = logger;
            comicService = _comicService;
        }
        public async Task<IActionResult> Index()
        {
            HomePageModel viewModel = new HomePageModel();
            viewModel.Recent = await comicService.TakeRecentComic(); 
            return View(viewModel);
        }

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}