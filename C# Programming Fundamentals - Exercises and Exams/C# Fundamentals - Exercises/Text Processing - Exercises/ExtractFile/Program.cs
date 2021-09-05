using System;

namespace ExtractFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] fileLocation = Console.ReadLine().Split("\\", StringSplitOptions.RemoveEmptyEntries);

            string[] fileAndExtension = fileLocation[fileLocation.Length - 1].Split(".");

            Console.WriteLine($"File name: {fileAndExtension[0]}");
            Console.WriteLine($"File extension: {fileAndExtension[1]}");
        }
    }
}
