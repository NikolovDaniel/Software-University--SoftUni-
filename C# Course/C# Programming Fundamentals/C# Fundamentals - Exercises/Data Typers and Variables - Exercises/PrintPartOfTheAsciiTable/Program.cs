﻿using System;

namespace PrintPartOfTheAsciiTable
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int stop = int.Parse(Console.ReadLine());

            for (int i = start; i <= stop; i++)
            {                                         
                Console.Write((char)i + " ");
            }
        }
    }
}
