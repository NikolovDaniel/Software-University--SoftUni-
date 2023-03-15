using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P02_FootballBetting.Data.Models
{
    public class Team
    {
        public Team()
        {
            this.AwayGames = new HashSet<Game>();
            this.HomeGames = new HashSet<Game>();
            this.Players = new HashSet<Player>();
        }

        [Key]
        public int TeamId { get; set; }

        [Required]
        public string Name { get; set; } = null!;
        
        public string LogoUrl { get; set; } = null!;
        [Required]
        public string Initials { get; set; } = null!;

        [Required]
        public decimal Budget { get; set; }

        [ForeignKey(nameof(PrimaryKitColor))]
        public int PrimaryKitColorId { get; set; } 
        public Color PrimaryKitColor { get; set; } = null!;

        [ForeignKey(nameof(SecondaryKitColor))]
        public int SecondaryKitColorId { get; set; } 
        public Color SecondaryKitColor { get; set; } = null!;

        [ForeignKey(nameof(Town))]
        public int TownId { get; set; } 
        public Town Town { get; set; } = null!;

        [InverseProperty(nameof(Game.HomeTeam))] // Might not need to be with "Id"
        public ICollection<Game> HomeGames { get; set; } = null!;

        [InverseProperty(nameof(Game.AwayTeam))] // Might not need to be with "Id"
        public ICollection<Game> AwayGames { get; set; } = null!;

        public ICollection<Player> Players { get; set; } = null!;
    }
}