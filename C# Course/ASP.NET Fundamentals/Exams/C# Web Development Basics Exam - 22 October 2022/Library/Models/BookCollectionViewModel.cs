using System;
namespace Library.Models
{
	public class BookCollectionViewModel
	{
		public ICollection<BookViewModel> Books { get; set; } = new List<BookViewModel>();
	}
}

