using System;
using System.IO;
using System.Threading.Tasks;

namespace OddLines
{
    class Program
    {
        static async Task Main(string[] args)
        {

            using (StreamReader str = new StreamReader("Input.txt"))
            {

                int count = 0;
                string line = await str.ReadLineAsync();

                using (StreamWriter swtr = new StreamWriter("output.txt"))
                {
                    while (line != null)
                    {
                        if (count % 2 == 1)
                        {
                            await swtr.WriteLineAsync(line);
                        }
                        line = await str.ReadLineAsync();
                        count++;
                    }
                };
            };
        }
    }
}
