using StudentEnrollmentRepository.ModelEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using StudentEnrollmentRepository.Repository;
using StudentEnrollmentRepository.DatabaseAccess;

namespace UniversityApplication.Controllers
{
    public class StudentRegistrationController : Controller
    {
        private readonly IStudentRegistrationDataAccess _studentDA;
        
        public StudentRegistrationController()
        {
            this._studentDA = new StudentRegistrationDataAccess();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult StudentRegistration()
        {
            return View();
        }
        [HttpGet]
        public JsonResult GetAllSubjects()
        {
            List<Subject> SubjectList = new List<Subject>();
            SubjectList = _studentDA.GetSubjectList();
            return Json(SubjectList, JsonRequestBehavior.AllowGet);
            
        }

    }
}