﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {

            string name1 = Console.ReadLine();
            string name2 = Console.ReadLine();
            string age = Console.ReadLine();
            string town = Console.ReadLine();

            Console.WriteLine(" You are {0} {1}, a {2}-years old person from {3}.", name1, name2, age, town);

        }
    }
}
