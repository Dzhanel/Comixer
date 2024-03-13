using Comixer.Core.Models.Comic;

namespace Comixer.Core.Contracts
{
    public interface IComicService
    {
        Task<ComicDetailsModel> GetComicById(Guid comicId);
    }
}
