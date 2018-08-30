using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_Part1
{
    class Program
    {
        public static void Main(string[] args)
        {
            string firstNumber, secondNumber;
            int validateIntValue;                            // defining variable types for the Main method

            Console.WriteLine("Please enter two numbers with the same amount of digits");

            while (true)
            {
                firstNumber = Console.ReadLine();        // user inputs two values (hopefully both integers of the same length)
                secondNumber = Console.ReadLine();
                validateIntValue = 1;

                if (string.IsNullOrWhiteSpace(firstNumber) || string.IsNullOrWhiteSpace(secondNumber))
                {
                    // if the user has entered no values, or only one value, the following message is displayed and the while loop starts over
                    Console.WriteLine("Please enter TWO numbers");
                    continue;
                }

                if (!int.TryParse(firstNumber, out validateIntValue) || !int.TryParse(secondNumber, out validateIntValue))
                {
                    // validates that the inputs are of ONLY an integer value
                    // if not, it outputs the following message and restarts the while loop 
                    Console.WriteLine("One, or both, of your inputs has a value that is not a number \nPlease enter only NUMBER values of the same length");
                    continue;
                }

                if (firstNumber.Length != secondNumber.Length)
                {
                    // validating user input; making sure both numbers contain the same amount of digits
                    Console.WriteLine("Both numbers need to have the same number of digits");
                    continue;
                }

                CompareIntegerDigitSums(firstNumber, secondNumber, firstNumber.Length);
                break;
            }
        }

        public static void CompareIntegerDigitSums(string firstNumber, string secondNumber, int inputLength)
        {
            int prevSum, firstDigit, secondDigit, digitSum; // defining variable type for the CompareIntegerDigits method

            prevSum = -1;
            for (var i = 0; i < inputLength; i++)
            // iterates through each numbers corresponding index position (as shown below)
            {
                firstDigit = firstNumber[i] - '0';  // convert character to integer it represents
                secondDigit = secondNumber[i] - '0'; // convert character to integer it represents
                digitSum = firstDigit + secondDigit;

                if (i != 0) // dont do this code in the first iteration of the loop!
                {
                    // if the last number and the current number are NOT equal, it's false!
                    if (prevSum != digitSum)
                    {
                        Console.WriteLine("FALSE");
                        Console.WriteLine(@"Each number's corresponding ""1s, 10s, 100s, etc place"" do not all have the same sum.");
                        return;
                    }
                }
                prevSum = digitSum;
            }

            Console.WriteLine("TRUE");
            Console.WriteLine(@"Each number's corresponding ""1s, 10s, 100s, etc. place"" all have the same sum.");
            return;
        }
    }
}