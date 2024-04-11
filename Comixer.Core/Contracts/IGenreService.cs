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
        /// <summary>
        /// Gets comic genres
        /// </summary>
        /// <param name="comicId"></param>
        /// <returns></returns>
        Task<ICollection<GenreModel>> GetGenresByComicId(Guid comicId);
        /// <summary>
        /// Adds comic genres
        /// </summary>
        /// <param name="genreIds"></param>
        /// <param name="comicId"></param>
        /// <returns></returns>
        Task AddGenresToComicAsync(int[] genreIds, Guid comicId);
    }
}
