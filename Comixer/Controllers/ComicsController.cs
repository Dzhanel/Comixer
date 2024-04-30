using Comixer.Core.Contracts;
using Comixer.Core.Models.Comic;
using Comixer.Core.Models.Genre;
using Comixer.Extensions;
using Comixer.Infrastructure.Data.Entities;
using Comixer.Infrastructure.Enums;
using Comixer.Models.Comics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Comixer.Controllers
{
    [Authorize]
    public class ComicsController : Controller
    {
        private readonly IComicService comicService;
        private readonly IImageService imageService;
        private readonly IGenreService genreService;
        private readonly UserManager<ApplicationUser> userManager;
        public ComicsController(IComicService _comicService, IImageService _imageService, IGenreService _genreService, UserManager<ApplicationUser> userManager)
        {
            this.comicService = _comicService;
            this.imageService = _imageService;
            this.genreService = _genreService;
            this.userManager = userManager;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Comic(Guid Id)
        {
            try
            {
                return View(await comicService.GetComicById(Id));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Publish()
        {
            var genres = await genreService.AllGenresAsync();
            return View(new CreateComicModel()
            {
                Genres = genres
            });
        }

        [HttpPost]
        public async Task<IActionResult> Publish(CreateComicModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            try
            {
                viewModel.Genres = viewModel
                    .Genres
                    .Where(x => x.IsChecked)
                    .ToList();

                var newComicid = await comicService.CreateComic(viewModel, User.Id());
                var currentUser = await userManager.GetUserAsync(User);
                if (!await userManager.IsInRoleAsync(currentUser, "Author"))
                {
                    await userManager.AddToRoleAsync(currentUser, "Author");
                }
                return RedirectToAction(nameof(Comic), new { id = newComicid });
            }
            catch
            {
                viewModel.Genres = await genreService.AllGenresAsync();
                return View(viewModel);
                throw;
            }

        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Search(string search, [FromQuery] List<string> genres, [FromQuery] List<string> statuses, [FromQuery] string sorting)
        {
            TempData["SearchTerm"] = search;
            ViewBag.SearchTerm = search;
            var result = await comicService.Search(search, genres, statuses, sorting);
            ViewBag.Genres = await genreService.AllGenresAsync();
            ViewBag.Statuses = comicService.GetAllStatusNames();
            ViewBag.Sortings = comicService.GetAllSortingNames();
            ComicsBrowseModel viewModel = new()
            {
                Genres = genres,
                SearchResult = result,
                Sorting = sorting
            };
            return View(viewModel);
        }

        [HttpGet]
        [Authorize(Roles = "Author")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
            }
            catch (Exception ex)
            {
                return RedirectToAction("Comic", "Comics", new { id });
            }
                var author = await comicService.GetAuthorByComicId(id);
                if(User.Id() == author.Id)
                {
                    await comicService.DeleteComic(id);
                }
                return RedirectToAction("Index", "Home");

        }

    }
}
