using System;

namespace DateModify
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] timeOne = Console.ReadLine().Split();
            string[] timeTwo = Console.ReadLine().Split();

            DateTime dateOne = new DateTime(int.Parse(timeOne[0]), int.Parse(timeOne[1]), int.Parse(timeOne[2]));
            DateTime dateTwo = new DateTime(int.Parse(timeTwo[0]), int.Parse(timeTwo[1]), int.Parse(timeTwo[2]));

            DateModifier modifier = new DateModifier();

            modifier.DayDifference(dateOne, dateTwo);

            Console.WriteLine(modifier.Days);
        }
    }
}
