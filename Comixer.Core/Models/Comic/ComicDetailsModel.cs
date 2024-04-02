using Comixer.Core.Models.Chapter;
using Comixer.Core.Models.Genre;
using System.ComponentModel.DataAnnotations;

namespace Comixer.Core.Models.Comic
{
    public class ComicDetailsModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        [DisplayFormat(DataFormatString = "{0:MMM, dd yyyy}")]
        public DateTime ReleaseDate { get; set; }
        public int Status { get; set; }
        public string? CoverImageUrl { get; set; }
        public ComicAuthorModel? Author { get; set; }
        public ComicArtistModel? Artist { get; set; }
        public double AverageRating { get; set; }
        public ICollection<GenreModel> Genres { get; set; } = new HashSet<GenreModel>();
        public ICollection<ComicChaptersModel> Chapters { get; set; } = new HashSet<ComicChaptersModel>();
    }
}
