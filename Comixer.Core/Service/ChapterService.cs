using AutoMapper;
using Comixer.Core.Contracts;
using Comixer.Core.Models.Chapter;
using Comixer.Infrastructure.Common;
using Comixer.Infrastructure.Data.Entities;
using Humanizer;
using Microsoft.EntityFrameworkCore;

namespace Comixer.Core.Service
{
    public class ChapterService : IChapterService
    {
        private readonly IRepository repo;
        private readonly IMapper mapper;
        public ChapterService(IRepository _repo, IMapper _mapper)
        {
            this.repo = _repo;
            mapper = _mapper;
        }

        public async Task<ChapterModel> GetChapterContentAsync(Guid chapterId)
        {
            var entity = await repo
                .AllReadonly<Chapter>()
                .Include(x => x.Comic)
                .Include(x => x.Comments)
                .ThenInclude(x => x.User)
                .Where(x => x.Id == chapterId)
                .FirstOrDefaultAsync();
            
            var model = mapper.Map<ChapterModel>(entity);
            model.PreviousChapter = await GetPreviousChapterAsync(chapterId);
            model.NextChapter = await GetNextChapterAsync(chapterId);
                
            return model; 
        }
        private async Task<ChapterModel?> GetPreviousChapterAsync(Guid currentChapterId)
        {
            Guid comicId = (await repo.GetByIdAsync<Chapter>(currentChapterId)).ComicId;
            var allChapters = await repo
               .AllReadonly<Chapter>()
               .Where(x => x.ComicId == comicId)
               .OrderByDescending(x => x.ReleaseDate)
               .ToListAsync();

            int chapterIndex = allChapters.FindIndex(x => x.Id == currentChapterId) + 1;

            return chapterIndex < allChapters.Count && chapterIndex >= 0 ?
                                mapper.Map<ChapterModel?>(allChapters[chapterIndex]) : null;

        }
        private async Task<ChapterModel?> GetNextChapterAsync(Guid currentChapterId) 
        {
            Guid comicId = (await repo.GetByIdAsync<Chapter>(currentChapterId)).ComicId;
            var allChapters = await repo
               .AllReadonly<Chapter>()
               .Where(x => x.ComicId == comicId)
               .OrderByDescending(x => x.ReleaseDate)
               .ToListAsync();

            int chapterIndex = allChapters.FindIndex(x => x.Id == currentChapterId) - 1;

            return chapterIndex < allChapters.Count && chapterIndex >= 0 ? 
                mapper.Map<ChapterModel>(allChapters[chapterIndex]) : null;

        }
        public async Task<IEnumerable<ChapterDropDownModel>> GetPreviousFiveChapters(Guid chapterId)
        {
            var comicId = ((await repo.GetByIdAsync<Chapter>(chapterId))?.ComicId) ?? throw new ArgumentException("Invalid id");
            var entites = await repo.All<Chapter>()
                .Where(x => x.ComicId == comicId)
                .OrderByDescending(x => x.ReleaseDate)
                .ToListAsync();

            return entites.Take(5).Select(x => mapper.Map<ChapterDropDownModel>(x));
        }
        public async Task<Guid> CreateChapter(CreateChapterModel model)
        {
            throw new NotImplementedException();
        }
    }
}
