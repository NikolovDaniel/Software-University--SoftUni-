using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spaceship
{
    class Program
    {
        static void Main(string[] args)
        {
            double widthShip = double.Parse(Console.ReadLine());
            double lengthShip = double.Parse(Console.ReadLine());
            double heightShip = double.Parse(Console.ReadLine());
            double avgHeight = double.Parse(Console.ReadLine());

            double areaShip = widthShip * lengthShip * heightShip;
            double areaRoom = (avgHeight + 0.40) * 2 * 2;
            double spaceFor = Math.Floor(areaShip / areaRoom);

            if (spaceFor < 3)
            {
                Console.WriteLine("The spacecraft is too small.");
            }
            else if (spaceFor > 10)
            {
                Console.WriteLine("The spacecraft is too big.");
            }
            else
            {
                Console.WriteLine($"The spacecraft holds {spaceFor} astronauts.");
            }
            
        }
    }
}
