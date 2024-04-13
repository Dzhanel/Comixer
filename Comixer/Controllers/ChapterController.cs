using Comixer.Core.Contracts;
using Comixer.Core.Models.Comment;
using Comixer.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NuGet.Protocol;

namespace Comixer.Controllers
{
    [Authorize]
    public class ChapterController : Controller
    {
        private readonly IChapterService chapterService;
        private readonly ICommentService commentService;

        public ChapterController(IChapterService _chapterService, ICommentService _commentService)
        {
            this.chapterService = _chapterService;
            this.commentService = _commentService;
        }
        
        [Authorize]
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
        

    }
} 
