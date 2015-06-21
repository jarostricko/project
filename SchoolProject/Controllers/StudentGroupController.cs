using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using SchoolProject.CustomFilters;
using SchoolProject.DAL;
using SchoolProject.Models;
using SchoolProject.ViewModels;

namespace SchoolProject.Controllers
{
    public class StudentGroupController : Controller
    {
        private SchoolProjectContext db = new SchoolProjectContext();

        // GET: StudentGroup
        [AuthLog(Roles = "Teacher")]
        public ActionResult Index(string sortOrder, string searchString, int? id, string email)
        {
            ViewBag.TitleSortParm = String.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            var viewModel = new StudentGroupIndexData();
            var studs = new List<EditUserViewModel>();
            viewModel.StudentGroups = db.StudentGroups.
                Include(i => i.Students).
                OrderBy(i => i.Title);

            if (!String.IsNullOrEmpty(searchString))
            {
                viewModel.StudentGroups = db.StudentGroups.
                Where(s => s.Title.Contains(searchString)).
                Include(i => i.Students).
                OrderBy(i => i.Title);
            }
            if (id != null && String.IsNullOrEmpty(searchString))
            {
                ViewBag.StudentGroupID = id.Value;
                var students = viewModel.StudentGroups.Where(
                    i => i.StudentGroupID == id.Value).Single().Students;
                studs = new List<EditUserViewModel>();
                foreach (var user in students)
                {
                    if (user is Student)
                    {
                        var u = new EditUserViewModel(user);
                        studs.Add(u);
                    }

                }
                viewModel.Students = studs;
            }
            if (id != null && !String.IsNullOrEmpty(searchString))
            {
                try
                {
                    ViewBag.StudentGroupID = id.Value;
                    var students = viewModel.StudentGroups.Where(s => s.Title.Contains(searchString)).
                        Where(i => i.StudentGroupID == id.Value).Single().Students;
                    studs = new List<EditUserViewModel>();
                    foreach (var user in students)
                    {
                        if (user is Student)
                        {
                            var u = new EditUserViewModel(user);
                            studs.Add(u);
                        }

                    }
                    viewModel.Students = studs;
                }
                catch (InvalidOperationException)
                {

                    ViewBag.StudentGroupID = id.Value;
                    viewModel.Students = null;
                }

            }

            switch (sortOrder)
            {
                case "title_desc":
                    viewModel.StudentGroups = viewModel.StudentGroups.
                OrderByDescending(i => i.Title);
                    break;
                default:
                    viewModel.StudentGroups = viewModel.StudentGroups.
                OrderBy(i => i.Title);
                    break;
            }


            if (email != null)
            {
                //Student student = db.Students.Find(studentID);
                Student student = (Student)db.Users.Single(a => a.Email.Equals(email));
                StudentGroup studentGroup = db.StudentGroups.Find(id);
                studentGroup.Students.Remove(student);
                db.SaveChanges();
                var s = studs.Single(a => a.Email.Equals(email));
                studs.Remove(s);
                viewModel.Students = studs;

            }
            return View(viewModel);
        }

