using System;
using System.Collections.Generic;
using System.Linq;

namespace TheImitationGame
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();
            List<string> decodedMessage = new List<string>();

            for (int i = 0; i < message.Length; i++)
            {
                decodedMessage.Add(message[i].ToString());
            }

            string[] input = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries);

            while (input[0] != "Decode")
            {

                string cmd = input[0];

                if (cmd == "ChangeAll")
                {
                    string letter = input[1];
                    string replacement = input[2];

                    for (int i = 0; i < decodedMessage.Count; i++)
                    {
                        if (decodedMessage[i] == letter)
                        {
                            decodedMessage[i] = replacement;
                        }
                    }
                }
                else if (cmd == "Insert")
                {
                    int index = int.Parse(input[1]);
                    string value = input[2];

                    if (value.Length == 1)
                    {
                        decodedMessage.Insert(index, value);
                    }
                    else
                    {
                        for (int i = 0; i < value.Length; i++)
                        {
                            decodedMessage.Insert(index + i, value[i].ToString());
                        }
                    }


                }
                else if (cmd == "Move")
                {
                    string letters = string.Empty;

                    int n = int.Parse(input[1]);

                    for (int i = 0; i < n; i++)
                    {
                        letters += decodedMessage[i];
                    }
                    decodedMessage.RemoveRange(0, n);

                    for (int i = 0; i < letters.Length; i++)
                    {
                        decodedMessage.Add(letters[i].ToString());
                    }
                }

                input = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries);
            }

            string result = string.Empty;

            foreach (var letter in decodedMessage)
            {
                result += letter;
            }

            Console.WriteLine($"The decrypted message is: {result}");


        }
    }
}
