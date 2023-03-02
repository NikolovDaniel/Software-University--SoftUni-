using System;
using System.Collections.Generic;
using System.Linq;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> cars = new Queue<string>();

            int green = int.Parse(Console.ReadLine());
            int window = int.Parse(Console.ReadLine());
            int count = 0;

            while (true)
            {
                string car = Console.ReadLine();

                int greenSeconds = green;
                int passSeconds = window;

                if (car == "END")
                {
                    Console.WriteLine("Everyone is safe.");
                    Console.WriteLine($"{count} total cars passed the crossroads.");
                    return;
                }
                else if (car == "green")
                {
                    while (greenSeconds > 0 && cars.Count != 0)
                    {
                        string firstCar = cars.Dequeue();
                        greenSeconds -= firstCar.Length;

                        if (greenSeconds >= 0)
                        {
                            count++;
                        }
                        else
                        {
                            passSeconds += greenSeconds;

                            if (passSeconds < 0)
                            {
                                Console.WriteLine("A crash happened!");
                                Console.WriteLine($"{firstCar} was hit at {firstCar[firstCar.Length + passSeconds]}.");
                                return;
                            }

                            count++;
                        }
                    }
                }
                else
                {
                    cars.Enqueue(car);
                }
            }
        }
    }
}
