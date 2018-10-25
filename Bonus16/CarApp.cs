using System;

namespace Bonus16
{
    class CarApp
    {

        public CarApp() { }

        static public int numberOfCars;
        static public string[] arrayOfCars;
        static public string make;
        static public string model;
        static public int year;
        static public double price;

        public void TakesUserInput()
        {
            Console.Write("How many cars would you like to enter? ");
            numberOfCars = Convert.ToInt32(Console.ReadLine());

            arrayOfCars = new string[numberOfCars];

            for (int i = 0; i < numberOfCars; i++)
            {
                Console.Write("What is the Make of your car? ");
                make = Console.ReadLine();

                Console.Write("What is the Model of your car? ");
                model = Console.ReadLine();

                Console.Write("What is the Year of your car? ");
                while (true)
                {
                    try
                    {
                        year = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine();
                        Console.Write("Please input a year: ");
                        continue;
                    }

                    if (!(year.ToString().Length == 4))
                    {

                        Console.WriteLine();
                        Console.Write("Please insert a valid year (i.e. 1998, 2006, etc.): ");
                        continue;
                    }

                    if (year > 1900 && year < 2020)
                    {
                        if (year > 2016 && year < 2020)
                        {
                            Console.WriteLine("Wow, your car is pretty new!");
                        }
                        if (year > 1990 && year < 2002)
                        {
                            Console.WriteLine("Wow, your car is old!");
                        }
                        if (year > 1950 && year < 1991)
                        {
                            Console.WriteLine("How is that thing still running....???");
                        }
                        if (year < 1951)
                        {
                            Console.WriteLine("---I can't with you---");
                        }
                    }
                    else
                    {
                        Console.Write("Please enter a valid year: ");
                        continue;
                    }
                    break;
                }
                Console.Write("What is the Price of your car? ");
                while (true)
                {
                    try
                    {
                        price = Convert.ToDouble(Console.ReadLine());
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Please enter a price with only numbers!");
                        Console.Write("No commas or special symbols:  ");
                    }

                    if (price >= 0)
                    {
                        if (price < 500)
                        {
                            Console.WriteLine("Get that thing off the road!");
                        }
                        if (price >= 30000 && price < 100000)
                        {
                            Console.WriteLine("Well look at you");
                        }
                        if (price >= 100000)
                        {
                            Console.WriteLine("I gotta get in that baby!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Prices can't be negative numbers");
                        Console.Write("Please enter a valid price: ");
                        continue;
                    }
                    break;
                }
                Car updatedCar = new Car(make, model, year, price);
                arrayOfCars[i] = updatedCar.ToString();
            }
        }

        public void DisplaysCarInfo()
        {
            Console.WriteLine("\r\n\r\n");      // makes room for display table (cleanliness)
            Console.WriteLine("MAKE".PadRight(20) + "MODEL".PadRight(20)
                                + "YEAR".PadRight(20) + "PRICE");
            Console.WriteLine("====".PadRight(20) + "=====".PadRight(20)
                                + "====".PadRight(20) + "=====");

            foreach (string car in arrayOfCars)
            {
                Console.WriteLine(car);
            }

            Console.ReadLine();
        }
    }
}
