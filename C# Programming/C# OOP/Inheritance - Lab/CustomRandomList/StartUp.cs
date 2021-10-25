using System;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] items = new string[] { "a", "b", "c" };
            RandomList list = new RandomList(items);

            Console.WriteLine(list.RandomString());
        }
    }
}
