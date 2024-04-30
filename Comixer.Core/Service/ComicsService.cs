using AutoMapper;
using Comixer.Core.Contracts;
using Comixer.Core.Models.Comic;
using Comixer.Infrastructure.Common;
using Comixer.Infrastructure.Data.Entities;
using Comixer.Infrastructure.Enums;
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
            return await repo.AllReadonly<Comic>(x => x.IsApproved)
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
                    //IsReadLater = readLater
                });
        }
        public async Task<List<ComicThumbnailModel>> GetComicsByAuthorId(Guid authorId)
        {
            return await repo.AllReadonly<UserComic>(x => x.IsAuthor && x.UserId == authorId)
                .Include(x => x.Comic)
                .ThenInclude(x => x.ComicGenres)
                .ThenInclude(x => x.Genre)
                .Select(x => mapper.Map<ComicThumbnailModel>(x.Comic))
                .ToListAsync();
        }
        public async Task<List<ComicThumbnailModel>> Search(string? keyword, List<string> genres, List<string> statuses, string sorting)
        {
            var result = repo.AllReadonly<Comic>(x => x.IsApproved)
                 .Include(x => x.ComicGenres)
                 .ThenInclude(x => x.Genre)
                 .Include(x => x.Chapters)
                 .AsQueryable();

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                result = result
                    .Where(x => x.Title!.Contains(keyword));
            }

            if (genres.Count != 0)
            {
                result = result
                    .Where(x => x.ComicGenres
                        .Any(x => genres.Contains(x.Genre.Name)));
            }

            if (statuses.Count != 0)
            {
                result = result
                    .Where(rs => statuses
                        .Select(s => Enum.Parse(typeof(Status), s, true))
                        .Contains(rs.Status));
            }

            if (!string.IsNullOrEmpty(sorting))
            {
                if (sorting == Sorting.LastUpdated.ToString())
                {
                    result.OrderByDescending(x => x.Chapters.Max(x => x.ReleaseDate));
                }
                else if (sorting == Sorting.ChapterCount.ToString())
                {
                    result.OrderByDescending(x => x.Chapters);
                }
                else if (sorting == Sorting.ReleaseDate.ToString())
                {
                    result.OrderBy(x => x.Chapters.Min(x => x.ReleaseDate));
                }
                else if (sorting == Sorting.Alphabetical.ToString())
                {
                    result.OrderByDescending(x => x.Title);
                }
            }

            return await result.Select(x => mapper.Map<Comic, ComicThumbnailModel>(x)).ToListAsync();
        }
        public List<string> GetAllStatusNames() => Enum.GetNames(typeof(Status)).ToList();
        public List<string> GetAllSortingNames() => Enum.GetNames(typeof(Sorting)).ToList();
        public async Task<ComicAuthorModel> GetAuthorByComicId(Guid comicId)
        {
            var author = (await repo
                .AllReadonly<UserComic>(x => x.IsAuthor && comicId == x.ComicId).Include(x => x.User)
                .FirstOrDefaultAsync())?.User ?? throw new ArgumentException("This author does not have comicses");
            return mapper.Map<ApplicationUser, ComicAuthorModel>(author);
        }
        public async Task DeleteComic(Guid comicId)
        {
            if (await repo.All<Comic>(x => x.Id == comicId).AnyAsync())
            {
                try
                {
                    await imageService.DeleteComicFolder(comicId);
                    await repo.DeleteAsync<Comic>(comicId);
                    await repo.SaveChangesAsync();
                }
                catch (Exception)
                {

                    throw new Exception("Something went wrong");
                }
            }
        }
    }
}
