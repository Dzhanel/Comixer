using Comixer.Core.Models.Chapter;
using Comixer.Core.Models.Genre;
using Comixer.Infrastructure.Data.Entities;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Comixer.Core.Models.Comic
{
    public class ComicDetailsModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime ReleaseDate { get; set; }
        public int Status { get; set; }
        public string? CoverImageUrl { get; set; }
        public ComicAuthorModel Author { get; set; } = null!;
        public ComicArtistModel Artist { get; set; } = null!;
        public int AverageRating { get; set; }
        public ICollection<GenreModel> Genres { get; set; } = new HashSet<GenreModel>();
        public ICollection<ComicChaptersViewModel> Chapters { get; set; } = new HashSet<ComicChaptersViewModel>();
    }
}
