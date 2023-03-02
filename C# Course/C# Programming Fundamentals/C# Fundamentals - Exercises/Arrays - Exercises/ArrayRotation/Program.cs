﻿using System;
using System.Linq;

namespace ArrayRotation
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] numbers = Console.ReadLine().Split(); 

            int rotations = int.Parse(Console.ReadLine()); 


            for (int i = 0; i < rotations; i++) 
            {
                string first = numbers[0];

                for (int j = 1; j < numbers.Length; j++)
                {
                    numbers[j - 1] = numbers[j];
                }

                numbers[numbers.Length - 1] = first;

            }

            Console.WriteLine(string.Join(" ", numbers));

        }
    }
}