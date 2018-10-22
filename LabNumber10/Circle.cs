using System;

namespace LabNumber10
{
    class Circle
    {
        public const double PI = Math.PI;

        private double radius;
        public double Radius
        {
            get
            {
                return radius;
            }
            set
            {
                radius = value;
            }
        }

        public Circle(double rad)
        {
            radius = rad;
        }

        public string FormatNumber(double x)
        {
            return $"{x,0:N2}";
        }

        public double CalculateCircumference()
        {
            double circumference = PI * (radius * 2);
            return circumference;
        }

        public string CalculateFormattedCircumference()
        {
            return FormatNumber(CalculateCircumference());
        }

        public double CalculateArea()
        {
            double area = PI * (radius * radius);
            return area;
        }

        public string CalculateFormattedArea()
        {
            return FormatNumber(CalculateArea());
        }
    }
}
