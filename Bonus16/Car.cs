using System;

namespace Bonus16
{
    class Car
    {
        private string make;
        public string Make
        {
            get
            {
                return make;
            }
            set
            {
                make = value;
            }
        }

        private string model;
        public string Model
        {
            get
            {
                return model;
            }
            set
            {
                model = value;
            }
        }

        private int year;
        public int Year
        {
            get
            {
                return year;
            }
            set
            {
                year = value;
            }
        }

        private double price;
        public double Price
        {
            get
            {
                return price;
            }
            set
            {
                price = value;
            }
        }

        public Car() { }

        public Car(string make, string model, int year, double price)
        {
            Make = make;
            Model = model;
            Year = year;
            Price = price;
        }

        //string formatPrice = Price.ToString();

        public override string ToString()
        {
            return $"{Make.PadRight(20)}{Model.PadRight(20)}" +
                    $"{Year.ToString().PadRight(20)}{String.Format("{0:C}", Price)}";
        }
    }
}
