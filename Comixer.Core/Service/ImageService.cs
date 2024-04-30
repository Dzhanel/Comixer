using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Comixer.Common.Constants;
using Comixer.Core.Contracts;
using Comixer.Core.Helpers;
using Comixer.Infrastructure.Common;
using Comixer.Infrastructure.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Comixer.Core.Service
{
    public class ImageService : IImageService
    {
        private readonly Cloudinary cloudinary;
        private readonly IRepository repo;

        public ImageService(IOptions<CloudinarySettings> config, IRepository _repo)
        {
            var account = new Account(config.Value.CloudName,
                                      config.Value.ApiKey,
                                      config.Value.ApiSecret);

            this.cloudinary = new Cloudinary(account);
            this.cloudinary.Api.Secure = true;
            this.repo = _repo;
        }

        public async Task<string> UploadComicCoverImage(IFormFile image, Guid comicId)
        {
            string fileName = $"cover-{comicId}{Path.GetExtension(image.FileName)}";
            using var stream = image.OpenReadStream();

            string coverUrl = (await cloudinary.UploadAsync(new ImageUploadParams()
            {
                File = new FileDescription(fileName, stream),
                Folder = $"comic-{comicId}",
                PublicId = $"cover-{comicId}"
            })).SecureUrl.AbsoluteUri;

            return coverUrl;
        }
        public async Task<List<ChapterImage>> UploadChapterImages(IFormFileCollection files, Guid chapterId, Guid comicId)
        {
            List<ChapterImage> imageUrls = new();
            foreach (var file in files)
            {
                ChapterImage entity = new()
                {
                    Id = Guid.NewGuid(),
                    ChapterId = chapterId,
                };
                string publicId = $"{Path.GetFileNameWithoutExtension(file.FileName)}-{entity.Id}{Path.GetExtension(file.FileName)}";
                using (var stream = file.OpenReadStream())
                {
                    entity.ImagePath = (await cloudinary.UploadAsync(new ImageUploadParams()
                    {
                        File = new FileDescription(file.FileName, stream),
                        Folder = $"comic-{comicId}/{chapterId}",
                        PublicId = publicId
                    })).SecureUrl.AbsoluteUri;
                }
                await repo.AddAsync(entity);
                imageUrls.Add(entity);
            }
            return imageUrls;
        }
        public async Task<string> GetImageUrl(string publicId)
        {
            return (await cloudinary.GetResourceAsync(publicId)).Url;
        }
        public async Task DeleteComicFolder(Guid comicId)
        {
            try
            {
                await cloudinary.DeleteResourcesByPrefixAsync($"comic-{comicId}/");
                await cloudinary.DeleteFolderAsync($"comic-{comicId}");
            }
            catch
            {
                throw new Exception("Something went wrong with the deletion form the cloud");
            }
        }
    }
}
