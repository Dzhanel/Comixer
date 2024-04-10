using Comixer.Core.Models.Comic;

namespace Comixer.Core.Contracts
{
    public interface IComicService
    {
        /// <summary>
        /// Returns GUID of the created comic. Returns null if fails.
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns><see cref="Guid"/></returns>
        Task<Guid> CreateComic(CreateComicModel viewModel, Guid authorId);
        /// <summary>
        /// Gets comic by GUID.
        /// </summary>
        /// <exception cref="KeyNotFoundException"></exception>
        /// <param name="comicId"></param>
        /// <returns></returns>
        Task<ComicDetailsModel> GetComicById(Guid comicId);
    }
}
