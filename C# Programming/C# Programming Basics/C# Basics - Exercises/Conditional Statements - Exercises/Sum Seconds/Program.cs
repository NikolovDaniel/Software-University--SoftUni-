using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sum_Seconds
{
    class Program
    {
        static void Main(string[] args)
        {
            int FirstTime = int.Parse(Console.ReadLine());
            int SecondTime = int.Parse(Console.ReadLine());
            int ThirdTime = int.Parse(Console.ReadLine());

            int totalTime = FirstTime + SecondTime + ThirdTime;

            int minutes = totalTime / 60;
            int seconds = totalTime % 60;

            if(seconds < 10)
            {
                Console.WriteLine("{0}:0{1}",minutes,seconds);
            }
            else
            {
                Console.WriteLine("{0}:{1}",minutes,seconds);
            }
            
        }
    }
}
