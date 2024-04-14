using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using static Comixer.Common.Constants.FileExtensions;

namespace Comixer.Core.Extensions.Attributes
{
    /// <summary>
    /// Custom attribute that validates <see cref="IFormFile"></see> allowed extensions.<br/>
    /// Supports: .jpg, .jpeg, .png, .webp
    /// </summary>
    /// <param name="extensions"></param>
    public class AllowedExtensionsAttribute : ValidationAttribute
    {
        private readonly string[] extensions;
        public AllowedExtensionsAttribute(params string[] extensions)
        {
            this.extensions = extensions;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var extension = string.Empty;
            if (value is IFormFile file && file != null)
            {
                extension = Path.GetExtension(file.FileName);
                if (!extensions.Contains(extension.ToLower()) && !IsFileValid(file))
                {
                    return new ValidationResult(GetErrorMessage());
                }
            }
            else if (value is IFormFileCollection files)
            {
                foreach (var formFile in files)
                {
                    extension = Path.GetExtension(formFile.FileName);
                    if (!extensions.Contains(extension.ToLower()) && !IsFileValid(formFile))
                    {
                        return new ValidationResult(GetErrorMessage());
                    }
                }
            }


            return ValidationResult.Success;
        }
        public string GetErrorMessage()
        {
            return $"Allowed file extensions are '{jpg}', '{jpeg}', '{png}', '{webp}'";
        }
        /// <summary>
        /// Valdiates if file contains signature from <see cref="fileSignatures"></see> dictionary.
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        //only works with jpg, jpeg, png and webp for now
        private static bool IsFileValid(IFormFile file)
        {
            using (var reader = new BinaryReader(file.OpenReadStream()))
            {
                var signatures = fileSignatures.Values.SelectMany(x => x).ToList();
                var headerBytes = reader.ReadBytes(fileSignatures.Max(m => m.Value.Max(n => n.Length)));
                bool result = signatures.Any(signature => headerBytes.Take(signature.Length).SequenceEqual(signature));
                return result;
            }

        }
        /// <summary>
        /// File signature dictionary to validate image file formats, as checking only extension name is vulnerable.
        /// </summary>
        private static readonly Dictionary<string, List<byte[]>> fileSignatures = new()
        {
            { png, new List<byte[]> { new byte[] { 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A } } },
            { jpeg, new List<byte[]>
                {
                    new byte[] { 0xFF, 0xD8, 0xFF, 0xE0 },
                    new byte[] { 0xFF, 0xD8, 0xFF, 0xE2 },
                    new byte[] { 0xFF, 0xD8, 0xFF, 0xE3 },
                    new byte[] { 0xFF, 0xD8, 0xFF, 0xEE },
                    new byte[] { 0xFF, 0xD8, 0xFF, 0xDB },
                }
            },
            { jpg, new List<byte[]>
                {
                    new byte[] { 0xFF, 0xD8, 0xFF, 0xE0 },
                    new byte[] { 0xFF, 0xD8, 0xFF, 0xE1 },
                    new byte[] { 0xFF, 0xD8, 0xFF, 0xE8 },
                    new byte[] { 0xFF, 0xD8, 0xFF, 0xEE },
                    new byte[] { 0xFF, 0xD8, 0xFF, 0xDB },
                }
            },
            { webp, new List<byte[]>
            {
                 new byte[] { 0x52, 0x49, 0x46, 0x46 },
                 new byte[] { 0x57, 0x45, 0x42, 0x50 },
            } }
        };
    }
}
