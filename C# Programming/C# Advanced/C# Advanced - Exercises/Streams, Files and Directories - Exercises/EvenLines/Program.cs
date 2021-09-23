using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EvenLines
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using (StreamReader str = new StreamReader("text.txt"))
            {
                using (StreamWriter swtr = new StreamWriter("output.txt"))
                {
                    string line = await str.ReadLineAsync();
                    int counter = 0;

                    while (line != null)
                    {
                        if (line.Contains('-'))
                        {
                            line = line.Replace('-', '@');
                        }
                        if (line.Contains(','))
                        {
                            line = line.Replace(',', '@');
                        }
                        if (line.Contains('.'))
                        {
                            line = line.Replace('.', '@');
                        }
                        if (line.Contains('!'))
                        {
                            line = line.Replace('!', '@');
                        }
                        if (line.Contains('?'))
                        {
                            line = line.Replace('?', '@');
                        }

                        if (counter % 2 == 0)
                        {
                            string result = string.Empty;

                            string[] arr = line.Split();

                            for (int i = arr.Length - 1; i >= 0; i--)
                            {
                                result += $"{arr[i]} ";
                            }

                            await swtr.WriteLineAsync(result.TrimEnd());
                        }
                        counter++;
                        line = await str.ReadLineAsync();
                    }
                }
            }
        }
    }
}
