﻿using ContactsPlatform.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ContactsPlatform.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<ApplicationUserContact> ApplicationUsersContacts { get; set; } = null!;
        public DbSet<Contact> Contacts { get; set; } = null!;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ApplicationUserContact>()
                .HasKey(au => new { au.ApplicationUserId, au.ContactId });

            builder
             .Entity<Contact>()
             .HasData(new Contact()
             {
                 Id = 1,
                 FirstName = "Bruce",
                 LastName = "Wayne",
                 PhoneNumber = "+359881223344",
                 Address = "Gotham City",
                 Email = "imbatman@batman.com",
                 Website = "www.batman.com"
             });

            base.OnModelCreating(builder);
        }
    }
}