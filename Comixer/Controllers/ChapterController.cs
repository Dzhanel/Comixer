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

        public ChapterController(IChapterService _chapterService,
                                 ICommentService _commentService,
                                 IComicService _comicService)
        {
            this.chapterService = _chapterService;
            this.commentService = _commentService;
            this.comicService = _comicService;
        }
        /// <summary>
        /// This action creates a new comment in the database then returns the partial of the comment
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        public async Task<PartialViewResult> PostComment(AddCommentModel viewModel)
        {
            List<CommentModel>? comments = null;
            if (ModelState.IsValid)
            {
                await commentService.AddComment(viewModel, User.Id());
                comments = await commentService.GetCommentsByChapterId(viewModel.ChapterId);
                ViewBag.ChapterId = viewModel.ChapterId;
            }
            return PartialView("_ChapterCommentsPartial", comments);

        }
        /// <summary>
        /// This action returns the comic page
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Chapter(Guid id)
        {
            var model = await chapterService.GetChapterContentAsync(id);
            ViewBag.PreviousFiveChapters = (await chapterService.GetPreviousFiveChapters(id));
            ViewBag.ChaterId = model.Id;
            return View(model);
        }
        /// <summary>
        /// This action returns the page for posting a chapter
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
        /// <summary>
        /// This action creates a chapter, then redirects to the comic of the newly create chapter.
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
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
