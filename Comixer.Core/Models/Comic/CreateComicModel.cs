using Comixer.Core.Models.Genre;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Comixer.Core.Models.Comic
{
    public class CreateComicModel
    {
        [Required]
        public string Title { get; set; } = null!;
        [AllowNull]
        public string? Description { get; set; }
        [Required]
        [Display(Name = "Cover Image")]
        public IFormFile CoverImage { get; set; } = null!;
        public IEnumerable<GenreModel> Genres { get; set; } = new HashSet<GenreModel>();
    }
}
