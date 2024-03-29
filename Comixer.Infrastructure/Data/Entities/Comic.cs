﻿    using Comixer.Infrastructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Comixer.Infrastructure.Data.Entities
{
    [EntityTypeConfiguration(typeof(ComicConfiguration))]
    public class Comic
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(80)]
        public string Title { get; set; } = null!;
        [AllowNull]
        [MaxLength(300)]
        public string Description { get; set; }
        public int Status { get; set; }
        public string? CoverImageUrl { get; set; }
        public ICollection<Chapter> Chapters { get; set; } = new HashSet<Chapter>();
        public ICollection<UserComic> UsersComics { get; set; } = new HashSet<UserComic>();
        public ICollection<ComicGenre> ComicGenres { get; set; } = new HashSet<ComicGenre>();
    }
}
