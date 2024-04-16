using Comixer.Core.Contracts;
using Comixer.Core.Models.Chapter;
using Comixer.Core.Models.Comment;
using Comixer.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Comixer.Controllers
{
    [Authorize]
    public class ChapterController : Controller
    {
        private readonly IChapterService chapterService;
        private readonly ICommentService commentService;
        private readonly IComicService comicService;

        public ChapterController(IChapterService _chapterService, ICommentService _commentService, IComicService _comicService)
        {
            this.chapterService = _chapterService;
            this.commentService = _commentService;
            this.comicService = _comicService;
        }

        [HttpPost]
        public async Task<PartialViewResult> PostComment(AddCommentModel viewModel)
        {
            await commentService.AddComment(viewModel, User.Id());
            var comments = await commentService.GetCommentsByChapterId(viewModel.ChapterId);
            ViewBag.ChapterId = viewModel.ChapterId;
            return PartialView("_ChapterCommentsPartial", comments);
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Chapter(Guid id)
        {
            var model = await chapterService.GetChapterContentAsync(id);
            ViewBag.PreviousFiveChapters = (await chapterService.GetPreviousFiveChapters(id));
            ViewBag.ChaterId = model.Id;
            return View(model);
        }

        [Authorize(Roles = "Administrator")]
        [HttpGet]
        public IActionResult PostChapter(Guid id)
        {
            if (id != Guid.Empty)
            {
                //TODO Check if the comics is the current users comic
                CreateChapterModel viewModel = new()
                {
                    AuthorId = User.Id(),
                    ComicId = id
                };

                return View(viewModel);
            }
            else
            {
                return RedirectToAction("/Index/Home");
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostChapter(CreateChapterModel viewModel)
        {
            Guid? comicAuthorId = (await comicService.GetComicById(viewModel.ComicId)).Author?.Id;
            if (comicAuthorId is not null)
            {
                if (viewModel.AuthorId == User.Id() && comicAuthorId == User.Id())
                {
                    Guid chapterGuid = await chapterService.CreateChapter(viewModel);
                    return RedirectToAction("Chapter", new { id = viewModel.ComicId });

                }
            }
            return RedirectToAction("/Index/Home");
        }
    }
}
