﻿using Comixer.Core.Models.Genre;

namespace Comixer.Core.Contracts
{
    public interface IGenreService
    {
        Task<IEnumerable<GenreModel>> AllGenresAsync();
    }
}