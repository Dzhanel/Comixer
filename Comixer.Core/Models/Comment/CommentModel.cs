using Comixer.Infrastructure.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comixer.Core.Models.Comment
{
    public class CommentModel
    {
        public Guid Id { get; set; }
        public string Content { get; set; } = null!;
        public Guid ChapterId { get; set; }
        public string Username { get; set; } = null!;
        public string TimeAgo { get; set; } = null!;
        public int Likes { get; set; }
    }
}
