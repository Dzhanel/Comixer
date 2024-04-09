using Microsoft.AspNetCore.Http;
using SixLabors.ImageSharp;
using System.ComponentModel.DataAnnotations;


namespace Comixer.Core.Extensions.Attributes
{
    public class AllowedDimensionsAttribute : ValidationAttribute
    {
        private readonly int minWidth;
        private readonly int maxWidth;
        private readonly int minHeight;
        private readonly int maxHeight;
        public AllowedDimensionsAttribute(int minWidth, int maxWidth, int minHeight, int maxHeight)
        {
            this.minWidth = minWidth;
            this.maxWidth = maxWidth;
            this.minHeight = minHeight;
            this.maxHeight = maxHeight;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is IFormFile file && file is not null)
            {
                if (!IsInDimensions(file))
                {
                    return new ValidationResult(GetErrorMessage());
                }
            }
            return ValidationResult.Success;
        }

        public bool IsInDimensions(IFormFile file)
        {
            using var image = Image.Load(file.OpenReadStream());
            var height = image.Height;
            var width = image.Width;

            return (height >= minHeight && height <= maxHeight) && width >= minWidth && width <= minHeight;
        }
        public string GetErrorMessage()
        {
            if (minWidth == maxWidth && minHeight == maxHeight)
            {
                return $"Dimensions should be exactly {minWidth}x{minHeight}px";
            }
            else
            {
                return $"Dimensions should be between {minWidth}x{minHeight} and {maxWidth}x{maxHeight}";
            }
        }
    }
}
