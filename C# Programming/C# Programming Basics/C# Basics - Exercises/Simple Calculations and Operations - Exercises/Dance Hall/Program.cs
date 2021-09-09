using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dance_Hall
{
    class Program
    {
        static void Main(string[] args)
        { 
            

            double Length  = double.Parse(Console.ReadLine());
            double Width = double.Parse(Console.ReadLine());
            double AreaForWardrobe = double.Parse(Console.ReadLine());

            double AreaOfHall = (Length * 100) * (Width * 100); // ( 50 * 100 ) * ( 25 * 100 ) = 12 500 000
            double AreaOfWardrobe = (AreaForWardrobe * 100) * ( AreaForWardrobe * 100); // 200 * 200 = 40 000
            double AreaOfBench = AreaOfHall / 10; // 12 500 000 / 10 = 1 250 000
            double FreeSpace = AreaOfHall - AreaOfWardrobe - AreaOfBench; // 12 500 000 - 40 000 - 1 250 000 =  11 210 000
            double NumOfDancers = FreeSpace / (40 + 7000); // 11 210 000 / ( 40 + 7000 ) = 1592

            Console.WriteLine("{0:F0}", Math.Floor(NumOfDancers)); 




        }
    }
}
