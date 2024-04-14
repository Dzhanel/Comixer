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
            if (value is IFormFile file && file != null)
            {
                if (file.Length > maxFileSize)
                {
                    return new ValidationResult(GetErrorMessage());
                }
            }
            else if (value is IFormFileCollection files)
            {
                foreach (var formFile in files)
                {
                    if (formFile.Length > maxFileSize)
                    {
                        return new ValidationResult(GetErrorMessage());
                    }
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
