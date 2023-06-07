﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaskBoardApp.Data.Models;

namespace TaskBoardApp.Data;

public class ApplicationDbContext : IdentityDbContext
{
    private IdentityUser TestUser { get; set; }
    private Board OpenBoard { get; set; }
    private Board InProgressBoard { get; set; }
    private Board DoneBoard { get; set; }

    public DbSet<Board> Boards { get; set; }
    public DbSet<Models.Task> Tasks { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
        Database.Migrate();
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder
            .Entity<Models.Task>()
            .HasOne(t => t.Board)
            .WithMany(b => b.Tasks)
            .HasForeignKey(t => t.BoardId)
            .OnDelete(DeleteBehavior.Restrict);

        SeedUsers();
        builder
            .Entity<IdentityUser>()
            .HasData(TestUser);

        SeedBoards();
        builder
            .Entity<Board>()
            .HasData(OpenBoard, InProgressBoard, DoneBoard);

        builder
            .Entity<Models.Task>()
            .HasData(new Models.Task()
            {
                Id = 1,
                Title = "Improve CSS styles",
                Description = "Implement better styling for all public pages",
                CreatedOn = DateTime.Now.AddDays(-200),
                OwnerId = TestUser.Id,
                BoardId = OpenBoard.Id
            },
            new Models.Task()
            {
                Id = 2,
                Title = "Android Client App",
                Description = "Create Android client app for the TaskBoard RESTful API",
                CreatedOn = DateTime.Now.AddDays(-5),
                OwnerId = TestUser.Id,
                BoardId = OpenBoard.Id
            },
            new Models.Task()
            {
                Id = 3,
                Title = "Desktop Client App",
                Description = "Create Windows Forms desktop app client for the TaskBoard RESTful API",
                CreatedOn = DateTime.Now.AddDays(-1),
                OwnerId = TestUser.Id,
                BoardId = OpenBoard.Id
            },
            new Models.Task()
            {
                Id = 4,
                Title = "Create Tasks",
                Description = "Implement [Create Task] page for adding new tasks",
                CreatedOn = DateTime.Now.AddDays(-1),
                OwnerId = TestUser.Id,
                BoardId = OpenBoard.Id
            });
            

        base.OnModelCreating(builder);
    }

    private void SeedUsers()
    {
        var hasher = new PasswordHasher<IdentityUser>();

        TestUser = new IdentityUser()
        {
            UserName = "test@softuni.bg",
            NormalizedUserName = "TEST@SOFTUNI.BG"
        };

        TestUser.PasswordHash = hasher.HashPassword(TestUser, "softuni");
    }

    private void SeedBoards()
    {
        OpenBoard = new Board()
        {
            Id = 1,
            Name = "Open"
        };

        InProgressBoard = new Board()
        {
            Id = 2,
            Name = "In Progress"
        };

        DoneBoard = new Board()
        {
            Id = 3,
            Name = "Done"
        };
    }
}

