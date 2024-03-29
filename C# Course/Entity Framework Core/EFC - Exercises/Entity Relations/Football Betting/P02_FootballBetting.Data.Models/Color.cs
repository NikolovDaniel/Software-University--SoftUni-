﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P02_FootballBetting.Data.Models
{
    public class Color
    {
        public Color()
        {
            this.PrimaryKitTeams = new HashSet<Team>();
            this.SecondaryKitTeams = new HashSet<Team>();
        }
        
        [Key]
        public int ColorId { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        [InverseProperty(nameof(Team.PrimaryKitColor))]
        public ICollection<Team> PrimaryKitTeams { get; set; } = null!;

        [InverseProperty(nameof(Team.SecondaryKitColor))]
        public ICollection<Team> SecondaryKitTeams { get; set; } = null!;
    }
}
