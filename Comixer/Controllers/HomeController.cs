using Comixer.Core.Contracts;
using Comixer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Comixer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IImageService imageService;

        public HomeController(ILogger<HomeController> logger, IImageService _imageService)
        {
            _logger = logger;
            imageService = _imageService;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}