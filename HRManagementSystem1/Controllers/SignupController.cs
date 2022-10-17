using System.Web.Mvc;
using HRManagementSystem1.Models;
using HRManagementSystem1.Repository;

namespace HRManagementSystem1.Controllers
{
    public class SignupController : Controller
    {
        private EmpRepository Repository = new EmpRepository();
        // GET: Signup
        public ActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Signup(FormCollection fc)
        {
            Employee emp = new Employee();
            emp.FirstName = fc["FirstName"];
            emp.LastName = fc["LastName"];
            emp.Email = fc["Email"];
            emp.Password = fc["Password"];
            //emp.ConfPassword = fc["ConfPassword"];
            if (Repository.AddEmployee(emp)){
                @TempData["Message"] = "<script>alert('Sign Up Successful')</script>";
            }
            {
                @TempData["Message"] = "<script>alert('Account already exists redirecting to Login')</script>";
            }

            return RedirectToAction("Login","Login");
        }
    }
}