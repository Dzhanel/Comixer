﻿using AutoMapper;
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
        public List<string> GetAllStatusNames() => Enum.GetNames(typeof(Status)).ToList();
        public async Task<List<ComicThumbnailModel>> Search(string? keyword, List<string> genres, List<string> statuses, string sorting)
        {
            var result = repo.AllReadonly<Comic>()
                 .Include(x => x.ComicGenres)
                 .ThenInclude(x => x.Genre)
                 .AsQueryable();

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                result = result
                    .Where(x => x.Title!.Contains(keyword));
            }

            if(genres.Count != 0)
            {
                result = result
                    .Where(x => x.ComicGenres
                        .Any(x => genres.Contains(x.Genre.Name)));
            }

            if(statuses.Count != 0)
            {
                result = result
                    .Where(rs => statuses
                        .Select(s => Enum.Parse(typeof(Status), s, true))
                        .Contains(rs.Status));
            }

            if (!string.IsNullOrEmpty(sorting))
            {

            }


            return await result.Select(x => mapper.Map<Comic, ComicThumbnailModel>(x)).ToListAsync();
        }
    }
}
