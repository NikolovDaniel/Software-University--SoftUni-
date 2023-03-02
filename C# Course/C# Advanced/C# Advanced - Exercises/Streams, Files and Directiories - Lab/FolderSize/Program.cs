using System;
using System.IO;

namespace FolderSize
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] folderFiles = Directory.GetFiles(@"C:\Users\KOlombus\source\repos\CSharp Advanced\FolderSize\TestFolder\");

            double sum = 0;

            for (int i = 0; i < folderFiles.Length; i++)
            {
                FileInfo fileInfo = new FileInfo(folderFiles[i]);
                sum += fileInfo.Length;
            }

            sum = sum / 1024 / 1024;

            File.WriteAllText("output.txt", sum.ToString());
        }
    }
}
