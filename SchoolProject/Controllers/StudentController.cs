using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using SchoolProject.DAL;
using SchoolProject.Models;
using PagedList;
using SchoolProject.CustomFilters;


namespace SchoolProject.Controllers
{
    public class StudentController : Controller
    {
        private SchoolProjectContext db = new SchoolProjectContext();
        
        // GET: Student
        [AuthLog]
        public ActionResult Index()
        {
            ViewBag.Student = User.Identity.GetUserName();
          return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
