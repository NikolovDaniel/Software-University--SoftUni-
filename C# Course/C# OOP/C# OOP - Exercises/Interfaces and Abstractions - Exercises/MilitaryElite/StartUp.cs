using System;
using System.Collections.Generic;
using System.Linq;

namespace MilitaryElite
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Soldier> soldiers = new List<Soldier>();

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (tokens[0] == "Private")
                {
                    Private newPrivate = new Private(tokens[1], tokens[2], tokens[3], decimal.Parse(tokens[4]));

                    soldiers.Add(newPrivate);
                }

                if (tokens[0] == "LeutenantGeneral" || tokens[0] == "LieutenantGeneral")
                {
                    LeutenantGeneral leutenant = new LeutenantGeneral(tokens[1], tokens[2], tokens[3], decimal.Parse(tokens[4]));

                    for (int i = 5; i < tokens.Length; i++)
                    {
                        leutenant.Privates.Add(soldiers.First(x => x.Id == tokens[i]));
                    }

                    soldiers.Add(leutenant);
                }

                if (tokens[0] == "Engineer")
                {
                    try
                    {
                        Engineer engineer = new Engineer(tokens[1], tokens[2], tokens[3], decimal.Parse(tokens[4]), tokens[5]);

                        for (int i = 6; i < tokens.Length; i += 2)
                        {
                            Repair repair = new Repair(tokens[i], int.Parse(tokens[i + 1]));
                            engineer.Repairs.Add(repair);
                        }

                        soldiers.Add(engineer);
                    }
                    catch (Exception)
                    {

                    }
                }

                if (tokens[0] == "Commando")
                {
                    try
                    {
                        Commando commando = new Commando(tokens[1], tokens[2], tokens[3], decimal.Parse(tokens[4]), tokens[5]);

                        for (int i = 6; i < tokens.Length; i += 2)
                        {
                            try
                            {
                                Mission mission = new Mission(tokens[i], tokens[i + 1]);
                                commando.Missions.Add(mission);
                            }
                            catch (Exception)
                            {

                            }
                        }

                        soldiers.Add(commando);
                    }
                    catch (Exception)
                    {

                    }
                }

                if (tokens[0] == "Spy")
                {
                    Spy spy = new Spy(tokens[1], tokens[2], tokens[3], int.Parse(tokens[4]));

                    soldiers.Add(spy);
                }

                input = Console.ReadLine();
            }

            soldiers.ForEach(x => Console.WriteLine(x));
        }
    }
}
