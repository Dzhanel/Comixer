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

        [Authorize]
        [HttpPost]
        public async Task<PartialViewResult> PostComment(AddCommentModel viewModel)
        {
            if (ModelState.IsValid)
            {
                await commentService.AddComment(viewModel, User.Id());
                ViewBag.ChapterId = viewModel.ChapterId;
                var comments = await commentService.GetCommentsByChapterId(viewModel.ChapterId);
                return PartialView("_ChapterCommentsPartial", comments);
            }
            else
            {
                var comments = await commentService.GetCommentsByChapterId(viewModel.ChapterId);
                return PartialView("_ChapterCommentPartial", comments);
            }
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
        [HttpGet]
        public async Task<IActionResult> PostChapter(Guid id)
        {
            try
            {
                var comic = await comicService.GetComicById(id);
                if (id != Guid.Empty && comic.Author != null && comic.Author.Id == User.Id())
                {
                    CreateChapterModel viewModel = new()
                    {
                        AuthorId = User.Id(),
                        ComicId = id
                    };

                    return View(viewModel);
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Something went wrong");
            }
            return RedirectToAction("/Index/Home");
        }
        [HttpPost]
        public async Task<IActionResult> PostChapter(CreateChapterModel viewModel)
        {
            Guid? comicAuthorId = (await comicService.GetComicById(viewModel.ComicId)).Author?.Id;
            if (comicAuthorId is not null)
            {
                if (viewModel.AuthorId == User.Id() && comicAuthorId == User.Id())
                {
                    Guid chapterId = await chapterService.CreateChapter(viewModel);
                    return RedirectToAction("Comic", "Comics", new { id = viewModel.ComicId });
                }
            }
            return RedirectToAction("/Index/Home");
        }
    }
}
