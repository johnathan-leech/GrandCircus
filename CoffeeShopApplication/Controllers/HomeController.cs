using CoffeeShopApplication.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace CoffeeShopApplication.Controllers
{
    public class HomeController : Controller
    {
        public List<Item> listOfItemsFromDB;

        public ActionResult Index()
        {
            CoffeeShopDBEntities1 database = new CoffeeShopDBEntities1();
            ViewBag.ItemsList = database.Items.ToList<Item>();

            //ViewBag.listItems = database.Items.ToList<Item>();

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

        public ActionResult AddUser(UserInfo newUserInfo)
        {
            if (ModelState.IsValid)
            {
                string firstName = new string(CharsToTitleCase(newUserInfo.FirstName).ToArray());

                ViewBag.ConfMessage1 = "Welcome " + firstName;
                ViewBag.AddedUser = "Item was successfully added";
                User newUser = UserFromUserInfo(newUserInfo);
                AddInfo(newUser);

                return View("Confirm");
            }
            else
            {
                return View("Error");
            }
        }

        public void AddInfo(User newUser)
        {
            CoffeeShopDBEntities database = new CoffeeShopDBEntities();   // Object Relational Mapping
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
    }
}