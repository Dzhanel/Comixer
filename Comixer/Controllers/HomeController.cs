using Comixer.Core.Contracts;
using Comixer.Extensions;
using Comixer.Models;
using Comixer.Models.Home;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Comixer.Controllers
{
    [AutoValidateAntiforgeryToken]
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
            HomePageModel viewModel = new()
            {
                Recent = await comicService.TakeRecentComics(),
            };
            if (User.IsInRole("Author"))
            {
                viewModel.MyComics = await comicService.GetComicsByAuthorId(this.User.Id());
            }
            return View(viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}