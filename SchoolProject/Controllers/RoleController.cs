using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SchoolProject.DAL;
//using A11_RBS.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using SchoolProject.CustomFilters;

namespace SchoolProject.Controllers
{
    public class RoleController : Controller
    {
        SchoolProjectContext context;

        public RoleController()
        {
            context = new SchoolProjectContext();
        }



        /// <summary>
        /// Get All Roles
        /// </summary>
        /// <returns></returns>
        [AuthLog(Roles = "Teacher")]
        public ActionResult Index()
        {
            var Roles = context.Roles.ToList();
            return View(Roles);
        }

        /// <summary>
        /// Create  a New role
        /// </summary>
        /// <returns></returns>
        [AuthLog(Roles = "Teacher")]
        public ActionResult Create()
        {
            var Role = new IdentityRole();
            return View(Role);
        }

        /// <summary>
        /// Create a New Role
        /// </summary>
        /// <param name="Role"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(IdentityRole Role)
        {
            context.Roles.Add(Role);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}