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
    public class TestTemplateController : Controller
    {
        private SchoolProjectContext db = new SchoolProjectContext();

        // GET: TestTemplate
        public ActionResult Index()
        {
            var testTemplates = db.TestTemplates.Include(t => t.StudentGroup);
            return View(testTemplates.ToList());
        }

        // GET: TestTemplate/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestTemplate testTemplate = db.TestTemplates.Find(id);
            if (testTemplate == null)
            {
                return HttpNotFound();
            }
            return View(testTemplate);
        }

        // GET: TestTemplate/Create
        public ActionResult Create()
        {
            ViewBag.StudentGroupID = new SelectList(db.StudentGroups, "StudentGroupID", "Title");
            return View();
        }

        // POST: TestTemplate/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,Time,StartTime,EndTime,QuestionCount,StudentGroupID")] TestTemplate testTemplate)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.TestTemplates.Add(testTemplate);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            ViewBag.StudentGroupID = new SelectList(db.StudentGroups, "StudentGroupID", "Title", testTemplate.StudentGroupID);
            return View(testTemplate);
        }

        // GET: TestTemplate/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestTemplate testTemplate = db.TestTemplates.Find(id);
            if (testTemplate == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentGroupID = new SelectList(db.StudentGroups, "StudentGroupID", "Title", testTemplate.StudentGroupID);
            return View(testTemplate);
        }

        // POST: TestTemplate/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TestTemplateID,Name,Time,StartTime,EndTime,QuestionCount,StudentGroupID")] TestTemplate testTemplate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(testTemplate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StudentGroupID = new SelectList(db.StudentGroups, "StudentGroupID", "Title", testTemplate.StudentGroupID);
            return View(testTemplate);
        }

        // GET: TestTemplate/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestTemplate testTemplate = db.TestTemplates.Find(id);
            if (testTemplate == null)
            {
                return HttpNotFound();
            }
            return View(testTemplate);
        }

        // POST: TestTemplate/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TestTemplate testTemplate = db.TestTemplates.Find(id);
            db.TestTemplates.Remove(testTemplate);
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
