using System;
using System.IO.Compression;

namespace ZipAndExtract
{
    class Program
    {
        static void Main(string[] args)
        {
            ZipFile.CreateFromDirectory(@"C:\Users\YourUserName\Desktop\Zip", @"C:\Users\YourUserName\Desktop\Extract\Archive.zip");

            ZipFile.ExtractToDirectory(@"Archive.zip", @"C:\Users\YourUserName\Desktop\Extract");

        }
    }
}
