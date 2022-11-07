using System;
using System.Collections.Generic;
using System.Linq;

namespace TruckTour
{
    class TruckTour
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Queue<int> petrol = new Queue<int>();
            Queue<int> distance = new Queue<int>();

            int[] arr;

            for (int i = 0; i < n; i++)
            {
                arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

                petrol.Enqueue(arr[0]);
                distance.Enqueue(arr[1]);
            }

            int currPetrol;

            for (int i = 0; i < n; i++)
            {

                currPetrol = petrol.Peek();

                for (int x = 0; x < n; x++)
                {
                    if (currPetrol >= distance.Peek())
                    {
                        currPetrol -= distance.Peek();

                        if (x == n - 1)
                        {
                            Console.WriteLine(i);
                            return;
                        }
                    }
                    else
                    {
                        for (int y = x; y < n; y++)
                        {
                            petrol.Enqueue(petrol.Dequeue());
                            distance.Enqueue(distance.Dequeue());
                        }
                        break;
                    }
                    petrol.Enqueue(petrol.Dequeue());
                    distance.Enqueue(distance.Dequeue());
                    currPetrol += petrol.Peek();
                }
                petrol.Enqueue(petrol.Dequeue());
                distance.Enqueue(distance.Dequeue());
            }
        }
    }
}