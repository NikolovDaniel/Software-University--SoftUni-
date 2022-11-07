using System;
using System.Collections.Generic;

namespace ValidUsernames
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] usernames = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

            List<string> result = new List<string>();

            for (int i = 0; i < usernames.Length; i++)
            {

                string currentUsername = usernames[i];
                bool isCorrect = false;

                if (currentUsername.Length >= 3 && currentUsername.Length <= 16)
                {
                    for (int j = 0; j < currentUsername.Length; j++)
                    {
                        if (char.IsDigit(currentUsername[j]) || char.IsLetter(currentUsername[j]) || currentUsername[j] == '-' || currentUsername[j] == '_')
                        {
                            isCorrect = true;
                        }
                        else
                        {
                            isCorrect = false;
                            break;
                        }
                    }
                }

                if (isCorrect)
                {
                    result.Add(currentUsername);
                }

            }

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

        }
    }
}
