using System;
using System.Linq;

namespace FromLeftToTheRight
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            double sum = 0;

            for (int i = 0; i < n; i++)
            {
                double[] array = Console.ReadLine().Split().Select(double.Parse).ToArray();

                if (array[0] > array[1])
                {
                    if (array[0] < 0)
                    {
                        string element = array[0].ToString();
                        element = element.Trim(new char[] { '-' });
                        double[] splitArray = new double[element.Length];

                        for (int a = 0; a < element.Length; a++)
                        {
                            splitArray[a] = double.Parse(element[a].ToString());
                            sum += splitArray[a];
                        }

                        Console.WriteLine(sum);
                    }
                    else
                    {
                        string element = array[0].ToString();
                        double[] splitArray = new double[element.Length];

                        for (int a = 0; a < element.Length; a++)
                        {                          
                            splitArray[a] = double.Parse(element[a].ToString());
                            sum += splitArray[a];
                        }
                        Console.WriteLine(sum);
                    }

                }
                if (array[1] >= array[0])
                {
                    if (array[1] < 0)
                    {
                        string element = array[1].ToString();
                        element = element.Trim(new char[] { '-' });
                        double[] splitArray = new double[element.Length];

                        for (int a = 0; a < element.Length; a++)
                        {
                            splitArray[a] = double.Parse(element[a].ToString());
                            sum += splitArray[a];
                        }

                        Console.WriteLine(sum);
                    }
                    else
                    {
                        string element = array[1].ToString();
                        double[] splitArray = new double[element.Length];

                        for (int a = 0; a < element.Length; a++)
                        {
                            splitArray[a] = double.Parse(element[a].ToString());
                            sum += splitArray[a];
                        }

                        Console.WriteLine(sum);
                    }
                }

                sum = 0;
            }           
        }
    }
}
