using System.Web.Mvc;
using HRManagementSystem1.Models;
using HRManagementSystem1.Repository;

namespace HRManagementSystem1.Controllers
{
    public class LoginController : Controller
    {
        private EmpRepository Repository = new EmpRepository();
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection fc)
        {
            Employee emp = new Employee();
            emp.Email = fc["Email"];
            emp.Password = fc["Password"];
            string firstname = Repository.SignIn(emp);
            if (firstname == null)
            {
                return View();
            }
            Session["username"] = firstname;
            return RedirectToAction("Index","Home");
        }
    }
}