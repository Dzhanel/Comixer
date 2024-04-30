using Comixer.Core.Extensions.Attributes;
using Comixer.Core.Models.Genre;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using static Comixer.Common.Constants.Image;
using static Comixer.Common.Constants.FileExtensions;

namespace Comixer.Core.Models.Comic
{
    public class CreateComicModel
    {
        [Required]
        public string Title { get; set; } = null!;
        [AllowNull]
        public string? Description { get; set; }
        public bool IsApproved { get; set; }
        [Required]
        [Display(Name = "Cover Image")]
        [FormFileMaxSize(maxFileSize: MaxImageFileSize)]
        [AllowedExtensions(jpg, jpeg, png, webp)]
        [AllowedDimensions(
            minHeight: MinComicCoverHeight, 
            maxHeight: MaxComicCoverHeight, 
            maxWidth: MaxComicCoverWidth, 
            minWidth:MinComicCoverWidth)]
        [DataType(DataType.Upload)]
        public IFormFile CoverImage { get; set; } = null!;
        public List<GenreModel> Genres { get; set; } = new List<GenreModel>();
    }
 }
