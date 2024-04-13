namespace Comixer.Core.Models.Comment
{
    public class CommentModel
    {
        public Guid Id { get; set; }
        public string Content { get; set; } = null!;
        public Guid ChapterId { get; set; }
        public string Username { get; set; } = null!;
        public DateTime PostDate { get; set; }
        public int Likes { get; set; }
    }
}
