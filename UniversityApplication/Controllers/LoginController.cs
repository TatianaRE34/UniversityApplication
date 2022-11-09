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
using Microsoft.Ajax.Utilities;
using System.Web.UI.WebControls;
namespace UniversityApplication.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginRepository _loginRepository;
        public LoginController(ILoginRepository iLoginRepository)
        {
            _loginRepository = iLoginRepository;
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Login(LoginViewModel userLogin)
        {
            bool loginStatus = _loginRepository.IsUserAuthenticated(userLogin);
            LoginViewModel user = _loginRepository.GetUserDetailsWithRoles(userLogin);
            RoleId userRole = (RoleId)user.RoleId;
            if (loginStatus)
            {
                this.Session["CurrentUser"] = user;
                this.Session["CurrentUserID"] = user.UserID;
                Debug.WriteLine("this is session:" + user.UserID);
                if (userRole == RoleId.Admin)
                {
                    this.Session["CurrentRole"] = user.RoleName;
                    return Json(new { result = loginStatus, url = Url.Action("Admin", "Admin") });
                }
                else if (userRole == RoleId.User)
                {
                    this.Session["CurrentRole"] = user.RoleName;
                    return Json(new { result = loginStatus, url = Url.Action("StudentRegistration", "StudentRegistration") });
                }
                else if (userRole == RoleId.Student)
                {
                    this.Session["CurrentRole"] = user.RoleName;
                    return Json(new { result = loginStatus, url = Url.Action("Index", "Home") });
                }
            }
            return Json(new { result = loginStatus, url = Url.Action("Login") });
        }
    }
}