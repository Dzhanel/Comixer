﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Comixer.Data.Entities
{
    public class UserComic
    {
        public bool IsAuthor { get; set; }
        public bool IsArtist { get; set; }
        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }
        public ApplicationUser User { get; set; } = null!;
        [ForeignKey(nameof(Comic))]
        public Guid ComicId { get; set; }
        public Comic Comic { get; set; } = null!;
    }
}
