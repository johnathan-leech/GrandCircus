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
        static string foodTownHeightDecision;
        static int counter;

        static void Main(string[] args)
        {
            while (true)
            {
                List<string> names = System.IO.File.ReadAllLines("Names.txt").ToList();
                List<string> towns = System.IO.File.ReadAllLines("Town.txt").ToList();
                List<string> foods = System.IO.File.ReadAllLines("Food.txt").ToList();
                List<string> hghts = System.IO.File.ReadAllLines("Height.txt").ToList();

                // counter's value is used to keep track of how many elements are in
                // the List's, so that future validation is possible
                counter = names.Count();

                GetsAndVerifiesUserInputID();

                string name = names[userInputID - 1];
                string food = foods[userInputID - 1];
                string town = towns[userInputID - 1];
                string hght = hghts[userInputID - 1];

                Console.WriteLine($"\r\nThe student that you have chosen: {name}");

                while (true)
                {
                    VerifiesFoodTownHeight();

                    if (foodTownHeightDecision == "town")
                    {
                        Console.WriteLine($"{name}'s favorite town is {town}.\r\n");
                    }
                    if (foodTownHeightDecision == "food")
                    {
                        Console.WriteLine($"{name}'s favorite food is {food}.\r\n");
                    }
                    if (foodTownHeightDecision == "height")
                    {
                        Console.WriteLine($"{name} is {hght} tall.\r\n");
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
                    // by putting cursor to the next line at the end of the code before
                    // returning, I guarantee that if/when the program is run again the
                    // new data is not skewing the existing data
                    File.AppendAllText("Names.txt", "\r\n");
                    File.AppendAllText("Town.txt", "\r\n");
                    File.AppendAllText("Food.txt", "\r\n");
                    File.AppendAllText("Height.txt", "\r\n");
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

        static string VerifiesFoodTownHeight()
        {
            Console.Write("Please enter 'town', 'food', or 'height': ");

            while (true)
            {
                foodTownHeightDecision = Console.ReadLine().ToLower().Trim();

                if (foodTownHeightDecision == "town" || foodTownHeightDecision == "food"
                    || foodTownHeightDecision == "height")
                {
                    return foodTownHeightDecision;
                }
                else
                {
                    Console.WriteLine("That is not a valid option.");
                    Console.WriteLine("Please enter only 'town', 'food', or 'height'.");
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
            File.AppendAllText("Names.txt", "\r\n");

            Console.Write("Enter town: ");
            string newTown = Console.ReadLine().ToLower().Trim();
            newTown = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(newTown);
            File.AppendAllText("Town.txt", newTown);
            File.AppendAllText("Town.txt", "\r\n");


            Console.Write("Enter food: ");
            string newFood = Console.ReadLine().ToLower().Trim();
            newFood = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(newFood);
            File.AppendAllText("Food.txt", newFood);
            File.AppendAllText("Food.txt", "\r\n");

            Console.Write("Enter height: ");
            string newHght = Console.ReadLine().Trim();
            File.AppendAllText("Height.txt", newHght);
            File.AppendAllText("Height.txt", "\r\n");
            File.AppendAllText("Food.txt", "\r\n");
        }
    }
}