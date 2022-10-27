using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls.WebParts;
using DAL.Model;
using DAL.BusinessLogic;

namespace UniversityApplication.Controllers
{
    public class RegistrationController : Controller
    {

        
        // GET: UserRegistration
        public IRegistrationBL RegistrationBL;

        public RegistrationController()
        {
            RegistrationBL = new RegistrationBL();  
        }
        public RegistrationController(IRegistrationBL registrationBL)
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
            var registrationStatus = RegistrationBL.RegisterNew(userReg);
                     
           return Json(new { result = registrationStatus, url = Url.Action("Login", "Login") });
            
           
        }
    }
}