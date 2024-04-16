using AutoMapper;
using Comixer.Core.Contracts;
using Comixer.Core.Models.Chapter;
using Comixer.Infrastructure.Common;
using Comixer.Infrastructure.Data.Entities;
using Comixer.Infrastructure.Enums;
using Microsoft.EntityFrameworkCore;

namespace Comixer.Core.Service
{
    public class ChapterService : IChapterService
    {
        private readonly IRepository repo;
        private readonly IMapper mapper;
        private readonly IImageService imageService;
        public ChapterService(IRepository _repo, IMapper _mapper, IImageService _imageService)
        {
            this.repo = _repo;
            this.mapper = _mapper;
            this.imageService = _imageService;
        }

        public async Task<ChapterModel> GetChapterContentAsync(Guid chapterId)
        {
            var entity = await repo
                .AllReadonly<Chapter>()
                .Include(x => x.Comic)
                .Include(x => x.Comments)
                .ThenInclude(x => x.User)
                .Include(x => x.ChapterImages)
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
            Guid? comicId = (await repo.GetByIdAsync<Chapter>(currentChapterId))?.ComicId;
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
            Guid? comicId = (await repo.GetByIdAsync<Chapter>(chapterId))?.ComicId;
            var entites = await repo.All<Chapter>()
                .Where(x => x.ComicId == comicId)
                .OrderByDescending(x => x.ReleaseDate)
                .ToListAsync();

            return entites.Take(5).Select(x => mapper.Map<ChapterDropDownModel>(x));
        }
        public async Task<Guid> CreateChapter(CreateChapterModel model)
        {
            var entity = mapper.Map<CreateChapterModel, Chapter>(model);
            entity.Id = Guid.NewGuid();
            entity.Comic = await repo.GetByIdAsync<Comic>(entity.ComicId);
            entity.Comic.Status = Status.Releasing;
            await repo.AddAsync(entity);
            await repo.SaveChangesAsync();
            try
            {
                if (model.ChapterImages.Count > 0)
                {
                    await imageService.UploadChapterImages(model.ChapterImages, entity.Id, model.ComicId);
                }
                else
                {
                    throw new ArgumentException("Chapter should consist of at least 1 image");
                }
                await repo.SaveChangesAsync();
                return entity.Id;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
