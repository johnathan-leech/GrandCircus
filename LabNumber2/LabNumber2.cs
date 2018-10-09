using System;

namespace LabNumber2
{
    class LabNumber2
    {
        // declaring variables to the class to use in methods
        static double roomLength, roomWidth, roomHeigth;
        static double roomPerim, roomArea, roomVolume;

        static void Main(string[] args)
        {
            // sections of the math, inputs and outputs entered into 
            // separate methods on the Main method
            do
            {
                InputForRoomSize();
                CalculateDimensions();
                OutputDimensions();
            } while (PromptToContinue());
        }

        static void OutputDimensions()
        {
            Console.WriteLine($"\r\nVolume: {roomVolume}cub-ft");
            Console.WriteLine($"Area: {roomArea}sq-ft");
            Console.WriteLine($"Permiter: {roomPerim}ft\r\n");
        }

        static void CalculateDimensions()
        {
            roomPerim = roomLength * 2 + roomWidth * 2;
            roomArea = roomLength * roomWidth;
            roomVolume = roomHeigth * roomLength * roomWidth;
        }

        static void InputForRoomSize()
        {
            Console.Write("Enter length: ");
            roomLength = double.Parse(Console.ReadLine());
            Console.Write("Enter width: ");
            roomWidth = double.Parse(Console.ReadLine());
            Console.Write("Enter heigth: ");
            roomHeigth = double.Parse(Console.ReadLine());
        }

        static bool PromptToContinue()
        {
            Console.Write("Continue? (y/n): ");

            // while loop is used to validate user input for y/n question
            while (true)
            {
                string prompt;
                prompt = Console.ReadLine().ToLower();
                Console.WriteLine(""); // empty string used for user readability

                if (prompt == "n")
                {
                    return false;
                }
                if (prompt == "y")
                {
                    return true;
                }

                Console.WriteLine("Invalid input. Please enter 'y' or 'n'");
            }
        }
    }
}

