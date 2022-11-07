using System;
using System.Collections.Generic;
using System.Linq;

namespace TheFightForGondor
{
    class Program
    {
        static void Main(string[] args)
        {
            int waves = int.Parse(Console.ReadLine());
            int[] numPlates = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> plates = new Queue<int>(numPlates);
            Stack<int> orcsToPrint = new Stack<int>();

            bool isDestroyed = false;

            for (int i = 1; i <= waves; i++)
            {
                Stack<int> waveOrcs = new Stack<int>(Console.ReadLine().Split()
                    .Select(int.Parse).ToArray());

                if (i % 3 == 0)
                {
                    int addPlate = int.Parse(Console.ReadLine());
                    plates.Enqueue(addPlate);
                }

                while (waveOrcs.Count != 0 && plates.Count != 0)
                {
                    if (waveOrcs.Peek() > plates.Peek())
                    {
                        waveOrcs.Push(waveOrcs.Pop() - plates.Dequeue());
                    }                    
                    else if (plates.Peek() > waveOrcs.Peek())
                    {
                        Queue<int> updatedQueue = new Queue<int>();

                        updatedQueue.Enqueue(plates.Dequeue() - waveOrcs.Pop());

                        for (int j = 0; j < plates.Count; j++)
                        {
                            updatedQueue.Enqueue(plates.ElementAt(j));
                        }

                        plates = updatedQueue;
                    }
                    else
                    {
                        waveOrcs.Pop();
                        plates.Dequeue();
                    }

                    if (plates.Count == 0)
                    {
                        isDestroyed = true;
                        orcsToPrint = waveOrcs;
                        break;
                    }
                }
            }

            if (isDestroyed)
            {
                Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");
                Console.WriteLine($"Orcs left: {string.Join(", ", orcsToPrint)} ");
            }
            else
            {
                Console.WriteLine("The people successfully repulsed the orc's attack.");
                Console.WriteLine($"Plates left: {string.Join(", ", plates)}");
            }
        }
    }
}
