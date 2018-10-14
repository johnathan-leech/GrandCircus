using System;

namespace LabNumber5
{
    class LabNumber5
    {
        static int userInt;
        static long factorialResult;

        static void Main(string[] args)
        {
            do
            {
                Console.Write("Enter an integer from 1 to 12: ");
                userInt = int.Parse(Console.ReadLine());

                CalculatesFactorial(userInt);
                Console.WriteLine($"The factorial of {userInt} is {factorialResult}");

                Console.Write("Continue? (y/n): ");

            } while (LoopsAgain());
        }


        static void CalculatesFactorial(int num)
        {
            factorialResult = num;
            for (int i = 1; i < num; i++)
            {
                factorialResult *= i;
            }
        }

        // prompts user to enter if they would like to continue finding factorials
        static bool LoopsAgain()
        {
            while (true)
            {
                string loop = Console.ReadLine().ToLower();
                Console.WriteLine("");

                if (loop == "y")
                {
                    return true;
                }
                if (loop == "n")
                {
                    return false;
                }

                Console.WriteLine("Invalid input. Try again.");
                continue;
            }
        }
    }
}
