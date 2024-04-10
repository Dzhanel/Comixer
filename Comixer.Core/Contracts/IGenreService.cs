using Comixer.Core.Models.Genre;

namespace Comixer.Core.Contracts
{
    public interface IGenreService
    {
        /// <summary>
        /// Returns all of the availiable genres
        /// </summary>
        /// <returns></returns>
        Task<List<GenreModel>> AllGenresAsync();
    }
}
