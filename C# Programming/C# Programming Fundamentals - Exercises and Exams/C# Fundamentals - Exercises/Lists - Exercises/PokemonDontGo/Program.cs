using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonDontGo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                                       .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                       .Select(int.Parse)
                                       .ToList();

            int sum = 0;

            while (numbers.Count != 0)
            {
                int command = int.Parse(Console.ReadLine());

                if (command < 0)
                {
                    command = 0;
                    sum += numbers[command];
                    int power = numbers[command];
                    numbers.RemoveAt(command); 
                    numbers.Insert(0, numbers[numbers.Count - 1]);

                    for (int i = 0; i < numbers.Count; i++)
                    {
                        if (power >= numbers[i]) numbers[i] += power;
                        else numbers[i] -= power;
                    }
                   
                }

                else if (command > numbers.Count - 1)
                {
                    command = numbers.Count - 1;
                    sum += numbers[command];
                    int power = numbers[command];
                    numbers.RemoveAt(command);
                    numbers.Insert(numbers.Count, numbers[0]);

                    for (int i = 0; i < numbers.Count; i++)
                    {
                        if (power >= numbers[i]) numbers[i] += power;
                        else numbers[i] -= power;
                    }
                    
                }

                else
                {

                    sum += numbers[command];
                    int power = numbers[command];
                    numbers.RemoveAt(command);

                    for (int i = 0; i < numbers.Count; i++)
                    {
                        if (power >= numbers[i]) numbers[i] += power;
                        else numbers[i] -= power;
                    }

                }              
            }
            Console.WriteLine(sum);
        }
    }
}
