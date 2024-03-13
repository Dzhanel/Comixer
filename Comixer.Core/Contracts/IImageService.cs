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
        Task<List<string>> Upload(ICollection<IFormFile> file);
        Task<string> Upload();
        Task<string> GetImageUrl(string publicId);
    }
}
