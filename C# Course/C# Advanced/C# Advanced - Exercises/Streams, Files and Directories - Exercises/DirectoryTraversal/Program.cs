using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DirectoryTraversal
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Dictionary<string, List<FileInfo>> filesExtensions = new Dictionary<string, List<FileInfo>>();

            string path = Console.ReadLine();

            string[] files = Directory.GetFiles(path);

            foreach (string file in files)
            {

                FileInfo info = new FileInfo(file);

                string extensions = info.Extension;

                if (!filesExtensions.ContainsKey(extensions))
                {
                    filesExtensions[extensions] = new List<FileInfo>();
                }

                filesExtensions[extensions].Add(info);

            }

            using (StreamWriter writer = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/report.txt"))
            {

                foreach (var extension in filesExtensions.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key)) 
                {

                    await writer.WriteLineAsync(extension.Key);

                    foreach (var file in extension.Value.OrderBy(x => Math.Ceiling((double) x.Length / 1024)))
                    {
                        await writer.WriteLineAsync($"--{file.Name} - {Math.Ceiling((double)file.Length / 1024)}kb");
                    }
                }
            }
        }
    }
}
