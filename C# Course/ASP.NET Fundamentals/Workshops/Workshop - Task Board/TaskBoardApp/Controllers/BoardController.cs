using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskBoardApp.Data;
using TaskBoardApp.Models.Task;
using TaskBoardApp.Models.Board;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaskBoardApp.Controllers
{
    public class BoardController : Controller
    {
        private readonly ApplicationDbContext context;

        public BoardController(ApplicationDbContext _context)
        {
            this.context = _context;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> All()
        {
            var boards = await context
                .Boards
                .Select(b => new BoardViewModel()
                {
                    Id = b.Id,
                    Name = b.Name,
                    Tasks = b.Tasks
                             .Select(t => new TaskViewModel()
                             {
                                 Id = t.Id,
                                 Title = t.Title,
                                 Description = t.Description,
                                 Owner = t.Owner.UserName
                             })
                })
                .ToListAsync();

            return View(boards);
        }
    }
}

