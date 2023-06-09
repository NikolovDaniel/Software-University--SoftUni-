using System;
using Library.Data.Entities;
using Library.Utilities;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
	public class CategoryViewModel
	{
        public int Id { get; set; }

        [Required]
        [StringLength(
            DataConstants.CategoryNameMaxLength,
            MinimumLength = DataConstants.CategoryNameMinLength)]
        public string Name { get; set; } = null!;
    }
}

