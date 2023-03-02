using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WordCount
{
    class Program
    {
        static async Task Main(string[] args)
        {

            Dictionary<string, int> countWords = new Dictionary<string, int>();

            using (StreamReader str = new StreamReader("words.txt"))
            {
                using (StreamReader str2 = new StreamReader("text.txt"))
                {
                    string lineWords = await str.ReadLineAsync();
                    string lineText = await str2.ReadLineAsync();
                    string[] words = lineWords.ToUpper().Split(new char[] { ' ', '.', ',', '-', '?', '!', ':', ';' }, StringSplitOptions.RemoveEmptyEntries);

                    while (lineText != null)
                    {
                       string[] wordsInp = lineText.ToUpper().Split(new char[] { ' ', '.', ',', '-', '?', '!', ':', ';' }, StringSplitOptions.RemoveEmptyEntries);
                        for (int i = 0; i < words.Length; i++)
                        {
                            for (int j = 0; j < wordsInp.Length; j++)
                            {
                                if (words[i] == wordsInp[j])
                                {
                                    if (countWords.ContainsKey(words[i]))
                                    {
                                        countWords[words[i]]++;
                                    }
                                    else
                                    {
                                        countWords.Add(words[i], 1);
                                    }
                                }
                            }
                        }
                        lineText = await str2.ReadLineAsync();
                    }
                }
            }

            using (StreamWriter swtr = new StreamWriter("Output.txt"))
            {
                foreach (var word in countWords.OrderByDescending(x => x.Value))
                {
                    await swtr.WriteLineAsync($"{word.Key} - {word.Value}");
                }
            }
        }
    }
}
