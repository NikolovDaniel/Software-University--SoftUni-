using System;
using System.Collections.Generic;
using System.Linq;

namespace CardsGame
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> playerOne = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            List<int> playerTwo = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            while (playerOne.Count != 0 && playerTwo.Count != 0) 
            {

                int playerOneCard = playerOne[0];
                int playerTwoCard = playerTwo[0];

                if(playerOneCard > playerTwoCard)
                {
                    playerOne.Add(playerOneCard);
                    playerOne.Add(playerTwoCard);
                }
                else if(playerTwoCard > playerOneCard)
                {
                    playerTwo.Add(playerTwoCard);
                    playerTwo.Add(playerOneCard);
                }

                playerOne.RemoveAt(0);
                playerTwo.RemoveAt(0);
              
            }

            if (playerOne.Count == 0)
            {
                Console.WriteLine($"Second player wins! Sum: {playerTwo.Sum()}");
            }
            else Console.WriteLine($"First player wins! Sum: {playerOne.Sum()}");
        }
    }
}
