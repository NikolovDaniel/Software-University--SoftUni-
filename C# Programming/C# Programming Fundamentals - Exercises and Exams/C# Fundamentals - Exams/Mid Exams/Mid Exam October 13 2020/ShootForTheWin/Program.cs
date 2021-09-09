using System;
using System.Linq;

namespace ShootForTheWin
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] targets = Console.ReadLine().Split().Select(int.Parse).ToArray();

            string input = Console.ReadLine();

            while (input != "End")
            {
                int index = int.Parse(input);

                if (index >= 0 && index <= targets.Length - 1)
                {
                    int currentIndexValue = targets[index];

                    if (targets[index] != -1)
                    {
                        targets[index] = -1;
                    }

                    for (int i = 0; i < targets.Length; i++)
                    {
                        if (targets[i] != -1 && targets[i] > currentIndexValue)
                        {
                            targets[i] -= currentIndexValue;
                        }
                        else if (targets[i] != -1 && targets[i] <= currentIndexValue)
                        {
                            targets[i] += currentIndexValue;
                        }
                    }


                }

                input = Console.ReadLine();
            }

            int shotTargets = 0;

            for (int i = 0; i < targets.Length; i++)
            {
                if (targets[i] == -1)
                {
                    shotTargets++;
                }
            }

            Console.WriteLine($"Shot targets: {shotTargets} -> {string.Join(" ", targets)}");

        }
    }
}
