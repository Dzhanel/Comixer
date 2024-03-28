﻿using AutoMapper;
using Comixer.Core.Models.Chapter;
using Comixer.Core.Models.Comic;
using Comixer.Core.Models.Genre;
using Comixer.Infrastructure.Data.Entities;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.IdentityModel.Tokens;

namespace Comixer.Core.Extensions
{
    public class ApplicationMappingProfile : Profile
    {
        public ApplicationMappingProfile() 
        {
            CreateMap<Genre, GenreModel>();
            
            CreateMap<ApplicationUser, ComicAuthorModel>();
            CreateMap<ApplicationUser, ComicArtistModel>();
            
            CreateMap<Chapter, ChapterDropDownModel>();
            CreateMap<Chapter, ComicChaptersModel>();
            CreateMap<ChapterImage, ChapterImageModel>();
            CreateMap<Chapter, ChapterModel>()
                .ForMember(dest => dest.ComicName, opt => opt.MapFrom(x => x.Comic.Title));

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
                .ForMember(dest => dest.AverageRating,
                           opt => opt.MapFrom(src => src.Chapters.Count == 0 ? 0 : src.Chapters
                                                .Average(x => x.Rating)))
                .ForMember(dest => dest.ReleaseDate,
                           opt => opt.MapFrom(src => src.Chapters.Count == 0 ? DateTime.UtcNow : src.Chapters.Min(x => x.ReleaseDate)));
        }
    }
}
