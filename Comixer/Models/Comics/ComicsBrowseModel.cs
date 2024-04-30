using Comixer.Core.Models.Comic;

namespace Comixer.Models.Comics
{
    public class ComicsBrowseModel
    {
        public List<string> Genres { get; set; } = new();
        public List<string> Statuses { get; set; } = new();
        public List<ComicThumbnailModel> SearchResult { get; set; } = new List<ComicThumbnailModel>();
        public string? Sorting { get; set; }

    }
}
