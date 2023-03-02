using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Telephony
{
    public class Smartphone : IBrowse, ICall
    {
        public void Browse(string website)
        {
            //CHECK IF STRING CONTAINS ANY DIGITS
            bool isDigit = false;

            website.ToCharArray().ToList().ForEach(x =>
            {
                if (char.IsDigit(x))
                {
                    isDigit = true;
                }
            });

            if (isDigit)
            {
                Console.WriteLine("Invalid URL!");
                return;
            }
            Console.WriteLine($"Browsing: {website}!");
        }

        public void Call(string number)
        {
            bool isChar = false;

            number.ToCharArray().ToList().ForEach(x =>
            {
                if (char.IsLetter(x))
                {
                    isChar = true;
                }
            });

            if (isChar || number.Length < 7 || number.Length > 10)
            {
                Console.WriteLine("Invalid number!"); 
            }
            else if (number.Length == 10)
            {
                Console.WriteLine($"Calling... {number}");
            }
            else if (number.Length == 7)
            {
                Console.WriteLine($"Dialing... {number}");
            }
        }
    }
}
