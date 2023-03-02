using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballTeamGenerator
{
    public class Team
    {
        private List<Player> TeamCollection;
        private string name;
        public int Rating => CalculateAverage();


        public Team(string name)
        {
            this.Name = name;
            this.TeamCollection = new List<Player>();
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("A name should not be empty.");
                }
                else
                {
                    name = value;
                }
            }
        }

        public void Add(Player player)
        {
            if (!TeamCollection.Contains(player))
            {
                TeamCollection.Add(player);
            }
        }
        public void Remove(string player)
        {
            if (TeamCollection.FirstOrDefault(x => x.Name == player) == null)
            {
                Console.WriteLine($"Player {player} is not in {this.Name} team.");
            }
            else
            {
                Player playerToRemove = TeamCollection.FirstOrDefault(x => x.Name == player);
                TeamCollection.Remove(playerToRemove);
            }
        }
        private int CalculateAverage()
        {
            if (TeamCollection.Count == 0) return 0;

            int sum = 0;

            foreach (var player in TeamCollection)
            {
                sum += player.SkillLevel;
            }

            return sum / TeamCollection.Count;
        }
    }
}
