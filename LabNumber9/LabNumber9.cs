using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace LabNumber9
{
    class LabNumber9
    {
        static int userInputID;
        static string foodTownColorDecision;
        static int counter;

        static void Main(string[] args)
        {
            while (true)
            {
                List<string> names = System.IO.File.ReadAllLines("Names.txt").ToList();
                List<string> towns = System.IO.File.ReadAllLines("Towns.txt").ToList();
                List<string> foods = System.IO.File.ReadAllLines("Food.txt").ToList();
                List<string> colrs = System.IO.File.ReadAllLines("Colors.txt").ToList();

                File.AppendAllText("Names.txt", "\r\n");
                File.AppendAllText("Towns.txt", "\r\n");
                File.AppendAllText("Food.txt", "\r\n");
                File.AppendAllText("Colors.txt", "\r\n");

                // counter's value is used to keep track of how many elements are in
                // the List's, so that future validation is possible
                counter = names.Count();

                GetsAndVerifiesUserInputID();

                string name = names[userInputID - 1];
                string food = foods[userInputID - 1];
                string town = towns[userInputID - 1];
                string colr = colrs[userInputID - 1];

                Console.WriteLine($"\r\nThe student that you have chosen: {name}");

                while (true)
                {
                    VerifiesFoodTownColor();

                    if (foodTownColorDecision == "town")
                    {
                        Console.WriteLine($"{name}'s favorite town is {town}.\r\n");
                    }
                    if (foodTownColorDecision == "food")
                    {
                        Console.WriteLine($"{name}'s favorite food is {food}.\r\n");
                    }
                    if (foodTownColorDecision == "height")
                    {
                        Console.WriteLine($"{name}'s favorite color is {colr}.\r\n");
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

                Console.Write("Would you like to add a student? (y/n): ");

                if (ContinueProgram())
                {
                    EnterNewStudentInfo();
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
            Console.Write($"\r\nEnter an ID number between 1 and {counter}: ");
            while (true)
            {
                try
                {
                    userInputID = int.Parse(Console.ReadLine());
                    if (1 <= userInputID && userInputID <= counter)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"Enter a valid number (1-{counter}): ");
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
                string answerYN = Console.ReadLine().ToLower().Trim();

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

        static string VerifiesFoodTownColor()
        {
            Console.Write("Please enter 'town', 'food', or 'color': ");

            while (true)
            {
                foodTownColorDecision = Console.ReadLine().ToLower().Trim();

                if (foodTownColorDecision == "town" || foodTownColorDecision == "food"
                    || foodTownColorDecision == "color")
                {
                    return foodTownColorDecision;
                }
                else
                {
                    Console.WriteLine("That is not a valid option.");
                    Console.WriteLine("Please enter only 'town', 'food', or 'color'.");
                }
            }
        }

        static void EnterNewStudentInfo()
        {
            Console.Write("Enter name: ");
            // newName is taken by user, all turned to lowercase and trimmed of any whitespace.
            // then index 0 is made to an uppercase letter (since names are proper nouns).
            string newName = Console.ReadLine().ToLower().Trim();
            newName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(newName);
            // new information is appended to the end of the text file
            File.AppendAllText("Names.txt", newName);

            Console.Write("Enter town: ");
            string newTown = Console.ReadLine().ToLower().Trim();
            newTown = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(newTown);
            File.AppendAllText("Towns.txt", newTown);

            Console.Write("Enter food: ");
            string newFood = Console.ReadLine().ToLower().Trim();
            newFood = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(newFood);
            File.AppendAllText("Food.txt", newFood);

            Console.Write("Enter color: ");
            string newColr = Console.ReadLine().Trim();
            File.AppendAllText("Colors.txt", newColr);
        }
    }
}