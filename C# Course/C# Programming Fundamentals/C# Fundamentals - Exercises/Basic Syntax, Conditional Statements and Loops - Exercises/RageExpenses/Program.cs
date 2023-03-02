using System;

namespace RageExpenses
{
    class Program
    {
        static void Main(string[] args)
        {
            int gamesLost = int.Parse(Console.ReadLine());
            double headsetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardPrice = double.Parse(Console.ReadLine());
            double displayPrice = double.Parse(Console.ReadLine());

            double totalSum = 0;

            int counterHeadset = 0;
            int counterMouse = 0;
            int counterKeyboard = 0;

            for (int i = 0; i < gamesLost; i++)
            {
                counterHeadset++;
                counterMouse++;
                
                if (counterMouse == 3 && counterHeadset == 2)
                {
                    totalSum += mousePrice + headsetPrice + keyboardPrice;
                    counterKeyboard++;
                    counterHeadset = 0;
                    counterMouse = 0;
                }
                else if (counterHeadset == 2)
                {
                    totalSum += headsetPrice;
                    counterHeadset = 0;
                }
                else if (counterMouse == 3)
                {
                    totalSum += mousePrice;
                    counterMouse = 0;
                }

                if (counterKeyboard == 2)
                {
                    totalSum += displayPrice;
                    counterKeyboard = 0;
                }
            }

            Console.WriteLine($"Rage expenses: {totalSum:f2} lv.");
        }
    }
}
