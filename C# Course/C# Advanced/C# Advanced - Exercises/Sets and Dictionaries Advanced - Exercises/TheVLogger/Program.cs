using System;
using System.Collections.Generic;
using System.Linq;

namespace TheVLogger
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Dictionary<string, Dictionary<string, List<string>>> vloggers = new Dictionary<string, Dictionary<string, List<string>>>();

            while (input != "Statistics")
            {
                string[] cmds = input.Split();

                string name = cmds[0];

                if (input.Contains("joined") && cmds.Length == 4 && !vloggers.ContainsKey(name))
                {
                    vloggers.Add(name, new Dictionary<string, List<string>>()
                    {
                        {"followers", new List<string>() },
                        {"following", new List<string>() }
                    });
                }
                else if (input.Contains("followed"))
                {
                    string secName = cmds[2];

                    if (name != secName
                        && vloggers.ContainsKey(secName)
                        && !vloggers[secName]["followers"].Contains(name)
                        && vloggers.ContainsKey(name))
                    {
                        vloggers[secName]["followers"].Add(name);
                        vloggers[name]["following"].Add(secName);
                    }

                }
                input = Console.ReadLine();
            }

            

            Queue<List<string>> vlogStats = new Queue<List<string>>();

            foreach (var vlogger in vloggers)
            {
                vlogStats.Enqueue(new List<string>()
                { vlogger.Key,
                vloggers[vlogger.Key]["followers"].Count.ToString(),
                vloggers[vlogger.Key]["following"].Count.ToString()
                });
            }


            int count = 1;
            int maxFollowers = 0;
            int minFollowing = 0;
            string bestName = string.Empty;

            while (vlogStats.Count > 0)
            {
                List<string> currStats = vlogStats.Dequeue();

                string name = currStats[0];
                int followers = int.Parse(currStats[1]);
                int following = int.Parse(currStats[2]);

                if (followers == maxFollowers)
                {
                    if (followers == maxFollowers && following < minFollowing)
                    {
                        maxFollowers = followers;
                        minFollowing = following;
                        bestName = name;
                    }
                }
                else if (followers > maxFollowers)
                {
                    maxFollowers = followers;
                    minFollowing = following;
                    bestName = name;
                }
            }

            Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");
            Console.WriteLine($"{count}. {bestName} : {maxFollowers} followers, {minFollowing} following");
            foreach (var followers in vloggers[bestName]["followers"].OrderBy(x => x))
            {
                Console.WriteLine($"*  {followers}");
            }
            vloggers.Remove(bestName);

            count = 2;

            foreach (var vlog in vloggers.OrderByDescending(x => x.Value["followers"].Count).ThenBy(x => x.Value["following"].Count))
            {
                Console.WriteLine($"{count}. {vlog.Key} : {vlog.Value["followers"].Count} followers, {vlog.Value["following"].Count} following");
                count++;
            }
        }
    }
}
