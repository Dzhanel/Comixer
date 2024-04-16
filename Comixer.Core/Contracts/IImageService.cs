using Comixer.Infrastructure.Data.Entities;
using Microsoft.AspNetCore.Http;

namespace Comixer.Core.Contracts
{
    public interface IImageService
    {
        Task<List<ChapterImage>> UploadChapterImages(IFormFileCollection files, Guid chapterId, Guid comicId);
        Task<string> GetImageUrl(string publicId);
        Task<string> UploadComicCoverImage(IFormFile file, Guid comicUrl);
    }
}
