namespace Comixer.Common.Constants
{
    public static class FileExtensions
    {
        public const string jpg = ".jpg";
        public const string jpeg = ".jpeg";
        public const string png = ".png";
        public const string webp = ".webp";

        public static string AllowedFileExtensions() => $"Allowed file extensions - {jpg}, {jpeg}, {png}, {webp}";
    }
}
