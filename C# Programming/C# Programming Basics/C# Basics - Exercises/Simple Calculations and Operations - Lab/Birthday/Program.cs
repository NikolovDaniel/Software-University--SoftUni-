using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Birthday
{
    class Program
    {
        static void Main(string[] args)
        {
            double aquariumLength = double.Parse(Console.ReadLine());
            double aquariumWidght = double.Parse(Console.ReadLine());
            double aquariamHeight = double.Parse(Console.ReadLine());
            double percent = double.Parse(Console.ReadLine());

            double aquariumCapacity = aquariumLength * aquariumWidght * aquariamHeight;
            double totalLiters  = aquariumCapacity * 0.001;
            double calculatedPercent = percent * 0.01;
            double litersNeeded = totalLiters * (1 - calculatedPercent);

            Console.WriteLine("{0:F3}", litersNeeded);



        }
    }
}
