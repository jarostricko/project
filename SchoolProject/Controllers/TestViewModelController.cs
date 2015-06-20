using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SchoolProject.DAL;
using SchoolProject.ViewModels;

namespace SchoolProject.Controllers
{
    public class TestViewModelController : Controller
    {
        private SchoolProjectContext db = new SchoolProjectContext();

        // GET: TestViewModel
        public ActionResult Index()
        {
            return View(db.TestViewModels.ToList());
        }

        // GET: TestViewModel/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestViewModel testViewModel = db.TestViewModels.Find(id);
            if (testViewModel == null)
            {
                return HttpNotFound();
            }
            return View(testViewModel);
        }

        // GET: TestViewModel/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TestViewModel/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TestViewModelID,TestTemplateName,Score")] TestViewModel testViewModel)
        {
            if (ModelState.IsValid)
            {
                db.TestViewModels.Add(testViewModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(testViewModel);
        }

        // GET: TestViewModel/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestViewModel testViewModel = db.TestViewModels.Find(id);
            if (testViewModel == null)
            {
                return HttpNotFound();
            }
            return View(testViewModel);
        }

        // POST: TestViewModel/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TestViewModelID,TestTemplateName,Score")] TestViewModel testViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(testViewModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(testViewModel);
        }

        // GET: TestViewModel/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestViewModel testViewModel = db.TestViewModels.Find(id);
            if (testViewModel == null)
            {
                return HttpNotFound();
            }
            return View(testViewModel);
        }

        // POST: TestViewModel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TestViewModel testViewModel = db.TestViewModels.Find(id);
            db.TestViewModels.Remove(testViewModel);
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
