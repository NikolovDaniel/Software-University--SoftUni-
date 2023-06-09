using System.ComponentModel.DataAnnotations;
using Library.Utilities;

namespace Library.Data.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(
            DataConstants.CategoryNameMaxLength,
            MinimumLength = DataConstants.CategoryNameMinLength)]
        public string Name { get; set; } = null!;

        public ICollection<Book> Books { get; set; } = null!;
    }
}