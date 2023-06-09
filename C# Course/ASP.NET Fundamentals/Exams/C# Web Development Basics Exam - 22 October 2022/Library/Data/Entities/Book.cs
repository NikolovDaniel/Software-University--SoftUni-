using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Library.Utilities;

namespace Library.Data.Entities
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(
            DataConstants.TitleMaxLength,
            MinimumLength = DataConstants.TitleMinLength)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(
            DataConstants.AuthorMaxLength,
            MinimumLength = DataConstants.AuthorMinLength)]
        public string Author { get; set; } = null!;

        [Required]
        [StringLength(
            DataConstants.DescriptionMaxLength,
            MinimumLength = DataConstants.DescriptionMinLength)]
        public string Description { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [Column(TypeName = "decimal(4,2)")]
        public decimal Rating { get; set; }

        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }

        public Category Category { get; set; } = null!;

        public ICollection<ApplicationUserBook> ApplicationUsersBooks { get; set; } = null!;
    }
}

