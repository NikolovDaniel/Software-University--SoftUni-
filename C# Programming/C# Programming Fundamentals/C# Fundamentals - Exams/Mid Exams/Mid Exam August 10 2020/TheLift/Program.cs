using System;
using System.Collections.Generic;
using System.Linq;

namespace TheLift
{
    class Program
    {
        static void Main(string[] args)
        {
            int people = int.Parse(Console.ReadLine());

            List<int> wagon = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            bool isEmpty = false;

            for (int i = 0; i < wagon.Count; i++)
            {
                for (int a = wagon[i]; a < 4; a++)
                {
                    wagon[i]++;
                    people--;
                    
                    if (people == 0) break;
                                   
                }             
                if (people == 0) break;              
            }

            for (int i = 0; i < wagon.Count; i++)
            {
                if (wagon[i] < 4)
                {
                    isEmpty = true;
                    break;
                }
            }


            if (people == 0 && !isEmpty)
            {
                Console.WriteLine(string.Join(" ", wagon));
            }
            else if (people == 0 && isEmpty)
            {
                Console.WriteLine($"The lift has empty spots!");
                Console.WriteLine(string.Join(" ", wagon));
            }
            else if (people != 0)
            {
                Console.WriteLine($"There isn't enough space! {people} people in a queue!");
                Console.WriteLine(string.Join(" ", wagon));
            }
            

        }
    }
}
