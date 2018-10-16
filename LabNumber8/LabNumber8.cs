using System;

namespace LabNumber8
{
    class LabNumber8
    {
        static int userInputID;
        static string foodTownDecision;
        static void Main(string[] args)
        {
            while (true)
            {    // declaring my arrays with which I will use to get index values
                // for my user prompts.
                string[] names = System.IO.File.ReadAllLines("Names.txt");
                string[] foods = System.IO.File.ReadAllLines("Food.txt");
                string[] towns = System.IO.File.ReadAllLines("Town.txt");

                GetsAndVerifiesUserInputID();

                string name = names[userInputID - 1];
                string food = foods[userInputID - 1];
                string town = towns[userInputID - 1];

                Console.WriteLine($"\r\nThe student that you have chosen: {name}");
                //Console.Write($"Would you like to know {name}'s favorite food or town?: ");

                while (true)
                {
                    VerifiesFoodTown();

                    if (foodTownDecision == "town")
                    {
                        Console.WriteLine($"{name}'s favorite town is {town}.\r\n");
                    }
                    if (foodTownDecision == "food")
                    {
                        Console.WriteLine($"{name}'s favorite food is {food}.\r\n");
                    }

                    Console.Write("Are you finished with this student? (y/n): ");

                    if (!ContinueProgram())
                    {
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }

                Console.Write("Would you like to look at another student? (y/n): ");


                if (!ContinueProgram())
                {
                    return;
                }
            }
        }

        static void GetsAndVerifiesUserInputID()
        {
            Console.Write("\r\nEnter an ID number: ");
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

        static string VerifiesFoodTown()
        {
            Console.Write("Please enter 'food' or 'town': ");

            while (true)
            {
                foodTownDecision = Console.ReadLine().ToLower();

                if (foodTownDecision == "food" || foodTownDecision == "town")
                {
                    return foodTownDecision;
                }
                else
                {
                    Console.WriteLine("That is not a valid option.");
                    Console.WriteLine("Please enter only 'food' or 'town'.");
                }
            }
        }
    }
}
