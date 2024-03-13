using AutoMapper;
using Comixer.Core.Contracts;
using Comixer.Core.Models.Comic;
using Comixer.Core.Models.Genre;
using Comixer.Infrastructure.Common;
using Comixer.Infrastructure.Data.Entities;
using Microsoft.AspNetCore.SignalR;
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

        public async Task<ComicDetailsModel> GetComicById(Guid comicId)
        {
            var entity = await repo.AllReadonly<Comic>(x => x.Id == comicId)
                .Include(c => c.ComicGenres)
                .ThenInclude(cg => cg.Genre)
                .Include(c => c.UsersComics)
                .ThenInclude(uc => uc.User)
                .Include(c => c.Chapters)
                .FirstOrDefaultAsync() ?? throw new NullReferenceException("Invalid Id");
            
            return mapper
                .Map<ComicDetailsModel>(source: entity);
        }
        public async Task<ICollection<GenreModel>> GetGenresByComicId(Guid comicId)
        {
            var genres = await repo
                .All<ComicGenre>(x => x.ComicId == comicId)
                .Select(x => x.Genre)
                .ToListAsync();
            
            return genres
                .Select(g => mapper.Map(g, new GenreModel()))
                .ToList();
        }

    }
}
