using System;

namespace CounterStrike
{
    class Program
    {
        static void Main(string[] args)
        {
            int energy = int.Parse(Console.ReadLine());
            string battleEnergy = Console.ReadLine();
            int winCounter = 0;
            int battleCounter = 0;

            while (battleEnergy != "End of battle")
            {

                int energyToRemove = int.Parse(battleEnergy);

                if (energy - energyToRemove < 0)
                {                    
                    Console.WriteLine($"Not enough energy! Game ends with {winCounter} won battles and {energy} energy");
                    return;
                }
                else
                {
                    energy -= energyToRemove;
                    battleCounter++;
                    winCounter++;
                }

                if (battleCounter == 3)
                {
                    energy += winCounter;
                    battleCounter = 0;
                }

                battleEnergy = Console.ReadLine();
            }

            Console.WriteLine($"Won battles: {winCounter}. Energy left: {energy}");

        }
    }
}
