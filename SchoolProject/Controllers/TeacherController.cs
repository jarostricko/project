using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using SchoolProject.CustomFilters;
using SchoolProject.DAL;
using SchoolProject.Models;

namespace SchoolProject.Controllers
{
    public class TeacherController : Controller
    {
        private SchoolProjectContext db = new SchoolProjectContext();
        
        [AuthLog(Roles = "Teacher")]
        public ActionResult Index()
        {
            ViewBag.QuestionCount = db.Questions.Count();
            ViewBag.FieldsCount = db.ThematicFields.Count();
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
