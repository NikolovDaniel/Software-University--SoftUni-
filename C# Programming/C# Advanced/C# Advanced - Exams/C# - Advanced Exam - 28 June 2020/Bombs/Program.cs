using System;
using System.Collections.Generic;
using System.Linq;

namespace Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrBombEffect = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int[] arrBombCasing = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            Queue<int> bombEffect = new Queue<int>(arrBombEffect);
            Stack<int> bombCasing = new Stack<int>(arrBombCasing);

            Dictionary<string, int> resultBombs = new Dictionary<string, int>()
            {
                { "Datura Bombs", 0 },
                { "Cherry Bombs", 0 },
                { "Smoke Decoy Bombs", 0 }
            };

            while (bombCasing.Count > 0 && bombEffect.Count > 0)
            {
                if (IsSameValue(bombCasing.Peek(), bombEffect.Peek()))
                {
                    string bomb = CreateBomb(bombCasing.Pop(), bombEffect.Dequeue());

                    resultBombs[bomb]++;
                }
                else
                {
                    bombCasing.Push(bombCasing.Pop() - 5);
                }

                if (resultBombs.Where(x => x.Value >= 3).ToList().Count == 3)
                {
                    Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
                    Console.WriteLine(PrintBombEffect(bombEffect));
                    Console.WriteLine(PrintBombCasing(bombCasing));
                    Console.WriteLine(PrintDictionaryValues(resultBombs));
                    return;
                }
            }

            Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            Console.WriteLine(PrintBombEffect(bombEffect));
            Console.WriteLine(PrintBombCasing(bombCasing));
            Console.WriteLine(PrintDictionaryValues(resultBombs));

        }

        private static string PrintDictionaryValues(Dictionary<string, int> bombs)
        {
            int countCherryBombs = bombs["Cherry Bombs"];
            int coutnDaturaBombs = bombs["Datura Bombs"];
            int countSmokeDecoyBombs = bombs["Smoke Decoy Bombs"];

            return $"Cherry Bombs: {countCherryBombs}\nDatura Bombs: {coutnDaturaBombs}\nSmoke Decoy Bombs: {countSmokeDecoyBombs}";
        }
        private static string PrintBombCasing(Stack<int> bombs)
        {
            if (bombs.Any())
            {
                return $"Bomb Casings: {string.Join(", ", bombs)}";
            }
            else
            {
                return "Bomb Casings: empty";
            }
        }
        private static string PrintBombEffect(Queue<int> bombs)
        {
            if (bombs.Any())
            {
                return $"Bomb Effects: {string.Join(", ", bombs)}";
            }
            else
            {
                return "Bomb Effects: empty";
            }
        }
        private static string CreateBomb(int a, int b)
        {
            if (a + b == 40) return "Datura Bombs";
            else if (a + b == 60) return "Cherry Bombs";
            else if (a + b == 120) return "Smoke Decoy Bombs";

            return null;
        }

        private static bool IsSameValue(int a, int b)
        {
            if (a + b == 40) return true;
            else if (a + b == 60) return true;
            else if (a + b == 120) return true;

            return false;
        }
    }
}
