using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_Titles
{
    class Program
    {
        static void Main(string[] args)
        {
            double age = double.Parse(Console.ReadLine());
            char gender = Console.ReadLine()[0];

            if (gender == 'f')
            {
                if (age > 0 && age < 16)
                {
                    Console.WriteLine("Miss");
                }
                else if (age >= 16)
                {
                    Console.WriteLine("Ms.");
                }
            }     
            else if (gender == 'm')
            {
                if ( age < 16 && age > 0)
                {
                    Console.WriteLine("Master");
                }
                else if (age >= 16 )
                {
                    Console.WriteLine("Mr.");
                }
            }
        }
    }
}
