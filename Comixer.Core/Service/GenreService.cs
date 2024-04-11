using AutoMapper;
using Comixer.Core.Contracts;
using Comixer.Core.Models.Genre;
using Comixer.Infrastructure.Common;
using Comixer.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Comixer.Core.Service
{
    public class GenreService : IGenreService
    {
        private readonly IMapper mapper;
        private readonly IRepository repo;

        public GenreService(IMapper _mapper, IRepository _repo)
        {
            this.mapper = _mapper;
            this.repo = _repo;
        }

        public async Task<List<GenreModel>> AllGenresAsync()
        {
            var genres = await repo.AllReadonly<Genre>().ToListAsync();
            return mapper.Map<List<Genre>, List<GenreModel>>(genres);
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
        public async Task AddGenresToComicAsync(int[] genreIds, Guid comicId)
        {
            int length = genreIds.Length;
            if (length > 0)
            {
                ComicGenre[] comicGenres = new ComicGenre[length];
                for (var i = 0; i < length; i++)
                {
                    comicGenres[i] = new ComicGenre { ComicId = comicId, GenreId = genreIds[i] };
                }
                await repo.AddRangeAsync(comicGenres);
            }
        }
    }
}
