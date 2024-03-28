namespace Comixer.Core.Models.Chapter
{
    public class ChapterImageModel
    { 
        public Guid Id { get; set; }
        public string ImagePath { get; set; } = null!;
        public int Position { get; set; }
    }
}
