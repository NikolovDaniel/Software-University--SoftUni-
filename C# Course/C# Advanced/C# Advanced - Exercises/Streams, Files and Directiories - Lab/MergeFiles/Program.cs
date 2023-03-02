using System;
using System.IO;
using System.Threading.Tasks;

namespace MergeFiles
{
    class Program
    {
        static async Task Main(string[] args)
        {
            
            using (StreamReader str = new StreamReader("FileOne.txt"))
            {

                using (StreamReader str2 = new StreamReader("FileTwo.txt"))
                {

                    using (StreamWriter swtr = new StreamWriter("Output.txt"))
                    {
                        string txtOne = await str.ReadLineAsync();
                        string txtTwo = await str2.ReadLineAsync();

                        while (txtOne != null && txtTwo != null)
                        {

                            await swtr.WriteLineAsync(txtOne);
                            await swtr.WriteLineAsync(txtTwo);


                            txtOne = await str.ReadLineAsync();
                            txtTwo = await str2.ReadLineAsync();
                        }
                    }

                }
            }
        }
    }
}
