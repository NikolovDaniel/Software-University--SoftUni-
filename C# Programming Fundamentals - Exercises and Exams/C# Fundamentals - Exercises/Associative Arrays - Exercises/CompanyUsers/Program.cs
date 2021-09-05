using System;
using System.Collections.Generic;
using System.Linq;

namespace CompanyUsers
{
    class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, List<string>> companyID = new Dictionary<string, List<string>>();


            string[] input = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries);


            while (input[0] != "End")
            {

                string company = input[0];
                string ID = input[1];


                if (companyID.ContainsKey(company))
                {
                    if (!companyID[company].Contains(ID))
                    {
                        companyID[company].Add(ID);
                    }                   
                }
                else
                {
                    companyID.Add(company, new List<string>() { ID });
                }

                input = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
            }


            foreach (var company in companyID.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{company.Key}");
                foreach (var id in company.Value)
                {
                    Console.WriteLine($"-- {id}");
                }
            }

        }
    }
}
