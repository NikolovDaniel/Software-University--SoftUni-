    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace EquipmentForClimbing
    {
        class Program
        {
            static void Main(string[] args)
            {
                double NumberOfClimbers = double.Parse(Console.ReadLine());
                double NumberOfCarabines = double.Parse(Console.ReadLine());
                double NumberOfRopes = double.Parse(Console.ReadLine());
                double NumberOfPikels = double.Parse(Console.ReadLine());

                double SumForCarabines = NumberOfCarabines * 36;
                double SumForRopes = NumberOfRopes * 3.60;
                double SumForPikels = NumberOfPikels * 19.80;
                double TotalSumForOneClimber = SumForCarabines + SumForPikels + SumForRopes;
                double TotalSumForAllClimbers = TotalSumForOneClimber * NumberOfClimbers;
                double VAT = TotalSumForAllClimbers * 0.20;
                double SumAfterVAT = TotalSumForAllClimbers + VAT;

                Console.WriteLine("{0:F2}",  SumAfterVAT);



            }
        }
    }
