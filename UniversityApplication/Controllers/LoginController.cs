using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentEnrollmentRepository.ModelEntities;
using StudentEnrollmentRepository.DatabaseAccess;
using StudentEnrollmentRepository.Repository;

namespace UniversityApplication.Controllers
{
    public class LoginController : Controller
    {
        public ILoginRepository LoginRepository;
        public LoginController()
        {
            LoginRepository = new LoginRepository();
        }
        public LoginController(LoginRepository loginRepository)
        {
            LoginRepository = loginRepository;
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Login(User userLogin)
        {
            var loginStatus = LoginRepository.IsUserAuthenticated(userLogin);
            return Json(new { result =loginStatus, url = Url.Action("Index", "Home")});
        }
        public ActionResult RedirectRegistration()
        {
            var redirectUrl = Url.Action("Registration", "Registration");
            return View(redirectUrl);
        }
    }
}