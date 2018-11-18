using CoffeeShopApplication.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace CoffeeShopApplication.Controllers
{
    public class HomeController : Controller
    {
        private CoffeeShopDBEntities1 database = new CoffeeShopDBEntities1();

        public ActionResult Index()
        {
            ViewBag.ItemsList = database.Items.ToList();

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

        public ActionResult RegistrationError()
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

        public ActionResult AddUser(UserInfo newUserInfo)
        {
            if (ModelState.IsValid)
            {
                string firstName = new string(CharsToTitleCase(newUserInfo.FirstName).ToArray());

                ViewBag.ConfMessage1 = "Welcome " + firstName;
                ViewBag.AddedUser = "Your information was successfully added!";
                User newUser = UserFromUserInfo(newUserInfo);
                AddInfo(newUser);

                return View("Confirm");
            }
            else
            {
                TempData["ErrorMessage"] = "Unfortunately you have entered invalid information. If you would like to try again please click the link below";
                return View("RegistrationError");
            }
        }

        public void AddInfo(User newUser)
        {
            CoffeeShopDBEntities1 database = new CoffeeShopDBEntities1();   // Object Relational Mapping
            database.Users.Add(newUser);
            database.SaveChanges();
        }

        public User UserFromUserInfo(UserInfo newUserInfo)
        {
            User newUser = new User();
            newUser.firstName = newUserInfo.FirstName;
            newUser.lastName = newUserInfo.LastName;
            newUser.password = newUserInfo.Password;
            newUser.email = newUserInfo.Email;
            newUser.phoneNum = newUserInfo.Phone;

            return newUser;
        }

        public ActionResult ProductAdmin()
        {
            ViewBag.ItemsList = database.Items.ToList<Item>();
            return View();
        }

        public ActionResult AddNewItem()
        {
            return View();
        }


    }
}