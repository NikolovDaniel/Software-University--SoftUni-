using System;
using System.Collections.Generic;
using System.Linq;

namespace AnonymousThreat
{
    class Program
    {
        static void Main(string[] args)
        {

            List<string> text = Console.ReadLine()
                                       .Split()
                                       .ToList();

            List<string> printResult = new List<string>();
            string input = Console.ReadLine();
            string[] command = input.Split();

            while (input != "3:1")
            {

                string commandOne = command[0];               

                if (commandOne == "merge")
                {
                    int startIndex = int.Parse(command[1]);
                    int endIndex = int.Parse(command[2]);
                    if (startIndex < 0) startIndex = 0;
                    if (endIndex > text.Count - 1) endIndex = text.Count - 1; // Might throw error

                    for (int i = 0; i <= text.Count; i++)
                    {
                        if (i == startIndex)
                        {
                            for (int a = startIndex; a < endIndex; a++)
                            {
                                text[startIndex] += text[startIndex + 1];
                                text.RemoveAt(startIndex + 1);
                            }
                            break;
                        }
                    }
                }

                if(commandOne == "divide")
                {
                    int index = int.Parse(command[1]);
                    int partitions = int.Parse(command[2]);

                    string partitionData = text[index];
                    text.RemoveAt(index);
                    int partSize = partitionData.Length / partitions;
                    int reminder = partitionData.Length % partitions;

                    for (int i = 0; i < partitions; i++)
                    {
                        string textToAdd = string.Empty;

                        for (int a = 0; a < partSize; a++)
                        {
                            textToAdd += partitionData[(i * partSize) + a];
                        }

                        if(i == partitions - 1 && reminder != 0)
                        {
                            textToAdd += partitionData.Substring(partitionData.Length - reminder);
                        }

                        text.Add(textToAdd);
                    }

                }

                input = Console.ReadLine();
                command = input.Split();

            }

            Console.WriteLine(string.Join(" ", text));

        }
    }
}
