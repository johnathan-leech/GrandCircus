using System;
namespace LabNumber10
{
    class LabNumber10
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Please enter the radius of a circle");
            double userInput = double.Parse(Console.ReadLine());
            Circle myCircle = new Circle(userInput);

            Console.WriteLine($"Circumfrance: {myCircle.CaluculateCircumference()}");
            Console.WriteLine($"Formatted circumfrance:{myCircle.CaluculateCircumference()}");

            Console.WriteLine($"Area: {myCircle.CalculateArea()}");
            Console.WriteLine($"Formatted area: {myCircle.CalculatedFormatedArea()}");
        }
    }
}



