using Comixer.Core.Models.Chapter;

namespace Comixer.Core.Contracts
{
    public interface IChapterService
    {
        public Task<ChapterModel> GetChapterContentAsync(Guid chapterId);
        public Task<IEnumerable<ChapterDropDownModel>> GetPreviousFiveChapters(Guid chapterId);
    }
}
