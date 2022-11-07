using System;
using System.Linq;

namespace PasswordValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            bool isRuleOne = PrintPasswordRuleOne(password);
            bool isRuleTwo = PrintPasswordRuleTwo(password);
            bool isRuleThree = PrintPasswordRuleThree(password);

            if (isRuleOne && isRuleTwo && isRuleThree) Console.WriteLine("Password is valid");

            if (!isRuleOne) Console.WriteLine("Password must be between 6 and 10 characters");
            if (!isRuleTwo) Console.WriteLine("Password must consist only of letters and digits");
            if (!isRuleThree) Console.WriteLine("Password must have at least 2 digits");
        }

        static bool PrintPasswordRuleOne(string password)
        {                       
              
            bool isRuleOne = password.Length >= 6 && password.Length <= 10;

            return isRuleOne;

        }

        static bool PrintPasswordRuleTwo(string password)
        {

            bool isRuleTwo = false;

            foreach (var element in password)
            {

                if (char.IsLetterOrDigit(element)) isRuleTwo = true;
                else
                {
                    isRuleTwo = false;
                    break;
                }

            }

            return isRuleTwo;

        }

        static bool PrintPasswordRuleThree(string password)
        {

            bool isRuleThree = false;
            int digitCounter = 0;

            foreach (var element in password)
            {

                if (char.IsDigit(element)) digitCounter++;
                if (digitCounter >= 2)
                {
                    isRuleThree = true;
                    break;
                }

            }

            return isRuleThree;

        }
    }
}
