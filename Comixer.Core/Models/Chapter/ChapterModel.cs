using Comixer.Core.Models.Comment;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace Comixer.Core.Models.Chapter
{
    public class ChapterModel
    {
        public Guid Id { get; set; }
        public string ComicName { get; set; } = null!;
        public Guid ComicId { get; set; }
        public string Title { get; set; } = null!;
        public ChapterModel? NextChapter { get; set; }
        public ChapterModel? PreviousChapter { get; set; }
        public bool ProhibitComments { get; set; }
        public IEnumerable<ChapterImageModel> ChapterImages { get; set; } = new List<ChapterImageModel>();
        public IEnumerable<CommentModel> Comments { get; set; } = new List<CommentModel>(); 
    }
}
