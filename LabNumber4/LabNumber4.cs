using System;

namespace LabNumber4
{
    class LabNumber4
    {
        static int userInt;

        static void Main(string[] args)
        {
            Console.WriteLine("Learn your squares and cubes!");
            do
            {
                PromptsUserAndMakesHeader();
                OutputsPowersOfUserInteger();
            } while (LoopsAgain());
        }

        static void PromptsUserAndMakesHeader()
        {
            Console.Write("\r\nEnter an integer: ");
            userInt = int.Parse(Console.ReadLine());
            Console.WriteLine("");

            string number = "Number".PadRight(20);
            string squared = "Squared".PadRight(20);
            string cubed = "Cubed";
            string doubleUnderScore1 = "=======".PadRight(20);
            string doubleUnderScore2 = "======";

            Console.WriteLine($"{number}{squared}{cubed}");
            Console.WriteLine($"{doubleUnderScore1}{doubleUnderScore1}" +
                                                $"{doubleUnderScore2}");
        }

        static void OutputsPowersOfUserInteger()
        {
            for (int i = 1; i <= userInt; i++)
            {
                string noPower = i.ToString().PadRight(20);
                string powerOfTwo = (i * i).ToString().PadRight(20);
                string powerOfThree = (i * i * i).ToString().PadRight(20);

                Console.WriteLine($"{noPower}{powerOfTwo}{powerOfThree}");
            }
            Console.Write("\r\nContinue? (y/n): ");
        }

        static bool LoopsAgain()
        {
            while (true)
            {
                string continuePrompt = Console.ReadLine().ToLower();

                if (continuePrompt == "y")
                {
                    return true;
                }
                if (continuePrompt == "n")
                {
                    Console.WriteLine("\r\nHave a wonderful day! :)");
                    Console.ReadLine();
                    return false;
                }

                Console.WriteLine("You have input invalid data. Please try again.");
            }

        }
    }
}
