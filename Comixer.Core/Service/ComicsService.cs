using AutoMapper;
using Comixer.Core.Contracts;
using Comixer.Core.Models.Comic;
using Comixer.Core.Models.Genre;
using Comixer.Infrastructure.Common;
using Comixer.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Comixer.Core.Service
{
    public class ComicsService : IComicService
    {
        private readonly IRepository repo;
        private readonly IMapper mapper;
        private readonly IImageService imageService;
        private readonly IGenreService genreService;
        public ComicsService(IRepository _repo, 
            IMapper _mapper, 
            IImageService _imageService, 
            IGenreService _genreService)
        {
            this.repo = _repo;
            this.mapper = _mapper;
            this.imageService = _imageService;
            this.genreService = _genreService;
        }

        public async Task<Guid> CreateComic(CreateComicModel viewModel, Guid authorId)
        {
            var entity = mapper.Map<CreateComicModel, Comic>(viewModel);
            Guid comicId = Guid.NewGuid();
            entity.Id = comicId;
            await repo.AddAsync(entity);

            if (viewModel.Genres.Any())
            {
                var genreIds = viewModel.Genres.Select(x => x.Id).ToArray();
                await this.genreService.AddGenresToComicAsync(genreIds, entity.Id);
            }
            await AddUserComicRelation(comicId, authorId, isAuthor: true, isArtist: true);
            entity.CoverImageUrl = await imageService.UploadComicCoverImage(viewModel.CoverImage, entity.Id);
            var result = await repo.SaveChangesAsync();
            return comicId;
        }
        public async Task<List<ComicThumbnailModel>> TakeRecentComics()
        {
            return await repo.AllReadonly<Comic>()
                .Include(x => x.ComicGenres)
                .ThenInclude(x => x.Genre)
                .OrderByDescending(x => x.Chapters.Max(x => x.ReleaseDate))
                .Select(x => mapper.Map<ComicThumbnailModel>(x))
                .Take(8)
                .ToListAsync();
        }
        public async Task<ComicDetailsModel> GetComicById(Guid comicId)
        {
            var entity = await repo.AllReadonly<Comic>(x => x.Id == comicId)
                .Include(c => c.ComicGenres)
                .ThenInclude(cg => cg.Genre)
                .Include(c => c.UsersComics)
                .ThenInclude(uc => uc.User)
                .Include(c => c.Chapters.OrderByDescending(x => x.ReleaseDate))
                .FirstOrDefaultAsync() ?? throw new KeyNotFoundException("Invalid Id");
            
            return mapper
                .Map<ComicDetailsModel>(source: entity);
        }
        private async Task AddUserComicRelation(Guid comicId, Guid userId, bool isAuthor, bool isArtist = false, bool readLater = false)
        {
            await repo.AddAsync(
                new UserComic()
                {
                    ComicId = comicId,
                    UserId = userId,
                    IsAuthor = isAuthor,
                    IsArtist = isArtist,
                    IsReadLater = readLater
                });
        }

        public async Task<List<ComicThumbnailModel>> Search(string keyword)
        {
            var genres = (await genreService.AllGenresAsync()).Select(x => x.Name).ToList();

            var result = await repo.All<Comic>()
                .Where(x => x.Title!.Contains(keyword))
                .Include(x => x.ComicGenres)
                .ThenInclude(x => x.Genre)
                .OrderBy(x => x.Chapters.Count)
                .Select(x => mapper.Map<Comic, ComicThumbnailModel>(x))
                .ToListAsync();

            return result;
        }
    }
}
