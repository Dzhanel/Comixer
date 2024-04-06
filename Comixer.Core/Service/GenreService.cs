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
    }
}
