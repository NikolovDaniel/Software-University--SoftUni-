using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamGenerator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            List<Team> teams = new List<Team>();

            while (input != "END")
            {
                try
                {
                    string[] tokens = input.Split(';', StringSplitOptions.RemoveEmptyEntries);

                    if (tokens[0] == "Team")
                    {
                        Team team = new Team(tokens[1]);
                        teams.Add(team);
                    }
                    else if (tokens[0] == "Add")
                    {
                        if (teams.FirstOrDefault(x => x.Name == tokens[1]) == null)
                        {
                            Console.WriteLine($"Team {tokens[1]} does not exist.");
                        }
                        else
                        {
                            Team team = teams.FirstOrDefault(x => x.Name == tokens[1]);

                            team.Add(GetPlayer(tokens[2], int.Parse(tokens[3]), int.Parse(tokens[4]),
                                int.Parse(tokens[5]), int.Parse(tokens[6]), int.Parse(tokens[7])));

                        }
                    }
                    else if (tokens[0] == "Remove")
                    {
                        Team team = teams.FirstOrDefault(x => x.Name == tokens[1]);

                        team.Remove(tokens[2]);
                    }
                    else if (tokens[0] == "Rating")
                    {
                        if (teams.FirstOrDefault(x => x.Name == tokens[1]) == null)
                        {
                            Console.WriteLine($"Team {tokens[1]} does not exist.");
                        }
                        else
                        {
                            Team team = teams.FirstOrDefault(x => x.Name == tokens[1]);
                            Console.WriteLine($"{team.Name} - {team.Rating}");
                        }
                    }

                    input = Console.ReadLine();
                }
                catch (Exception ae)
                {
                    Console.WriteLine(ae.Message);
                    input = Console.ReadLine();
                }
            }
        }

        public static Player GetPlayer(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            Player player = new Player(name, endurance, sprint, dribble, passing, shooting);

            return player;
        }
    }
}
