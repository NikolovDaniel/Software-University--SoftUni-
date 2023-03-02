using System;

namespace DoublyLinkedList
{
    class StartUp
    {
        static void Main(string[] args)
        {
            CustomLinkedList list = new CustomLinkedList(new int[] { 5, 7, 12 });

            list.AddFirst(50);
            list.AddFirst(13);
            list.AddFirst(14);
            list.AddFirst(15);

            int[] arr = list.ToArray();

            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }

        }
    }
}
