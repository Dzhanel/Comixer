using System.ComponentModel.DataAnnotations;

namespace Comixer.Data.Entities
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; } = null!;
        public ICollection<Comic> Comics { get; set; } = new HashSet<Comic>();
    }
}
