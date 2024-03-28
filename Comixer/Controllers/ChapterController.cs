using Comixer.Core.Contracts;
using Comixer.Core.Models.Chapter;
using Microsoft.AspNetCore.Mvc;

namespace Comixer.Controllers
{
    public class ChapterController : Controller
    {
        private readonly IChapterService chapterService;

        public ChapterController(IChapterService chapterService)
        {
            this.chapterService = chapterService;
        }

        public async Task<IActionResult> Chapter(Guid id)
        {
            ViewBag.PreviosFiveChapters = (await chapterService.GetPreviousFiveChapters(id));
            var model = await chapterService.GetChapterContentAsync(id);
            return View(model);
        }
    }
}
