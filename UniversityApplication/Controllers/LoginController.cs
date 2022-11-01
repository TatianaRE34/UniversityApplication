using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentEnrollmentRepository.ModelEntities;
using StudentEnrollmentRepository.DatabaseAccess;
using StudentEnrollmentRepository.Repository;
using StudentEnrollmentRepository.ViewModel;
using System.Diagnostics;
using System.Data.SqlClient;
using Configuration.DatabaseAccess;
using System.Data;

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
        public JsonResult Login(LoginViewModel userLogin)
        { 
            var loginStatus = LoginRepository.IsPasswordTheSame(userLogin);
            return Json(new { result = loginStatus, url = Url.Action("Index", "Home") });
        }

    }
}