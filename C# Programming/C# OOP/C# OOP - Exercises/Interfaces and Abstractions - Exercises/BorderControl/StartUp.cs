using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Creatures> creatures = new List<Creatures>();

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] tokens = input.Split();

                if (tokens.Length == 2)
                {
                    Robot robot = new Robot(tokens[0], tokens[1]);

                    creatures.Add(robot);
                }
                else
                {
                    Citizen citizen = new Citizen(tokens[0], int.Parse(tokens[1]), tokens[2]);

                    creatures.Add(citizen);
                }

                input = Console.ReadLine();
            }

            string wordsToContain = Console.ReadLine();

            creatures.Where(x => x.Id.EndsWith(wordsToContain)).ToList().ForEach(x => Console.WriteLine(x.Id));

            //foreach (var item in creatures)
            //{
            //    CheckId(item.Id, wordsToContain);
            //}


            //private static void CheckId(string id, string wordsToContain)
            //{
            //    //CHECK IF THE ID CONTAINS THE GIVEN LETTERS
            //    bool isTrue = false;
            //    int counter = wordsToContain.Length - 1;

            //    if (id.Length >= wordsToContain.Length)
            //    {
            //        for (int i = id.Length - 1; i > id.Length - wordsToContain.Length; i--)
            //        {
            //            if (id[i] == wordsToContain[counter])
            //            {
            //                isTrue = true;
            //            }
            //            else
            //            {
            //                isTrue = false;
            //                break;
            //            }
            //            counter--;
            //        }

            //        if (isTrue)
            //        {
            //            Console.WriteLine(id);
            //        }
            //    }
        }
    }
}
