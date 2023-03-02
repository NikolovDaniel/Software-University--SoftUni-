using System;

namespace PizzaCalories
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                string[] pizzaInfo = Console.ReadLine().Split();

                string[] dough = Console.ReadLine().Split();

                Dough doughA = new Dough(dough[1], dough[2], double.Parse(dough[3]));

                Pizza pizza = new Pizza(pizzaInfo[1], doughA);

                string input = Console.ReadLine();

                while (input != "END")
                {
                    string[] toppings = input.Split();

                    Topping topping = new Topping(toppings[1], double.Parse(toppings[2]));

                    pizza.AddTopping(topping);

                    input = Console.ReadLine();
                }


                Console.WriteLine($"{pizza.Name} - {pizza.TotalCalories:f2} Calories.");
            }
            catch (Exception ae)
            {
                Console.WriteLine(ae.Message);
            }
        }
    }
}
