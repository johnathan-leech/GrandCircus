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
        public double CaluculateCircumference()
        {
            double circumference = PI * (radius * 2);
            return circumference;
        }
        public string CaluculateFormattedCircumference()
        {
            return FormatNumber(CaluculateCircumference());
        }
        public double CalculateArea()
        {
            double area = PI * (radius * radius);
            return area;
        }
        public string CalculatedFormatedArea()
        {
            return FormatNumber(CalculateArea());
        }
    }
}