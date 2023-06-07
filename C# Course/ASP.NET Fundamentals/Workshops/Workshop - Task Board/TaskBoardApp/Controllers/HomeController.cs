using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskBoardApp.Data;
using TaskBoardApp.Models;
using TaskBoardApp.Models.Task;

namespace TaskBoardApp.Controllers;

public class HomeController : Controller
{

    private readonly ApplicationDbContext context;

    public HomeController(ApplicationDbContext context)
    {
        this.context = context;
    }
    

    public async Task<IActionResult> Index()
    {
        var taskBoards = await this.context
            .Boards
            .Select(b => b.Name)
            .Distinct()
            .ToListAsync();

        var tasksCount = new List<HomeBoardModel>();

        foreach (var boardName in taskBoards)
        {
            var taskInBoard = this.context.Tasks.Where(t => t.Board.Name == boardName).Count();

            tasksCount.Add(new HomeBoardModel()
            {
                BoardName = boardName,
                TasksCount = taskInBoard
            });
        }

        var userTasksCount = -1;

        if (User.Identity.IsAuthenticated)
        {
            var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            userTasksCount = this.context.Tasks.Where(t => t.OwnerId == currentUserId).Count();
        }

        var homeModel = new HomeViewModel()
        {
            AllTasksCount = this.context.Tasks.Count(),
            BoardsWithTasksCount = tasksCount,
            UserTasksCount = userTasksCount
        };

        return View(homeModel);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

