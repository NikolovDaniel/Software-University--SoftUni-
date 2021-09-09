using System;

namespace Messages
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            int letterIndex = 0;
            int offset = 0;
            int length = 0;
            int mainDigit = 0;
            char convert = ' ';
            string result = "";

            for (int i = 0; i < n; i++)
            {
                string number = Console.ReadLine();
               
                length = number.Length;
                mainDigit = int.Parse(number[0].ToString());               

                if (mainDigit == 8 || mainDigit == 9)
                {
                    offset = (mainDigit - 2) * 3 + 1;
                }
                else offset = (mainDigit - 2) * 3;

                letterIndex = (offset + length - 1);
                letterIndex += 97;

                convert = (char)letterIndex;
                if (letterIndex == 91) result += " ";
                else result += convert.ToString();
            }
            Console.WriteLine(result);
        }
    }
}
