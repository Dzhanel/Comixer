using Microsoft.AspNetCore.Http;

namespace Comixer.Core.Contracts
{
    public interface IImageService
    {
        Task<List<string>> Upload(ICollection<IFormFile> files);
        Task<string> GetImageUrl(string publicId);
        Task<string> UploadComicCoverImage(IFormFile file, Guid comicUrl);
    }
}
