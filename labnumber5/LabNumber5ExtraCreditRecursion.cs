namespace LabNumber5
{
    class LabNumber5
    {
        static void Main(string[] args)
        {
            do
            {
                Console.Write("Enter an integer from 1 to 12: ");

                int userInt = int.Parse(Console.ReadLine());
                long factorialResult = GetsFactorial(userInt); // sets return value to a vabriable to use in Console.WriteLine below

                Console.WriteLine($"The factorial of {userInt} is {factorialResult}");

                Console.Write("Continue? (y/n): ");

            } while (LoopsAgain());
        }

        // using recursion to find the factorial of the number
        static long GetsFactorial(long num)
        {
            if (num == 1)
            {
                return 1;
            }
            return num * GetsFactorial(num - 1);
        }

        // prompts user to continue making calculations
        static bool LoopsAgain()
        {
            while (true)
            {
                string loop = Console.ReadLine().ToLower();
                Console.WriteLine("");

                if (loop == "y")
                {
                    return true;
                }
                if (loop == "n")
                {
                    return false;
                }

                Console.WriteLine("Invalid input. Try again.");
                continue;
            }
        }
    }
}
