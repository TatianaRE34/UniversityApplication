﻿using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UniversityApplication.Controllers
{
    public class StudentRegistrationController : Controller
    {
        // GET: StudentRegistration
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult StudentRegistration()
        {
            return View();
        }


        public ActionResult StudentRegistration(Student student)
        {
            return View();
        }


    }
}