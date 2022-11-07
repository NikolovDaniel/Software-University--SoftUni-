using System;
using System.Collections.Generic;

namespace TrafficJam
{
    class Program
    {
        static void Main(string[] args)
        {
            int carsToPass = int.Parse(Console.ReadLine());

            int count = 0;

            Queue<string> cars = new Queue<string>();

            string input = Console.ReadLine();

            while (input != "end")
            {

                if (input == "green")
                {
                    for (int i = 0; i < carsToPass; i++)
                    {
                        if (cars.Count > 0)
                        {
                            Console.WriteLine($"{cars.Dequeue()} passed!");
                            count++;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                else
                {
                    cars.Enqueue(input);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"{count} cars passed the crossroads.");


        }
    }
}
