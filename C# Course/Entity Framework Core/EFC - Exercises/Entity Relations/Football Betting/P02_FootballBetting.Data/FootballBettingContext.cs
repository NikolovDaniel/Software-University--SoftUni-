using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using P02_FootballBetting.Data.Models;

namespace P02_FootballBetting.Data
{
    public class FootballBettingContext : DbContext
    {

        public DbSet<Bet> Bets { get; set; } = null!;
        public DbSet<Color> Colors { get; set; } = null!;
        public DbSet<Country> Countries { get; set; } = null!;
        public DbSet<Game> Games { get; set; } = null!;
        public DbSet<Player> Players { get; set; } = null!;
        public DbSet<PlayerStatistic> PlayersStatistics { get; set; } = null!;
        public DbSet<Position> Positions { get; set; } = null!;
        public DbSet<Team> Teams { get; set; } = null!;
        public DbSet<Town> Towns { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;

        public FootballBettingContext()
        {

        }

        public FootballBettingContext(DbContextOptions options)
            :base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=KOlombus;Database=StudentSystem;Integrated Security=True;Encrypt=False");
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PlayerStatistic>(e =>
            {
                e.HasKey(e => new { e.PlayerId, e.GameId });

            });

            modelBuilder.Entity<Team>()
                .HasOne(c => c.PrimaryKitColor)
                .WithMany(c => c.PrimaryKitTeams)
                .HasForeignKey(t => t.PrimaryKitColorId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Team>()
              .HasOne(c => c.SecondaryKitColor)
              .WithMany(c => c.SecondaryKitTeams)
              .HasForeignKey(t => t.SecondaryKitColorId)
              .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Game>()
             .HasOne(g => g.AwayTeam)
             .WithMany(g => g.AwayGames)
             .HasForeignKey(g => g.AwayTeamId)
             .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Game>()
            .HasOne(g => g.HomeTeam)
            .WithMany(g => g.HomeGames)
            .HasForeignKey(g => g.HomeTeamId)
            .OnDelete(DeleteBehavior.NoAction);
        }
    }
}