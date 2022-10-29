using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls.WebParts;
using StudentEnrollmentRepository.ModelEntities;
using StudentEnrollmentRepository.Repository;

namespace UniversityApplication.Controllers
{
    public class RegistrationController : Controller
    {
        public IRegistrationRepository RegistrationBL;
        public RegistrationController()
        {
            RegistrationBL = new RegistrationRepository();  
        }
        public RegistrationController(IRegistrationRepository registrationBL)
        {
            RegistrationBL = registrationBL;
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
        public JsonResult Registration(User userReg)
        {
            var registrationStatus = RegistrationBL.IsNewUserRegistered(userReg);
                     
           return Json(new { result = registrationStatus, url = Url.Action("Login", "Login") });
            
           
        }
    }
}