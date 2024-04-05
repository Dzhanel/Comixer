using Comixer.Core.Contracts;
using Comixer.Core.Models.Comic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Comixer.Controllers
{
    [Authorize]
    public class ComicsController : Controller
    {
        private readonly IComicService comicService;
        private readonly IImageService imageService;
        private readonly IGenreService genreService;
        public ComicsController(IComicService _comicService, IImageService _imageService, IGenreService _genreService)
        {
            this.comicService = _comicService;
            this.imageService = _imageService;
            this.genreService = _genreService;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Comic(Guid Id)
        {
            try
            {
                return View(await comicService.GetComicById(Id));
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Publish()
        {
            ViewBag.Genres = await genreService.AllGenresAsync();
            return View(new CreateComicModel());
        }
        
        [HttpPost]
        public async Task<IActionResult> Publish(CreateComicModel viewModel)
        {
            ViewBag.Genres = await genreService.AllGenresAsync();
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }


            return View(viewModel);
        }
    }
}
