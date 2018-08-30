using System;

namespace Lab1_Part2
{
    class Program
    {
        static void Main(string[] args)
        {
            string input1, input2;
            DateTime firstDate, secondDate, temp;
            TimeSpan timeDifference;
            double days, hours, minutes;

            while (true)
            {
                Console.WriteLine("Input the first date (the most recent) using the following format: MM.DD.YYYY");
                input1 = Console.ReadLine();
                Console.WriteLine("Input the second date using the following format: MM.DD.YYYY");
                input2 = Console.ReadLine();

                try        // used in case user inputs the wrong format for MM.DD.YYYY
                {
                    firstDate = DateTime.Parse(input1);
                    secondDate = DateTime.Parse(input2);
                }
                catch (FormatException)
                {
                    Console.WriteLine("\nIncorrect input format. Try again\n");
                    continue;
                }

                if (firstDate < secondDate)
                {
                    temp = firstDate;
                    firstDate = secondDate;
                    secondDate = temp;
                }

                timeDifference = (firstDate - secondDate);
                days = timeDifference.TotalDays;
                hours = timeDifference.TotalHours;
                minutes = timeDifference.TotalMinutes;

                Console.WriteLine("Amounts of time between these dates... \nDays: {0} \nHours: {1} \nMinutes: {2}", days, hours, minutes);
                break;
            }
        }
    }
}