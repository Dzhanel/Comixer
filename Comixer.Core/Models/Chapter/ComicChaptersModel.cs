using System.ComponentModel.DataAnnotations;

namespace Comixer.Core.Models.Chapter
{
    public class ComicChaptersModel
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
