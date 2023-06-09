using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Library.Data;
using Library.Data.Entities;
using Library.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Library.Controllers
{
    [Authorize]
    public class BooksController : Controller
    {
        private readonly LibraryDbContext context;

        public BooksController(LibraryDbContext context)
        {
            this.context = context;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var books = await context.Books
                .Select(b => new BookViewModel()
                {
                    Id = b.Id,
                    Title = b.Title,
                    Author = b.Author,
                    Description = b.Description,
                    ImageUrl = b.ImageUrl,
                    Rating = b.Rating,
                    Category = b.Category.Name
                })
                .ToListAsync();

            return View(books);
        }

        [HttpGet]
        public async Task<IActionResult> Mine()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
            {
                return BadRequest();
            }

            var userBooks = await this.context.ApplicationUsersBooks
                .Where(aub => aub.ApplicationUserId == userId)
                .Select(aub => aub.Book)
                .ToListAsync();

            if (userBooks == null)
            {
                return BadRequest();
            }

            var bookCollectionModel = new BookCollectionViewModel()
            {
                Books = userBooks
                .Select(b => new BookViewModel()
                {
                    Id = b.Id,
                    Title = b.Title,
                    Author = b.Author,
                    Description = b.Description,
                    ImageUrl = b.ImageUrl,
                    Category = this.context.Categories.Find(b.CategoryId).Name
                })
                .ToList()
            };

            return View(bookCollectionModel);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var categories = await this.context.Categories
                .Select(c => new CategoryViewModel()
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToListAsync();

            var bookModel = new BookFormViewModel() { Categories = categories };

            return View(bookModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(BookFormViewModel bookModel)
        {
            var categoryExists = await this.context.Categories
                .FirstOrDefaultAsync(c => c.Id == bookModel.CategoryId);

            if (categoryExists == null)
            {
                ModelState.AddModelError(nameof(bookModel.CategoryId), "Category does not exist.");
            }

            if (!ModelState.IsValid)
            {
                bookModel.Categories = await this.context.Categories
                    .Select(c => new CategoryViewModel()
                    {
                        Id = c.Id,
                        Name = c.Name
                    })
                    .ToListAsync();

                return View(bookModel);
            }

            var book = new Book()
            {
                Title = bookModel.Title,
                Author = bookModel.Author,
                Description = bookModel.Description,
                ImageUrl = bookModel.ImageUrl,
                Rating = bookModel.Rating,
                CategoryId = bookModel.CategoryId,
            };

            await this.context.Books.AddAsync(book);
            await this.context.SaveChangesAsync();

            return RedirectToAction("All", "Books");
        }

        [HttpPost]
        public async Task<IActionResult> AddToCollection(int bookId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
            {
                return BadRequest();
            }

            var book = await this.context.ApplicationUsersBooks
                .Where(aub => aub.BookId == bookId && aub.ApplicationUserId == userId)
                .FirstOrDefaultAsync();

            if (book != null)
            {
                return RedirectToAction("All", "Books");
            }

            await this.context.ApplicationUsersBooks.AddAsync(new ApplicationUserBook()
            {
                ApplicationUserId = userId,
                BookId = bookId
            });

            await this.context.SaveChangesAsync();

            return RedirectToAction("All", "Books");
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromCollection(int bookId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
            {
                return Unauthorized();
            }

            var book = await this.context.ApplicationUsersBooks
                .Where(aub => aub.BookId == bookId && aub.ApplicationUserId == userId)
                .FirstOrDefaultAsync();

            if (book == null)
            {
                return BadRequest();
            }

            this.context.ApplicationUsersBooks.Remove(book);
            await this.context.SaveChangesAsync();

            return RedirectToAction("Mine", "Books");
        }
    }
}

