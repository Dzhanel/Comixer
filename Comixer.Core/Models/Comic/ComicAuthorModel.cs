using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comixer.Core.Models.Comic
{
    public class ComicAuthorModel
    {
        public Guid Id { get; set; }
        public string UserName { get; set; } = null!;
    }
}
