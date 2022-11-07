using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renovation
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine()); // Бюджет
            double widthFloor = double.Parse(Console.ReadLine()); // Широчината на пода
            double lengthFloor = double.Parse(Console.ReadLine()); // Дължината на пода
            double sideTriangle = double.Parse(Console.ReadLine()); // Страната на триъгълника
            double heightTriangle = double.Parse(Console.ReadLine()); // Височината на триъгълника
            double priceTile = double.Parse(Console.ReadLine()); // Цената на една плочка
            double sumWorkman = double.Parse(Console.ReadLine()); // Сумата за майстора

            double areaFloor = widthFloor * lengthFloor; // Площ на пода
            double areaTile = sideTriangle * heightTriangle / 2; // Площ плочки
            double neededTile = Math.Ceiling(areaFloor / areaTile) + 5; // Необходими плочки
            double totalSum = sumWorkman + (neededTile * priceTile); // Обща сума
            double sumLeft = Math.Abs(totalSum - budget); // Оставаща сума
            double neededSum = Math.Abs(totalSum - budget); // Нужна сума
           
            if (totalSum <= budget)
            {
                Console.WriteLine($"{sumLeft:f2} lv left.");
            }
            else
            {
                Console.WriteLine($"You'll need {neededSum:f2} lv more.");
                }
        }
    }
}
