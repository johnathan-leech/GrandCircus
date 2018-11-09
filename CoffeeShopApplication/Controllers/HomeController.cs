using CoffeeShopApplication.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace CoffeeShopApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult UserRegistration()
        {
            return View();
        }

        IEnumerable<char> CharsToTitleCase(string s)
        {
            bool newWord = true;
            foreach (char c in s)
            {
                if (newWord) { yield return char.ToUpper(c); newWord = false; }
                else yield return char.ToLower(c);
                if (c == ' ') newWord = true;
            }
        }

        public ActionResult AddUser(UserInfo newUser)
        {
            if (ModelState.IsValid)
            {
                string firstName = new string(CharsToTitleCase(newUser.FirstName).ToArray());

                ViewBag.ConfMessage1 = "Welcome " + firstName;
                ViewBag.ConfMessage2 = "Your email address: " + newUser.Email;
                ViewBag.ConfMessage3 = "Your phone number: " + newUser.YoDigits;
                ViewBag.ConfMessage4 = "Your password has been set";

                return View("Confirm");
            }
            else
            {
                return View("Error");
            }
        }


    }
}