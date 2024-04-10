﻿using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Comixer.Core.Contracts;
using Comixer.Core.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Comixer.Core.Service
{
    public class ImageService : IImageService
    {
        private readonly Cloudinary cloudinary;

        public ImageService(IOptions<CloudinarySettings> config)
        {
            var account = new Account(config.Value.CloudName, 
                                      config.Value.ApiKey, 
                                      config.Value.ApiSecret);
            
            this.cloudinary = new Cloudinary(account);
            this.cloudinary.Api.Secure = true;
        }
        public async Task<string> Upload(IFormFile image)
        {
            throw new NotImplementedException();
            //return (await cloudinary.UploadAsync(new ImageUploadParams()
            //{
            //    File = new FileDescription(@"https://picsum.photos/1080/1920"),
            //    PublicId = Guid.NewGuid().ToString(),
            //})).SecureUrl.ToString();
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
        public async Task<List<string>> Upload(ICollection<IFormFile> file)
        {
            throw new NotImplementedException();
        }


        public async Task<string> GetImageUrl(string publicId)
        {
            return (await cloudinary.GetResourceAsync(publicId)).Url;
        }
    }
}
