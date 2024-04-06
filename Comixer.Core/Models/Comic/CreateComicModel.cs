using Comixer.Core.Extensions.Attributes;
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
        [FormFileMaxSize(maxFileSize: 1920 * 1080 * 3)]
        [AllowedExtensions(".jpg", ".jpeg", ".png", ".webp")]
        [AllowedDimensions(minHeight: 1920, maxHeight: 1920, maxWidth:1080, minWidth:1080)]
        [DataType(DataType.Upload)]
        public IFormFile CoverImage { get; set; } = null!;
        public List<GenreModel> Genres { get; set; } = new List<GenreModel>();
    }
 }
