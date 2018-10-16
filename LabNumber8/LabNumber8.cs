using System;

namespace LabNumber8
{
    class LabNumber8
    {
        static int userInputID;
        static void Main(string[] args)
        {
            // declaring my arrays with which I will use to get index values
            // for my user prompts.
            string[] names = System.IO.File.ReadAllLines("Names.txt");
            string[] foods = System.IO.File.ReadAllLines("Food.txt");
            string[] towns = System.IO.File.ReadAllLines("Town.txt");

            GetsAndVerifiesUserInputID();

            string name = names[userInputID - 1];
            string food = foods[userInputID - 1];
            string town = towns[userInputID - 1];

            Console.WriteLine($"The student that you have chosen is: {name}");
            Console.WriteLine($"Would you like to know {name}'s favorite food or town? (y/n): ");

            if (!ContinueProgram())
            {
                return;
            }

            Console.WriteLine("Please enter 'food' or 'town'");

            VerifiesFoodTown();

            Console.WriteLine($"{name}'s favorite food is {food}.");
            Console.WriteLine($"{name}'s favorite town is {town}.");
        }

        static void GetsAndVerifiesUserInputID()
        {
            Console.WriteLine("Enter an ID number: ");
            while (true)
            {
                try
                {
                    userInputID = int.Parse(Console.ReadLine());
                    if (1 <= userInputID && userInputID <= 20)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Enter a valid number (1-20): ");
                        userInputID = int.Parse(Console.ReadLine());
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("You have entered something other than a number.");
                    Console.WriteLine("Please try again.");
                }
            }
        }

        static bool ContinueProgram()
        {
            while (true)
            {
                string answerYN = Console.ReadLine().ToLower();

                if (answerYN == "y")
                {
                    return true;
                }
                if (answerYN == "n")
                {
                    return false;
                }

                Console.WriteLine("Invalid input.");
                Console.WriteLine("Please Enter 'y' or 'n': ");

            }
        }

        static void VerifiesFoodTown()
        {

        }
    }
}
