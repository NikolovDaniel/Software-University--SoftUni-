using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guild
{
    public class Guild
    {
        private List<Player> Roster;
        public int Count { get; private set; }
        public string Name { get; set; }
        public int Capacity { get; private set; }

        public Guild(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            Roster = new List<Player>();
        }

        public void AddPlayer(Player player)
        {
            if (Roster.Count < this.Capacity)
            {
                Roster.Add(player);
                Count++;
            }
        }
        public bool RemovePlayer(string name)
        {
            foreach (var player in Roster)
            {
                if (player.Name == name)
                {
                    Roster.Remove(player);
                    Count--;
                    return true;
                }
            }

            return false;
        }
        public void PromotePlayer(string name)
        {
            foreach (var player in Roster)
            {
                if (player.Name == name && player.Rank != "Member")
                {
                    player.Rank = "Member";
                }
            }
        }
        public void DemotePlayer(string name)
        {
            foreach (var player in Roster)
            {
                if (player.Name == name && player.Rank != "Trial")
                {
                    player.Rank = "Trial";
                }
            }
        }
        public Player[] KickPlayersByClass(string inputClass)
        {
            List<Player> result = new List<Player>();

            foreach (Player player in Roster)
            {
                if (player.Class == inputClass)
                {
                    result.Add(player);
                    Count--;
                }
            }

            foreach (var player in result)
            {
                Roster.Remove(player);
            }

            return result.ToArray();
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Players in the guild: {this.Name}");

            foreach (var player in Roster)
            {
                sb.AppendLine($"Player {player.Name}: {player.Class}");
                sb.AppendLine($"Rank: {player.Rank}");
                sb.AppendLine($"Description: {player.Description}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
