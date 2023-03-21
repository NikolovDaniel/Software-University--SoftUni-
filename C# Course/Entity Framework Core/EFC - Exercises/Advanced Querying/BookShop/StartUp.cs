namespace BookShop
{
    using BookShop.Models;
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;
    using System.Globalization;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            DbInitializer.ResetDatabase(db);

            int result = RemoveBooks(db);

            Console.WriteLine(result);
        }

        // 02. Age Restriction
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            StringBuilder sb = new StringBuilder();

            AgeRestriction ageRestriction = Enum.Parse<AgeRestriction>(command, true);

            var titles = context.Books
                .Where(b => b.AgeRestriction == ageRestriction)
                .OrderBy(b => b.Title)
                .Select(b => b.Title);

            foreach (var t in titles)
            {
                sb.AppendLine(t);
            }

            return sb.ToString().TrimEnd();
        }

        // 03. Golden Books
        public static string GetGoldenBooks(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.EditionType == EditionType.Gold && b.Copies < 5000)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToArray();

            return string.Join(Environment.NewLine, books);
        }

        // 04. Books by Price
        public static string GetBooksByPrice(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.Price > 40)
                .OrderByDescending(b => b.Price)
                .Select(b => new
                {
                    Title = b.Title,
                    Price = b.Price
                })
                .ToArray();

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < books.Length; i++)
            {
                string title = books[i].Title;
                decimal price = books[i].Price;
                sb.AppendLine($"{title} - ${price:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        // 05. Not Released In
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            DateTime yearDate = new DateTime(year, 1, 1);

            var books = context.Books
                .AsEnumerable()
                .Where(b => Convert.ToDateTime(b.ReleaseDate).Year != yearDate.Year)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToArray();

            return string.Join(Environment.NewLine, books);
        }

        // 06. Book Titles by Category
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            string[] genres = input
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(g => g.ToLower())
                .ToArray();

            string[] bookTitles = context.Books
                    .Where(b => b.BookCategories.Any(bc => genres.Contains(bc.Category.Name.ToLower())))
                    .OrderBy(b => b.Title)
                    .Select(b => b.Title)
                    .ToArray();

            return string.Join(Environment.NewLine, bookTitles);
        }

        // 07. Released Before Date
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            DateTime dateConvert = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var books = context.Books
                .AsEnumerable()
                .Where(b => Convert.ToDateTime(b.ReleaseDate) < dateConvert)
                .OrderByDescending(b => b.ReleaseDate)
                .Select(b => new
                {
                    b.Title,
                    b.EditionType,
                    b.Price
                })
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        // 08. Author Search
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authors = context.Authors
                .AsEnumerable()
                .Where(a => a.FirstName.EndsWith(input))
                .Select(a => a.FirstName + " " + a.LastName)
                .OrderBy(a => a)
                .ToArray();

            return string.Join(Environment.NewLine, authors);
        }

        // 09. Book Search
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var bookTitles = context.Books
                .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .Select(b => b.Title)
                .OrderBy(b => b)
                .ToArray();

            return string.Join(Environment.NewLine, bookTitles);
        }

        // 10. Book Search by Author
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var titlesAuthors = context.Authors
                .Where(a => a.LastName.ToLower().StartsWith(input.ToLower()))
                .Select(a => new
                {
                    Name = a.FirstName + " " + a.LastName,
                    Titles = a.Books.OrderBy(b => b.BookId).Select(b => b.Title).ToArray()
                })
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var a in titlesAuthors)
            {
                foreach (var title in a.Titles)
                {
                    sb.AppendLine($"{title} ({a.Name})");
                }
            }

            return sb.ToString().TrimEnd();
        }

        // 11. Count Books
        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            int count = context.Books.Where(b => b.Title.Length > lengthCheck).Count();

            return count;
        }

        // 12. Total Book Copies
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var authorWithBookCopies = context.Authors
                .Select(a => new
                {
                    Name = a.FirstName + " " + a.LastName,
                    TotalCopies = a.Books.Select(b => b.Copies).Sum()
                })
                .OrderByDescending(a => a.TotalCopies)
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var a in authorWithBookCopies)
            {
                sb.AppendLine($"{a.Name} - {a.TotalCopies}");
            }

            return sb.ToString().TrimEnd();
        }

        // 13. Profit by Category
        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var categorySum = context.Categories
                .Select(c => new
                {
                    Name = c.Name,
                    TotalSum = c.CategoryBooks.Select(cb => cb.Book.Price * cb.Book.Copies).Sum()
                })
                .OrderByDescending(c => c.TotalSum)
                .ThenBy(c => c.Name)
                .ToArray();
                
            StringBuilder sb= new StringBuilder();

            foreach (var c in categorySum)
            {
                sb.AppendLine($"{c.Name} ${c.TotalSum:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        // 14. Most Recent Books
        public static string GetMostRecentBooks(BookShopContext context)
        {
            var genreTopThreeBooks = context.Categories
                .Select(c => new
                {
                    c.Name,
                    TopThreeTitles = c.CategoryBooks
                    .OrderByDescending(b => b.Book.ReleaseDate)
                    .Select(b => new { b.Book.Title, Year = Convert.ToDateTime(b.Book.ReleaseDate).Year }) // Year could be taken also like b.Book.ReleaseDate.Value.Year
                    .Take(3)
                })
                .OrderBy(c => c.Name)
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var c in genreTopThreeBooks)
            {
                sb.AppendLine($"--{c.Name}");

                foreach (var b in c.TopThreeTitles)
                {
                    sb.AppendLine($"{b.Title} ({b.Year})");
                }
            }

            return sb.ToString().TrimEnd();
        }

        // 15. Increase Prices 
        public static void IncreasePrices(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.ReleaseDate.Value.Year < 2010)
                .ToArray();

            foreach (var book in books)
            {
                book.Price += 5;
            }

            context.BulkUpdate(books);
        }

        // 16. Remove Books
        public static int RemoveBooks(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.Copies < 4200)
                .ToArray();

            int count = books.Count();

            context.BulkDelete(books);

            return count;
        }
    }
}


