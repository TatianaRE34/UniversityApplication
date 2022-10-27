using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL.Model;
using DAL.BusinessLogic;

namespace UniversityApplication.Controllers
{
    public class LoginController : Controller
    {

        // GET: Login

        public ILoginBL LoginBL;

        public LoginController()
        {
            LoginBL = new LoginBL();
        }

        public LoginController(ILoginBL loginBL)
        {
            LoginBL = loginBL;
        }

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Login(User userLogin)
        {
            var loginStatus = LoginBL.UserAuthentication(userLogin);
            return Json(new { result =loginStatus, url = Url.Action("Index", "Home") });
        }
    }
}