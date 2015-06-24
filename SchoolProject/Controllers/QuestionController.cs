using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using PagedList;
using SchoolProject.CustomFilters;
using SchoolProject.DAL;
using SchoolProject.Models;

namespace SchoolProject.Controllers
{
    public class QuestionController : Controller
    {
        private SchoolProjectContext db = new SchoolProjectContext();

        // GET: Question
        [AuthLog(Roles = "Teacher")]
        public ActionResult Index(string sortOrder, string searchString, int? page)
        {
            ViewBag.TextSortParm = String.IsNullOrEmpty(sortOrder) ? "text_desc" : "";
            ViewBag.PointsSortParm = sortOrder == "Point" ? "point_desc" : "Point";
            ViewBag.ExplSortParm = sortOrder == "Expl" ? "expl_desc" : "Expl";
            ViewBag.FieldSortParm = sortOrder == "Field" ? "field_desc" : "Field";
            var questions = db.Questions.Include(q => q.ThematicField);

            if (!String.IsNullOrEmpty(searchString))
            {
                questions = questions.Where(s => s.Text.Contains(searchString)
                                       || s.Explanation.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "text_desc":
                    questions = questions.OrderByDescending(s => s.Text);
                    break;
                case "expl_desc":
                    questions = questions.OrderByDescending(s => s.Explanation);
                    break;
                case "Expl":
                    questions = questions.OrderBy(s => s.Explanation);
                    break;
                case "Point":
                    questions = questions.OrderBy(s => s.Points);
                    break;
                case "point_desc":
                    questions = questions.OrderByDescending(s => s.Points);
                    break;
                case "Field":
                    questions = questions.OrderBy(s => s.ThematicField.Title);
                    break;
                case "field_desc":
                    questions = questions.OrderByDescending(s => s.ThematicField.Title);
                    break;
                default:
                    questions = questions.OrderBy(s => s.Text);
                    break;
            }
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(questions.ToPagedList(pageNumber, pageSize));
        }

        // GET: Question/Details/5
        [AuthLog(Roles = "Teacher")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = db.Questions.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }

        // GET: Question/Create
        [AuthLog(Roles = "Teacher")]
        public ActionResult Create()
        {
            ViewBag.ThematicFieldID = new SelectList(db.ThematicFields, "ThematicFieldID", "Title");
            return View();
        }

        // POST: Question/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Text,Points,Explanation,ThematicFieldID")] Question question)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Questions.Add(question);
                    db.SaveChanges();
                    return RedirectToAction("Details", new {id = question.QuestionID});
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            ViewBag.ThematicFieldID = new SelectList(db.ThematicFields, "ThematicFieldID", "Title", question.ThematicFieldID);
            return View(question);
        }

        // GET: Question/Edit/5
        [AuthLog(Roles = "Teacher")]
        public ActionResult Edit(int? id, int? answerID)
        {
            if (answerID != null)
            {
                return RedirectToAction("Edit", "Answer",new { id = answerID} );
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = db.Questions.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            ViewBag.ThematicFieldID = new SelectList(db.ThematicFields, "ThematicFieldID", "Title", question.ThematicFieldID);
            return View(question);
        }

        // POST: Question/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "QuestionID,Text,Points,Explanation,ThematicFieldID")] Question question)
        {
            if (ModelState.IsValid)
            {
                db.Entry(question).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ThematicFieldID = new SelectList(db.ThematicFields, "ThematicFieldID", "Title", question.ThematicFieldID);
            return View(question);
        }

        // GET: Question/Delete/5
        [AuthLog(Roles = "Teacher")]
        public ActionResult Delete(int? id, int? answerID , bool? saveChangesError = false )
        {
            if (answerID != null)
            {
                return RedirectToAction("Delete", "Answer", new {id = answerID});
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }
            Question question = db.Questions.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }

        // POST: Question/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Question question = db.Questions.Find(id);
                db.Questions.Remove(question);
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

        [AuthLog(Roles = "Teacher")]
        public ActionResult Add(int questionID)
        {
            return RedirectToAction("Create","Answer",new {questionID = questionID});
        }
    }
}
