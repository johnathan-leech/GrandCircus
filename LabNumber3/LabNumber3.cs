using System;
using System.Linq;

namespace LabNumber3
{
    class LabNumber3
    {
        static int userInteger;
        static string name;

        static void Main(string[] args)
        {
            Name();
            NumberValidation();
            NumberOutputs();
        }

        static string Name()
        {
            Console.Write("Create a fun and exciting nickname! ");
            name = Console.ReadLine();
            return name;
        }

        static int NumberValidation()
        {
            while (true)
            {
                Console.Write($"{name}, please enter a positive integer between 1 and 100: ");
                userInteger = int.Parse(Console.ReadLine());


                if (InRange(1, 100))
                {
                    return userInteger;
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
            if (IsEven() && IsGreaterThan(60, userInteger))
            {
                Console.WriteLine($"{userInteger}: Even");
            }
            if (!IsEven() && IsGreaterThan(60, userInteger))
            {
                Console.WriteLine($"{userInteger}: Odd");
            }
        }

        static bool IsEven()
        {
            if (userInteger % 2 == 0)
            {
                return true;
            }
            return false;
        }

        // range includes least and greatest integer arguments
        static bool InRange(int bottomOfRange, int topOfRange)
        {
            int difference = topOfRange - bottomOfRange;

            if (difference < 1)
            {
                difference *= -1;
            }
            if (bottomOfRange < 1)
            {
                bottomOfRange *= -1;
            }

            //creates an array containing the values in the range
            var makeArrayForComparison = Enumerable.Range(bottomOfRange, difference).ToArray();
            bool numberIsValid = makeArrayForComparison.Contains(userInteger);

            // returns boolean value needed to pass through if-statements
            return numberIsValid;
        }

        static bool IsGreaterThan(int userInteger, int greaterValue)
        {
            if (userInteger < greaterValue)
            {
                return true;
            }
            if (!(userInteger < greaterValue))
            {
                return false;
            }
            return false;
        }
    }
}
