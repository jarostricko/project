using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SchoolProject.DAL;
using SchoolProject.Models;

namespace SchoolProject.Controllers
{
    public class StudentsTestController : Controller
    {
        private SchoolProjectContext db = new SchoolProjectContext();

        // GET: StudentsTest
        public ActionResult Index()
        {
            return View(db.StudentsTests.ToList());
        }

        // GET: StudentsTest/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentsTest studentsTest = db.StudentsTests.Find(id);
            if (studentsTest == null)
            {
                return HttpNotFound();
            }
            return View(studentsTest);
        }

        // GET: StudentsTest/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentsTest/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentTestID,StudentID,Points")] StudentsTest studentsTest)
        {
            if (ModelState.IsValid)
            {
                db.StudentsTests.Add(studentsTest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(studentsTest);
        }

        // GET: StudentsTest/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentsTest studentsTest = db.StudentsTests.Find(id);
            if (studentsTest == null)
            {
                return HttpNotFound();
            }
            return View(studentsTest);
        }

        // POST: StudentsTest/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentTestID,StudentID,Points")] StudentsTest studentsTest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentsTest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(studentsTest);
        }

        // GET: StudentsTest/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentsTest studentsTest = db.StudentsTests.Find(id);
            if (studentsTest == null)
            {
                return HttpNotFound();
            }
            return View(studentsTest);
        }

        // POST: StudentsTest/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentsTest studentsTest = db.StudentsTests.Find(id);
            db.StudentsTests.Remove(studentsTest);
            db.SaveChanges();
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
    }
}
