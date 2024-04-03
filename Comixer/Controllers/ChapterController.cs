using Comixer.Core.Contracts;
using Comixer.Core.Models.Chapter;
using Microsoft.AspNetCore.Mvc;

namespace Comixer.Controllers
{
    public class ChapterController : Controller
    {
        private readonly IChapterService chapterService;

        public ChapterController(IChapterService _chapterService)
        {
            this.chapterService = _chapterService;
        }

        public async Task<IActionResult> Chapter(Guid id)
        {
            ViewBag.PreviousFiveChapters = (await chapterService.GetPreviousFiveChapters(id));
            var model = await chapterService.GetChapterContentAsync(id);
            return View(model);
        }


    }
}
