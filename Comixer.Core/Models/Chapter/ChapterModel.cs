namespace Comixer.Core.Models.Chapter
{
    public class ChapterModel
    {
        public Guid Id { get; set; }
        public string ComicName { get; set; } = null!;
        public string Title { get; set; } = null!;
        public ChapterModel? NextChapter { get; set; }
        public ChapterModel? PreviousChapter { get; set; }
        public IEnumerable<ChapterImageModel> ChapterImages { get; set; } = new List<ChapterImageModel>();
    }
}
