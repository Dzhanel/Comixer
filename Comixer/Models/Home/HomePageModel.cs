using Comixer.Core.Models.Comic;

namespace Comixer.Models.Home
{
    public class HomePageModel
    {
        public List<ComicThumbnailModel> Recent { get; set; } = new();
    }
}
