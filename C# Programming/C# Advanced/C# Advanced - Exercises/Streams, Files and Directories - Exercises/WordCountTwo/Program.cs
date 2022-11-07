using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WordCountTwo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string[] words = await File.ReadAllLinesAsync("words.txt");
            string[] text = await File.ReadAllLinesAsync("text.txt");

            Dictionary<string, int> wordCount = new Dictionary<string, int>();

            for (int i = 0; i < words.Length; i++)
            {
                for (int j = 0; j < text.Length; j++)
                {
                    string[] currWords = text[j].ToUpper().Split(new char[] { ' ', ',', '.', '-', '?', '!' }, StringSplitOptions.RemoveEmptyEntries);

                    for (int k = 0; k < currWords.Length; k++)
                    {
                        if (words[i].ToUpper() == currWords[k])
                        {
                            if (wordCount.ContainsKey(words[i]))
                            {
                                wordCount[words[i]]++;
                            }
                            else
                            {
                                wordCount.Add(words[i], 1);
                            }
                        }
                    }
                }
            }

            List<string> lines = new List<string>();

            foreach (var word in wordCount.OrderByDescending(x => x.Value))
            {
                lines.Add($"{word.Key} - {word.Value}");
            }

            await File.WriteAllLinesAsync("actualResult.txt", lines);
            
        }
    }
}
