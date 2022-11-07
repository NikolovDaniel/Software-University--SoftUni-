using System;

namespace ImplementingList
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            CustomList list = new CustomList();

            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);
            list.Add(6);
            list.Add(7);
            list.Add(8);

            Console.WriteLine(list.RemoveAt(0));

            Console.WriteLine(list.RemoveAt(0));

            list.Insert(0, 2);
            list.Insert(0, 1);

            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }

        }
    }
}
