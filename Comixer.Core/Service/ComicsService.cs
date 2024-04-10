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
        public ComicsService(IRepository _repo, IMapper _mapper, IImageService imageService)
        {
            this.repo = _repo;
            this.mapper = _mapper;
            this.imageService = imageService;
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
                await this.AddGenresToComicAsync(genreIds, entity.Id);
            }
            await AddUserComicRelation(comicId, authorId, isAuthor: true, isArtist: true);
            entity.CoverImageUrl = await imageService.UploadComicCoverImage(viewModel.CoverImage, entity.Id);
            var result = await repo.SaveChangesAsync();
            return comicId;
        }

        public async Task<ComicDetailsModel> GetComicById(Guid comicId)
        {
            var entity = await repo.AllReadonly<Comic>(x => x.Id == comicId)
                .Include(c => c.ComicGenres)
                .ThenInclude(cg => cg.Genre)
                .Include(c => c.UsersComics)
                .ThenInclude(uc => uc.User)
                .Include(c => c.Chapters)
                .FirstOrDefaultAsync() ?? throw new KeyNotFoundException("Invalid Id");
            
            return mapper
                .Map<ComicDetailsModel>(source: entity);
        }
        public async Task<ICollection<GenreModel>> GetGenresByComicId(Guid comicId)
        {
            var genres = await repo
                .All<ComicGenre>(x => x.ComicId == comicId)
                .Select(x => x.Genre)
                .ToListAsync() ?? throw new KeyNotFoundException("Invalid Id");
            
            return genres
                .Select(g => mapper.Map(g, new GenreModel()))
                .ToList();
        }
        private async Task AddGenresToComicAsync(int[] genreIds, Guid comicId)
        {
            int length = genreIds.Length;
            if(length > 0)
            {
                ComicGenre[] comicGenres = new ComicGenre[length];
                for (var i = 0; i < length; i++)
                {
                    comicGenres[i] = new ComicGenre { ComicId = comicId, GenreId = genreIds[i] };
                }
                await repo.AddRangeAsync(comicGenres);
            }
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

    }
}
