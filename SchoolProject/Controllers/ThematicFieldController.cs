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
    public class ThematicFieldController : Controller
    {
        private SchoolProjectContext db = new SchoolProjectContext();

        // GET: ThematicField
        public ActionResult Index(string sortOrder, string searchString)
        {
            ViewBag.TitleSortParm = String.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            var fields = db.ThematicFields.ToList();
            if (!String.IsNullOrEmpty(searchString))
            {
                fields = fields.Where(s => s.Title.Contains(searchString)).ToList();
            }
            switch (sortOrder)
            {
                case "title_desc":
                    fields = fields.OrderByDescending(s => s.Title).ToList();
                    break;
                default:
                    fields = fields.OrderBy(s => s.Title).ToList();
                    break;
            }
            return View(fields.ToList());
        }

        // GET: ThematicField/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThematicField thematicField = db.ThematicFields.Find(id);
            if (thematicField == null)
            {
                return HttpNotFound();
            }
            return View(thematicField);
        }

        // GET: ThematicField/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ThematicField/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Title")] ThematicField thematicField)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.ThematicFields.Add(thematicField);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(thematicField);
        }

        // GET: ThematicField/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThematicField thematicField = db.ThematicFields.Find(id);
            if (thematicField == null)
            {
                return HttpNotFound();
            }
            return View(thematicField);
        }

        // POST: ThematicField/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ThematicFieldID,Title")] ThematicField thematicField)
        {
            if (ModelState.IsValid)
            {
                db.Entry(thematicField).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(thematicField);
        }

        // GET: ThematicField/Delete/5
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
            ThematicField thematicField = db.ThematicFields.Find(id);
            if (thematicField == null)
            {
                return HttpNotFound();
            }
            return View(thematicField);
        }

        // POST: ThematicField/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                ThematicField thematicField = db.ThematicFields.Find(id);
                db.ThematicFields.Remove(thematicField);
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
    }
}
