using Comixer.Core.Models.Chapter;
using Comixer.Core.Models.Genre;
using Comixer.Infrastructure.Enums;
using System.ComponentModel.DataAnnotations;
using static Comixer.Common.Constants.Comic;

namespace Comixer.Core.Models.Comic
{
    public class ComicDetailsModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        [DisplayFormat(DataFormatString = DateTimeFormat)]
        public DateTime ReleaseDate { get; set; }
        public Status Status { get; set; }
        public string? CoverImageUrl { get; set; }
        public ComicAuthorModel? Author { get; set; }
        public ComicArtistModel? Artist { get; set; }
        public double AverageRating { get; set; }
        public IEnumerable<GenreModel> Genres { get; set; } = new HashSet<GenreModel>();
        public List<ComicChaptersModel> Chapters { get; set; } = new List<ComicChaptersModel>();
    }
}
