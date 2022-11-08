using StudentEnrollmentRepository.DatabaseAccess;
using StudentEnrollmentRepository.ModelEntities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace UniversityApplication.Controllers
{
    public class AdminController : Controller
    {
        private readonly IStudentRegistrationDataAccess _studentDA;
        public AdminController()
        {
            _studentDA = new StudentRegistrationDataAccess();
        }
        public ActionResult Admin()
        {
            return View();
        }
        //GET: StudentList
        [HttpGet]
        public JsonResult GetAllStudents()
        {
            List<Student> studentsList = new List<Student>();
            studentsList= _studentDA.GetStudentsWithGradePoint();
            return Json(studentsList, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Logout()
        {
            Response.AppendHeader("Cache-Control", "no-store");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
            Response.Cache.SetNoStore();
            Session.Clear();
            Session.Abandon();
            return Json(new { url = Url.Action("Login", "Login") });
        }

    }
}