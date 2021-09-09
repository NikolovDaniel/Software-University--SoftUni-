using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exchange
{
    class Program
    {
        static void Main(string[] args)
        {
            double BitCoin = 1168;
            double ChineseYuan = 0.15;
            double Dollar = 1.76;
            double Euro = 1.95;

            double BitCoinSum = double.Parse(Console.ReadLine());
            double ChineseYuanSum = double.Parse(Console.ReadLine());
            double Commission = double.Parse(Console.ReadLine());

            double ChineseToBGN = (ChineseYuanSum * ChineseYuan) * Dollar;
            double BitCoinPrice = BitCoinSum * BitCoin;
            double BGNToEuro = (BitCoinPrice + ChineseToBGN) / Euro;
            double CommissionSum = BGNToEuro * (Commission / 100);
            double FinalSum = BGNToEuro - CommissionSum;

            Console.WriteLine("{0:F2}", FinalSum);
        }
    }
}
