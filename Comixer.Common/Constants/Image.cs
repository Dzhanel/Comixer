
namespace Comixer.Common.Constants
{
    public class Image
    {
        //Cover Image Constants
        public const int MinComicCoverHeight = 1920;
        public const int MaxComicCoverHeight = 1922;
        public const int MinComicCoverWidth = 1080;
        public const int MaxComicCoverWidth = 1080;

        public const int MaxImageFileSize = MaxComicCoverHeight * MaxComicCoverWidth * 3;

        //Chapter Image Constants
        public const int MinChapterImageHeight = 1920;
        public const int MaxChapterImageHeight = 1920;
        public const int MaxChapterImageWidth = 1080;
        public const int MinChapterImageWidth = 1080;

        public static string DimensionsDescription() => MaxChapterImageHeight == MinChapterImageHeight && MaxChapterImageWidth == MinChapterImageWidth ?
                $"Image width should be {MaxChapterImageWidth}px and height {MaxChapterImageHeight}px ({MaxChapterImageWidth}x{MaxChapterImageHeight})." :
                $"Image width should be between {MinChapterImageWidth}px and {MaxChapterImageWidth}px and height between - 0px and 1080px ({MinChapterImageWidth}x{MinChapterImageHeight} - {MaxChapterImageWidth}x{MaxChapterImageWidth}).";

    }
}
