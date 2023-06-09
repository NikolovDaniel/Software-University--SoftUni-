using System;
using Library.Data.Entities;
using Library.Utilities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models
{
	public class BookFormViewModel
	{
        public int Id { get; set; }

        [Required]
        [StringLength(
            DataConstants.TitleMaxLength,
            MinimumLength = DataConstants.TitleMinLength,
            ErrorMessage = ErrorMessages.TitleErrorMessage)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(
            DataConstants.AuthorMaxLength,
            MinimumLength = DataConstants.AuthorMinLength,
            ErrorMessage = ErrorMessages.AuthoErrorMessage)]
        public string Author { get; set; } = null!;

        [Required]
        [StringLength(
            DataConstants.DescriptionMaxLength,
            MinimumLength = DataConstants.DescriptionMinLength,
            ErrorMessage = ErrorMessages.DescriptionErrorMessage)]
        public string Description { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = null!;

        [Column(TypeName = "decimal(12,3)")]
        public decimal Rating { get; set; }

        public int CategoryId { get; set; }

        public ICollection<CategoryViewModel> Categories { get; set; }
         = new List<CategoryViewModel>();
    }
}

