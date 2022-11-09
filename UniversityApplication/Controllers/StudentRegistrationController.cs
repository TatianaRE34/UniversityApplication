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
        [HttpPost]
        public JsonResult RegisterStudent(Student student)
        { 
            student.UserId = Convert.ToInt32(this.Session["CurrentUserID"]);
            if (_studentDA.IsInformationUnique(student)){
                _studentDA.RegisterStudent(student);
                return Json(new {url = Url.Action("Index", "Home") });
            }
          return Json(new { url = Url.Action("Index", "Home") });
        }
        [HttpGet]
        public JsonResult GetAllSubjects()
        {
            List<Subject> SubjectList = new List<Subject>();
            SubjectList = _studentDA.GetSubjectList();
            return Json(SubjectList, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult Logout()
        {
            Response.AppendHeader("Cache-Control", "no-store");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
            Response.Cache.SetNoStore();
            Session.Clear();
            Session.Abandon();
            return Json(new { url = Url.Action("Login", "Login") },JsonRequestBehavior.AllowGet);
        }
    }
}