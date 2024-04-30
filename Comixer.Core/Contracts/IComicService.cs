using Comixer.Core.Models.Comic;
using Comixer.Infrastructure.Enums;

namespace Comixer.Core.Contracts
{
    public interface IComicService
    {
        /// <summary>
        /// Fetches comic author
        /// </summary>
        /// <returns></returns>
        Task<ComicAuthorModel> GetAuthorByComicId(Guid comicId);
        /// <summary>
        /// Creates comic. Returns null if fails.
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns><see cref="Guid"/> of the created comic</returns>
        Task<Guid> CreateComic(CreateComicModel viewModel, Guid authorId);
        /// <summary>
        /// Fetches all the 
        /// </summary>
        /// <param name="authorId"></param>
        /// <returns></returns>
        Task<List<ComicThumbnailModel>> GetComicsByAuthorId(Guid authorId);
        /// <summary>
        /// Fetches comic by GUID.
        /// </summary>
        /// <exception cref="KeyNotFoundException"></exception>
        /// <param name="comicId"></param>
        /// <returns></returns>
        Task<ComicDetailsModel> GetComicById(Guid comicId);
        /// <summary>
        /// Performs search and returns list of <see cref="ComicThumbnailModel"/>, with applied filters and sorting
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="genres"></param>
        /// <param name="statuses"></param>
        /// <param name="sorting"></param>
        /// <returns></returns>
        Task<List<ComicThumbnailModel>> Search(string? keyword, List<string> genres, List<string> statuses, string sorting);
        /// <summary>
        /// Takes 8 most recently updated comics
        /// </summary>
        /// <returns></returns>
        Task<List<ComicThumbnailModel>> TakeRecentComics();
        /// <summary>
        /// Gets all values from <see cref="Status"/>
        /// </summary>
        /// <returns></returns>
        List<string> GetAllStatusNames();
        /// <summary>
        /// Gets all values from <see cref="Sorting"/>
        /// </summary>
        /// <returns>List of strings with sorting names</returns>
        List<string> GetAllSortingNames();
        /// <summary>
        /// Deletes Comic from the database
        /// </summary>
        /// <param name="comicId"></param>
        /// <returns></returns>
        Task DeleteComic(Guid comicId);
        Task ChangeToStatus(Status status, Guid comicId);
    }
}
