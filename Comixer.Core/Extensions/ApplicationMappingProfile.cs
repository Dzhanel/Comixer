using AutoMapper;
using Comixer.Core.Models.Chapter;
using Comixer.Core.Models.Comic;
using Comixer.Core.Models.Comment;
using Comixer.Core.Models.Genre;
using Comixer.Infrastructure.Data.Entities;
using Humanizer;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.IdentityModel.Tokens;

namespace Comixer.Core.Extensions
{
    public class ApplicationMappingProfile : Profile
    {
        public ApplicationMappingProfile() 
        {
            GenreMaps();
            UserMaps();
            ChapterImageMaps();
            CommentMaps();
            ChapterMaps();
            ComicMaps();
        }
        private void ComicMaps()
        {
            CreateMap<CreateComicModel, Comic>();
            CreateMap<Comic, ComicThumbnailModel>()
                .ForMember(dest => dest.Genres,
                           opt => opt.MapFrom(src => src.ComicGenres.Select(cg => cg.Genre)));
            CreateMap<Comic, ComicDetailsModel>()
               .ForMember(dest => dest.Genres,
                          opt => opt.MapFrom(src => src.ComicGenres
                                                .Select(cg => cg.Genre)))
               .ForMember(dest => dest.Author,
                          opt => opt.MapFrom(src => src.UsersComics
                                               .Where(uc => uc.IsAuthor)
                                               .FirstOrDefault()!.User))
               .ForMember(dest => dest.Artist,
                          opt => opt.MapFrom(src => src.UsersComics
                                               .Where(uc => uc.IsArtist)
                                               .FirstOrDefault()!.User))
               //.ForMember(dest => dest.AverageRating,
               //           opt => opt.MapFrom(src => src.Chapters.Count == 0 ? 0 : Math.Round(src.Chapters
               //                                .Average(x => x.Rating), 2)))
               .ForMember(dest => dest.ReleaseDate,
                          opt => opt.MapFrom(src => src.Chapters.Count == 0 ? DateTime.UtcNow : src.Chapters.Min(x => x.ReleaseDate)));
        }
        private void GenreMaps()
        {
            CreateMap<Genre, GenreModel>();
        }
        private void UserMaps()
        {
            CreateMap<ApplicationUser, ComicAuthorModel>();
            CreateMap<ApplicationUser, ComicArtistModel>();
        }
        private void ChapterImageMaps()
        {
            CreateMap<ChapterImage, ChapterImageModel>();
        }
        private void ChapterMaps()
        {
            CreateMap<Chapter, ChapterDropDownModel>();
            CreateMap<Chapter, ComicChaptersModel>();
            CreateMap<Chapter, ChapterModel>()
               .ForMember(dest => dest.ComicName, opt => opt.MapFrom(x => x.Comic.Title))
               .ForMember(dest => dest.CoverImageUrl, opt => opt.MapFrom(x => x.Comic.CoverImageUrl));
            CreateMap<CreateChapterModel, Chapter>()
               .ForMember(dest => dest.ChapterImages, opt => opt.Ignore())
               .ForMember(dest => dest.ReleaseDate, opt => opt.MapFrom(x => DateTime.Now));
        }
        private void CommentMaps()
        {
            CreateMap<Comment, CommentModel>()
                .ForMember(dest => dest.Username, opt => opt.MapFrom(x => x.User.UserName));
            CreateMap<AddCommentModel, Comment>();
        }
    }
}
