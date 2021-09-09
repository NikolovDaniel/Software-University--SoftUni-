using System;

namespace PokeMon
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());
            
            int pokeCounter = 0;
            double startPosition = n;

            while (n >= m)
            {               
                n -= m;
                
                if (startPosition / 2 == n && y > 0)
                {
                    if (n >= y) n /= y;
                }

                pokeCounter++;
            }
            Console.WriteLine(n);
            Console.WriteLine(pokeCounter);
        }
    }
}
