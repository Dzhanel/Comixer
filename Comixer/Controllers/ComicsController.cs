using Comixer.Core.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Comixer.Controllers
{
    public class ComicsController : Controller
    {
        private readonly IComicService comicService;
        private readonly IImageService imageService;
        public ComicsController(IComicService _comicService, IImageService imageService)
        {
            comicService = _comicService;
            this.imageService = imageService;
        }
        [HttpGet]
        public async Task<IActionResult> Comic(Guid Id)
        {
            try
            {
                return View(await comicService.GetComicById(Id));
            }
            catch
            {
                return NotFound("Not found");
            }
        }
    }

}
