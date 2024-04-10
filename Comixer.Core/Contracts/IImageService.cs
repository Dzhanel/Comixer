using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comixer.Core.Contracts
{
    public interface IImageService
    {
        Task<List<string>> Upload(ICollection<IFormFile> files);
        Task<string> Upload(IFormFile file);
        Task<string> GetImageUrl(string publicId);
        Task<string> UploadComicCoverImage(IFormFile file, Guid comicUrl);
    }
}
