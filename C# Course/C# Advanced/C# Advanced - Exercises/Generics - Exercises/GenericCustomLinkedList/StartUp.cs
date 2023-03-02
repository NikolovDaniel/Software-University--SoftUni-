using System;

namespace GenericCustomLinkedList
{
    class StartUp
    {
        static void Main(string[] args)
        {
            CustomLinkedList<string> list = new CustomLinkedList<string>(new string[] { "Pesho", "Gosho", "Petko" });

            list.AddFirst("Daniel");
            list.AddLast("Nikolov");

            list.ForEach(n => Console.WriteLine(n));

            list.RemoveFirst();
            list.RemoveLast();

            string[] arr = list.ToArray();

            Console.WriteLine(string.Join(" ", arr));
        }
    }
}
