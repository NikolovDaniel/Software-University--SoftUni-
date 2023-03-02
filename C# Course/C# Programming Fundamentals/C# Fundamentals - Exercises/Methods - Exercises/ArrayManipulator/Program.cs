using System;
using System.Linq;

namespace ArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] arrayOne = Console.ReadLine().Split().Select(int.Parse).ToArray();

            string manipulation = Console.ReadLine();

            while (manipulation != "end")
            {




                manipulation = Console.ReadLine();
            }





        }       
    }
}
