using System;

namespace LabNumber10
{
    class LabNumber10
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Please enter the radius of a circle! ");
                double userInput = double.Parse(Console.ReadLine());

                Circle myCircle = new Circle(userInput);

                Console.WriteLine($"Circumference: {myCircle.CalculateCircumference()}");
                Console.WriteLine($"Formatted circumference: {myCircle.CalculateFormattedCircumference()}");

                Console.WriteLine($"Area: {myCircle.CalculateArea()}");
                Console.WriteLine($"Formatted area: {myCircle.CalculateFormattedArea()}");
            }


        }
    }
}
