using Comixer.Core.Models.Chapter;

namespace Comixer.Core.Contracts
{
    public interface IChapterService
    {
        /// <summary>
        /// Gets chapter content by given chapter id
        /// </summary>
        /// <param name="chapterId"></param>
        /// <returns><see cref="ChapterModel"></see> instance</returns>
        public Task<ChapterModel> GetChapterContentAsync(Guid chapterId);
        /// <summary>
        /// Gets previous 5 chapter. If chapters count is less than 5, then returns all chapters.
        /// </summary>
        /// <param name="chapterId"></param>
        /// <returns></returns>
        public Task<IEnumerable<ChapterDropDownModel>> GetPreviousFiveChapters(Guid chapterId);
    }
}
