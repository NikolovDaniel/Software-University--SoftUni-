using System;

namespace BalancedBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int closeCount = 0;
            int openCount = 0;

            for (int i = 0; i < n; i++)
            {
                string brackets = Console.ReadLine();

                if (brackets == "(") openCount++;
                else if (brackets == ")")
                {
                    closeCount++;
                    
                    if(openCount - closeCount != 0)
                    {
                        Console.WriteLine("UNBALANCED");
                        return;
                    }
                }               
            }
            if (openCount - closeCount == 0) Console.WriteLine("BALANCED");
            else Console.WriteLine("UNBALANCED");
        }
    }
}
