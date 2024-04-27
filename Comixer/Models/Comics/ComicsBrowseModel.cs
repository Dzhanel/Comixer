using Comixer.Core.Models.Comic;
using Comixer.Core.Models.Genre;

namespace Comixer.Models.Comics
{
    public class ComicsBrowseModel
    {
        public List<string> Genres { get; set; } = new();
        public List<ComicThumbnailModel> SearchResult { get; set; } = null!;
        public string Sorting { get; set; }
    }
}
