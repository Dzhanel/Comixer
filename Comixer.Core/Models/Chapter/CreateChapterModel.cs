using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using static Comixer.Common.Constants.Chapter;

namespace Comixer.Core.Models.Chapter
{
    public class CreateChapterModel
    {
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]
        public string Title { get; set; } = null!;
        [Required(ErrorMessage = "Please upload at least one file")]
        [Display(Name = "ChapterImages")]
        public FormFileCollection ChapterImages { get; set; } = null!;
        public Guid ChapterId { get; set; }
        public Guid AuthorId { get; set; }
    }
}
