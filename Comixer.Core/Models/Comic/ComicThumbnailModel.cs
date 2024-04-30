using Comixer.Core.Models.Genre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comixer.Core.Models.Comic
{
    public class ComicThumbnailModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public string CoverImageUrl { get; set; } = null!;
        public List<GenreModel> Genres { get; set; } = new List<GenreModel>();
        public bool IsApproved { get; set; }

    }
}
