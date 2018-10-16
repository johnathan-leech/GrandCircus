using System;
using System.Text.RegularExpressions;

namespace LabNumber7
{
    class LabNumber7
    {
        static void Main(string[] args)
        {
            NameValidation();
            EmailValidation();
            PhoneNumberValidation();
            DateValidation();
        }

        static string NameValidation()
        {
            Console.Write("What is your name? ");
            string userName = Console.ReadLine();

            while (!Regex.IsMatch(userName, @"^[A-Z]+[A-z]{0,29}"))
            {
                Console.WriteLine("Please enter a valid name (input is case-sensitive):");
                Console.WriteLine("Try again.");
                userName = Console.ReadLine();
            }
            Console.WriteLine("Name is valid!");
            return userName;
        }

        static string EmailValidation()
        {
            Console.WriteLine("What is your email address?");
            string email = Console.ReadLine();

            while (!Regex.IsMatch(email, @"^[a-zA-Z0-9]{5,30}@[a-zA-Z0-9]{5,30}\.[a-zA-Z0-9]{2,3}$"))
            {
                Console.WriteLine("Please enter a valid email address.");
                Console.WriteLine("Try again.");
                email = Console.ReadLine();
            }
            Console.WriteLine("Email is valid!");
            return email;
        }

        static string PhoneNumberValidation()
        {
            Console.WriteLine("What is your phone number?");
            Console.WriteLine("Format is...  XXX-XXX-XXXX");
            string phoneNumber = Console.ReadLine();

            while (!Regex.IsMatch(phoneNumber, "^[0-9]{3}-[0-9]{3}-[0-9]{4}$"))
            {
                Console.WriteLine("Please enter a valid phone number.");
                Console.WriteLine("Try again.");
            }
            Console.WriteLine("Phone number is valid!");
            return phoneNumber;
        }

        static string DateValidation()
        {
            Console.WriteLine("What is the date?");
            Console.WriteLine("Format is... dd/mm/yyyy");
            string date = Console.ReadLine();

            while (!Regex.IsMatch(date, "^[0-9]{2}/[0-9]{2}/[0-9]{4}$"))
            {
                Console.WriteLine("Please enter a valid date.");
                Console.WriteLine("Try again");
            }
            Console.WriteLine("Date is valid!");
            return date;
        }
    }
}
