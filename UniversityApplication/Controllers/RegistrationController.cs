using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls.WebParts;
using StudentEnrollmentRepository.ModelEntities;
using StudentEnrollmentRepository.Repository;
using StudentEnrollmentRepository.ViewModel;
using Configuration.Helper;
using System.Diagnostics;

namespace UniversityApplication.Controllers
{
    public class RegistrationController : Controller
    { 
        public SecurityHelper securityHelper;
        private readonly IRegistrationRepository _registrationRepo;
        public RegistrationController()
        {
            _registrationRepo = new RegistrationRepository();
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Registration(RegistrationViewModel userReg)
        {
            if (_registrationRepo.DoesUserExist(userReg))
            {
                return Json(new { result = "User already exists" });
            }
            else
            {
                var registrationStatus = _registrationRepo.IsNewUserRegistered(userReg);
                return Json(new { result = registrationStatus, url = Url.Action("Login", "Login") });
            }
        }
    } 
}