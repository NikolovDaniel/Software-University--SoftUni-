using System;
using System.IO;
using System.Threading.Tasks;

namespace LineNumbers
{
    class Program
    {
        static async Task Main(string[] args)
        {
            
            using (StreamReader str = new StreamReader("Input.txt"))
            {

                string line = await str.ReadLineAsync();

                using (StreamWriter swtr = new StreamWriter("Output.txt"))
                {
                    int counter = 1;
                    while (line != null)
                    {
                        await swtr.WriteLineAsync($"{counter}. " + line);
                        line = await str.ReadLineAsync();
                        counter++;
                    }
                };
            };
        }
    }
}
