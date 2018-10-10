using System;

namespace LabNumber3
{
    class LabNumber3
    {
        static int userInteger;
        static string name;

        static void Main(string[] args)
        {
            Name();
            do
            {
                NumberValidation();
                NumberOutputs();
            } while (ContinueProgram());

            Console.WriteLine("Have a good day! :)");
            Console.Read();
        }

        static void Name()
        {
            Console.Write("Create a fun and exciting nickname! ");
            name = Console.ReadLine();
        }

        static void NumberValidation()
        {
            while (true)
            {
                Console.Write($"{name}, please enter a positive integer between 1 and 100: ");
                userInteger = int.Parse(Console.ReadLine());

                if (InRange(1, 100))
                {
                    break;
                }
                else
                {   // validates numbers 1-100 and re-prompts user for input
                    Console.WriteLine($"{name}, you have entered a number outside of the parameters.\r\n");
                    continue;
                }
            }
        }

        static void NumberOutputs()
        {
            Console.WriteLine("");
            if (!IsEven())
            {
                Console.WriteLine($"{userInteger}: Odd");
            }
            if (IsEven() && InRange(2, 25))
            {
                Console.WriteLine("Even and less than 25");
            }
            if (IsEven() && InRange(26, 60))
            {
                Console.WriteLine("Even");
            }
            if (IsEven() && userInteger > 60)
            {
                Console.WriteLine($"{userInteger}: Even");
            }
            if (!IsEven() && userInteger > 60)
            {
                Console.WriteLine($"{userInteger}: Odd");
            }
        }

        static bool ContinueProgram()
        {
            Console.Write($"\r\n{name}, Continue? (y/n?): ");

            while (true)
            {
                string doAgain = Console.ReadLine().ToLower();

                if (doAgain == "y")
                {
                    return true;
                }
                if (doAgain == "n")
                {
                    return false;
                }

                Console.WriteLine($"Uh oh {name}. You entered a value that" +
                    $" is neither 'y' or 'no'. Please try again.");
            }
        }

        static bool IsEven()
        {
            return userInteger % 2 == 0;
        }

        // range includes least and greatest integer arguments
        static bool InRange(int bottomOfRange, int topOfRange)
        {
            return (bottomOfRange <= userInteger && userInteger <= topOfRange);
        }
    }
}