        public ActionResult IndexStudent(string sortOrder, string searchString, int? id, string email)
        {
            ViewBag.TitleSortParm = String.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            var viewModel = new StudentGroupIndexData();
            var studs = new List<EditUserViewModel>();
            var currentUserId = User.Identity.GetUserId();
            var currentUser = db.Users.Find(currentUserId);
            var g = new List<StudentGroup>();
            var groups = db.StudentGroups.Include(i => i.Students).OrderBy(i => i.Title);
            foreach (var group in groups)
            {
                if (group.Students.Contains(currentUser))
                {
                    g.Add(group);
                }
            }
            viewModel.StudentGroups = g;

            if (!String.IsNullOrEmpty(searchString))
            {
                viewModel.StudentGroups = db.StudentGroups.
                    Where(s => s.Title.Contains(searchString)).
                    OrderBy(i => i.Title);
            }
            if (id != null && String.IsNullOrEmpty(searchString))
            {
                ViewBag.StudentGroupID = id.Value;
                var students = viewModel.StudentGroups.Where(
                    i => i.StudentGroupID == id.Value).Single().Students;
                studs = new List<EditUserViewModel>();
                foreach (var user in students)
                {
                    if (user is Student)
                    {
                        var u = new EditUserViewModel(user);
                        studs.Add(u);
                    }

                }
                viewModel.Students = studs;
            }
            if (id != null && !String.IsNullOrEmpty(searchString))
            {
                try
                {
                    ViewBag.StudentGroupID = id.Value;
                    var students = viewModel.StudentGroups.Where(s => s.Title.Contains(searchString)).
                        Where(i => i.StudentGroupID == id.Value).Single().Students;
                    studs = new List<EditUserViewModel>();
                    foreach (var user in students)
                    {
                        if (user is Student)
                        {
                            var u = new EditUserViewModel(user);
                            studs.Add(u);
                        }

                    }
                    viewModel.Students = studs;
                }
                catch (InvalidOperationException)
                {

                    ViewBag.StudentGroupID = id.Value;
                    viewModel.Students = null;
                }

            }

            //switch (sortOrder)
            //{
            //    case "title_desc":
            //        viewModel.StudentGroups = viewModel.StudentGroups.
            //            OrderByDescending(i => i.Title);
            //        break;
            //    default:
            //        viewModel.StudentGroups = viewModel.StudentGroups.
            //            OrderBy(i => i.Title);
            //        break;
            //}
            
            return View(viewModel);
        }
        
        

        // GET: StudentGroup/Details/5
        [AuthLog(Roles = "Teacher")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentGroup studentGroup = db.StudentGroups.Find(id);
            if (studentGroup == null)
            {
                return HttpNotFound();
            }
            return View(studentGroup);
        }

        // GET: StudentGroup/Create
        [AuthLog(Roles = "Teacher")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentGroup/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Title")] StudentGroup studentGroup)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    db.StudentGroups.Add(studentGroup);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(studentGroup);
        }

        // GET: StudentGroup/Edit/5
        [AuthLog(Roles = "Teacher")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentGroup studentGroup = db.StudentGroups.Find(id);
            if (studentGroup == null)
            {
                return HttpNotFound();
            }
            return View(studentGroup);
        }

        // POST: StudentGroup/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthLog(Roles = "Teacher")]
        public ActionResult Edit([Bind(Include = "StudentGroupID,Title")] StudentGroup studentGroup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentGroup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(studentGroup);
        }

        // GET: StudentGroup/Delete/5
        [AuthLog(Roles = "Teacher")]
        public ActionResult Delete(int? id, bool? saveChangesError = false)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }
            StudentGroup studentGroup = db.StudentGroups.Find(id);
            if (studentGroup == null)
            {
                return HttpNotFound();
            }
            return View(studentGroup);
        }

        // POST: StudentGroup/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AuthLog(Roles = "Teacher")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                StudentGroup studentGroup = db.StudentGroups.Find(id);
                db.StudentGroups.Remove(studentGroup);
                db.SaveChanges();
            }
            catch (DataException/* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult AddStudent(int id)
        {
            StudentGroup studentGroup = db.StudentGroups.Find(id);
            var viewModel = new StudentGroupIndexData();
            viewModel.StudentGroup = studentGroup;
            //viewModel.Students = db.Students.OrderBy(i => i.SureName);
            var users = db.Users;
            var studs = new List<EditUserViewModel>();
            foreach (var user in users)
            {
                if (user is Student)//&& !studentGroup.Students.Contains(user)
                {
                    var u = new EditUserViewModel(user);
                    studs.Add(u);
                }
            }
            viewModel.Students = studs;
            //viewModel.Students = viewModel.Students.Except(studentGroup.Students);
            return View(viewModel);
        }

        public ActionResult AddStudentByEmail(int id, string studentEmail)
        {
            StudentGroup studentGroup = db.StudentGroups.Find(id);
            //Student student = db.Students.Find(studentID);
            Student student = (Student)db.Users.Single(u => u.Email.Equals(studentEmail));
            studentGroup.Students.Add(student);
            db.SaveChanges();
            return RedirectToAction("Index",new { id = studentGroup.StudentGroupID });

        }
    }
}
