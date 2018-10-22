using System;

namespace LabNumber10
{
    class Validator
    {
        public bool IsValidInteger(string integer)
        {
            while (true)
            {
                if (String.IsNullOrEmpty(integer))
                {
                    Console.WriteLine("You have entered no value.");
                    Console.Write("Please enter a valid number :");
                    integer = Console.ReadLine();
                    continue;
                }

                int i = 0;
                if (!(Int32.TryParse(integer, out i)))
                {
                    Console.WriteLine("Please enter only numbers: ");
                    integer = Console.ReadLine();
                    continue;
                }
                return true;
            }
        }

        public bool IsValidString(string input)
        {
            while (true)
            {
                if (String.IsNullOrEmpty(input))
                {
                    Console.WriteLine("You have entered no value.");
                    Console.Write("Please enter a valid number :");
                    input = Console.ReadLine();
                    continue;
                }
                return true;
            }
        }
    }
}
