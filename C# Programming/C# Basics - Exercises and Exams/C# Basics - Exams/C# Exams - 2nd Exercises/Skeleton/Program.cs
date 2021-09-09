using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skeleton
{
    class Program
    {
        static void Main(string[] args)
        {
            int minutes = int.Parse(Console.ReadLine()); // Минути на контролата
            int seconds = int.Parse(Console.ReadLine()); // Секунди на контролата
            double length = double.Parse(Console.ReadLine()); // Дължина на улея в метри           
            int meters100 = int.Parse(Console.ReadLine()); // Секунди за изминаване на 100 метра

            double minToSec = minutes * 60 + seconds; // Изчисляване на контролата в секунди
            double slowDown = (length / 120) * 2.5; // Общо намалено време
            double marinTime = (length / 100) * meters100 - slowDown; //Времето на Марин
            double noTime = marinTime - minToSec; // Контролно време    

            if (marinTime <= minToSec)
            {
                Console.WriteLine("Marin Bangiev won an Olympic quota!");
                Console.WriteLine($"His time is {marinTime:f3}.");
            }
            else
            {
                Console.WriteLine($"No, Marin failed! He was {noTime:f3} second slower.");
            }



        }
    }
}
