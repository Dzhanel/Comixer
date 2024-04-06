using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Comixer.Core.Extensions.Attributes
{
    /// <summary>
    /// Specifies <see cref="IFormFile">IFormFile</see> max size (in bytes).
    /// </summary>
    /// <param name="maxFileSize">in bytes</param>
    public class FormFileMaxSizeAttribute : ValidationAttribute
    {
        private int maxFileSize;
        public FormFileMaxSizeAttribute(int maxFileSize)
        {
            this.maxFileSize = maxFileSize;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var file = value as IFormFile;
            if (file != null)
            {
                if (file.Length > maxFileSize)
                {
                    return new ValidationResult(GetErrorMessage());
                }
            }
            return ValidationResult.Success;
        }
        public string GetErrorMessage()
        {
            return $"Maximum allowed image size is {maxFileSize} bytes.";
        }
    }
}
