using StudentEnrollmentRepository.ModelEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using StudentEnrollmentRepository.Repository;
using StudentEnrollmentRepository.DatabaseAccess;
using System.Web.UI.WebControls;

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
        public JsonResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            return Json(new {url = Url.Action("Login", "Login") });
        }
        [HttpPost]
        public JsonResult RegisterStudent(Student student)
        { 
            student.UserId = Convert.ToInt32(this.Session["CurrentUserID"]);
            if (_studentDA.IsInformationUnique(student)){
                _studentDA.RegisterStudent(student);
                return Json(new {result="Registered"});
            }
          return Json(new { result = "Student exists" });
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