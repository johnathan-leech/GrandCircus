using CarDealership.Models;
using System.Linq;
using System.Web.Mvc;

namespace CarDealership.Controllers
{
    public class HomeController : Controller
    {
        CarsEntities database = new CarsEntities();

        public ActionResult Index()
        {
            ViewBag.CarList = database.Cars.ToList();
            return View();
        }

        public ActionResult AddCar()
        {
            return View();
        }

        public ActionResult AddNewCar(Car newCar)
        {
            database.Cars.Add(newCar);
            database.SaveChanges();
            return View("Index");
        }

        public ActionResult DeleteCar(int Id)
        {
            Car found = database.Cars.Find(Id);
            database.Cars.Remove(found);
            database.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult EditCar(int Id)
        {
            ViewBag.EditCar = database.Cars.Find(Id);
            return View();
        }

        public ActionResult SaveCarUpdate(Car updateCar)
        {
            Car editedCar = database.Cars.Find(updateCar.Id);

            editedCar.Make = updateCar.Make;
            editedCar.Model = updateCar.Model;
            editedCar.Year = updateCar.Year;
            editedCar.Color = updateCar.Color;

            database.Entry(editedCar).State = System.Data.Entity.EntityState.Modified;
            database.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult SaveNewCar(Car newCar)
        {
            database.Cars.Add(newCar);
            database.SaveChanges();

            return RedirectToAction("Index");

        }
    }
}
