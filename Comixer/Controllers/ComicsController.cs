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
            this.comicService = _comicService;
            this.imageService = imageService;
        }
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
        //[HttpGet]
        //public async Task<IActionResult> Publish()
        //{

        //}
        //[HttpPost]
        //public async Task<IActionResult> Publish()
        //{

        //}
    }
}
