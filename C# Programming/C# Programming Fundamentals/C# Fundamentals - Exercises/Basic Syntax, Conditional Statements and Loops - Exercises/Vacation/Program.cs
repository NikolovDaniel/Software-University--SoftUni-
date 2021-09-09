using System;

namespace Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            int people = int.Parse(Console.ReadLine());
            string typePeople = Console.ReadLine();
            string day = Console.ReadLine();

            double totalSum = 0;

            switch (day)
            {
                case "Friday":
                    switch (typePeople)
                    {
                        case "Students":
                            totalSum = people * 8.45;
                            break;
                        case "Business":
                            if (people >= 100) totalSum = (people - 10) * 10.90;
                            else totalSum = people * 10.90;
                            break;
                        case "Regular":
                            totalSum = people * 15;
                            break;
                    }                   
                    break;

                case "Saturday":
                    switch (typePeople)
                    {
                        case "Students":
                            totalSum = people * 9.80;
                            break;
                        case "Business":
                            if (people >= 100) totalSum = (people - 10) * 15.60;
                            else totalSum = people * 15.60;
                            break;
                        case "Regular":
                            totalSum = people * 20;
                            break;
                    }                   
                    break;

                case "Sunday":
                    switch (typePeople)
                    {
                        case "Students":
                            totalSum = people * 10.46;
                            break;
                        case "Business":
                            if (people >= 100) totalSum = (people - 10) * 16;
                            else totalSum = people * 16;
                            break;
                        case "Regular":
                            totalSum = people * 22.50;
                            break;
                    }                  
                    break;
            }

            if (people >= 30 && typePeople == "Students")
            {
                totalSum -= totalSum * 0.15;
            }
            else if (people >= 10 && people <= 20 && typePeople == "Regular")
            {
                totalSum -= totalSum * 0.05;
            }

            Console.WriteLine($"Total price: {totalSum:f2}");

        }
    }
}
