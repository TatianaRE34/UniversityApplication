﻿using System;
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
        public IRegistrationRepository registrationRepo;
        public RegistrationController()
        {
            registrationRepo = new RegistrationRepository();
        }
        public RegistrationController(IRegistrationRepository registrationBL)
        {
            registrationRepo = registrationBL;
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
            if (registrationRepo.DoesUserExist(userReg))
            {
                return Json(new { result = "User already exists" });
            }
            else
            {
                var registrationStatus = registrationRepo.IsNewUserRegistered(userReg);


                return Json(new { result = registrationStatus, url = Url.Action("Login", "Login") });
            }
        }
    } 
}