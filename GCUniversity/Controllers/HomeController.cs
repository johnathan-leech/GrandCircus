using GCUniversity.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace GCUniversity.Controllers
{
    public class HomeController : Controller
    {
        GCUniversityEntities DB = new GCUniversityEntities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult FinalGrades()
        {
            List<StudentCourse> finalGradeList = DB.StudentCourses.ToList();

            ViewBag.FinalGradeList = finalGradeList.OrderBy(x => x.CourseID).ToList();
            ViewBag.StudentList = DB.Students.ToList();
            ViewBag.CourseList = DB.Courses.ToList();

            //List<dynamic> allLists = new List<dynamic>();
            //allLists.Add(finalGradeList);
            //allLists.Add(studentList);
            //allLists.Add(courseList);

            //ViewBag.AllLists = allLists;

            return View();
        }

        public ActionResult ListOfStudents()
        {
            ViewBag.StudentList = DB.Students.ToList();
            ViewBag.CourseList = DB.Courses.ToList();
            ViewBag.StudentCourse = DB.StudentCourses.ToList();
            return View();
        }

        public ActionResult ListOfCourses()
        {
            ViewBag.CourseList = DB.Courses.ToList();
            ViewBag.StudentList = DB.Students.ToList();
            ViewBag.StudentCourse = DB.StudentCourses.ToList();
            return View();
        }

        public ActionResult DeleteStudent(int Id)
        {
            /*ensures that when removing the student(s) with a conflicting course(s) sharing Primary/Foreign Keys,
            we do not get an error */
            List<StudentCourse> courseList = DB.StudentCourses.Where(x => x.StudentID == Id).ToList();
            foreach (StudentCourse studentCourse in courseList)
            {
                DB.StudentCourses.Remove(studentCourse);
            }

            /* ICollection<StudentCourse> scList = DB.Students.Find(Id).StudentCourses;
               DB.StudentCourses.RemoveRange(scList); */
            //Another way to do the code above ^^^^^^

            Student find = DB.Students.Find(Id);
            DB.Students.Remove(find);
            DB.SaveChanges();

            return RedirectToAction("ListOfStudents");
        }

        public ActionResult DeleteCourse(int Id)
        {
            List<StudentCourse> courseList = DB.StudentCourses.Where(x => x.CourseID == Id).ToList();
            foreach (StudentCourse studentCourse in courseList)
            {
                DB.StudentCourses.Remove(studentCourse);
            }

            Course find = DB.Courses.Find(Id);
            DB.Courses.Remove(find);
            DB.SaveChanges();

            return RedirectToAction("ListOfCourses");
        }

        public ActionResult AddStudent()
        {
            return View();
        }

        public ActionResult SaveNewStudent(Student newStudent)
        {
            DB.Students.Add(newStudent);
            DB.SaveChanges();

            return RedirectToAction("ListOfStudents");
        }

        public ActionResult AddCourse()
        {
            return View();
        }

        public ActionResult AddNewCourse(Course newCourse)
        {
            DB.Courses.Add(newCourse);
            DB.SaveChanges();

            return RedirectToAction("ListOfCourses");
        }

        public ActionResult EditStudent(int Id)
        {
            ViewBag.EditStudent = DB.Students.Find(Id);
            return View();
        }

        public ActionResult SaveStudentUpdates(Student updateStudent)
        {
            Student oldStudent = DB.Students.Find(updateStudent.Id);

            oldStudent.FirstName = updateStudent.FirstName;
            oldStudent.LastName = updateStudent.LastName;
            oldStudent.PhoneNumber = updateStudent.PhoneNumber;
            oldStudent.Address = updateStudent.Address;

            DB.Entry(oldStudent).State = System.Data.Entity.EntityState.Modified;
            DB.SaveChanges();

            return RedirectToAction("ListOfStudents");
        }

        public ActionResult EditCourse(int Id)
        {
            ViewBag.EditCourse = DB.Courses.Find(Id);
            return View();
        }

        public ActionResult SaveCourseUpdates(Course updateCourse)
        {
            Course oldCourse = DB.Courses.Find(updateCourse.Id);

            oldCourse.Name = updateCourse.Name;
            oldCourse.Category = updateCourse.Category;

            DB.Entry(oldCourse).State = System.Data.Entity.EntityState.Modified;
            DB.SaveChanges();

            return RedirectToAction("ListOfCourses");
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
    }
}