using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SchoolProject.CustomFilters;
using SchoolProject.DAL;
using SchoolProject.Models;

namespace SchoolProject.Controllers
{
    public class AnswerController : Controller
    {
        private SchoolProjectContext db = new SchoolProjectContext();

        // GET: Answer
        [AuthLog(Roles = "Teacher")]
        public ActionResult Index(int? question)
        {
            if (question != null)
            {
                return RedirectToAction("Details", "Question", new {id = question});
            }
            var answers = db.Answers.Include(a => a.Question);
            return View(answers.ToList());
        }

        // GET: Answer/Details/5
        [AuthLog(Roles = "Teacher")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Answer answer = db.Answers.Find(id);
            if (answer == null)
            {
                return HttpNotFound();
            }
            return View(answer);
        }

        // GET: Answer/Create
        [AuthLog(Roles = "Teacher")]
        public ActionResult Create(int? questionID)
        {
            if (questionID != null)
            {
                List<Question> questions = new List<Question>();
                questions.Add(db.Questions.Find(questionID));
                ViewBag.QuestionID = new SelectList(questions, "QuestionID", "Text");
            }
            else
            {
                ViewBag.QuestionID = new SelectList(db.Questions, "QuestionID", "Text");
            }
            
            return View();
        }

        // POST: Answer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AnswerText,IsCorrect,QuestionID")] Answer answer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Answers.Add(answer);
                    db.SaveChanges();
                    return RedirectToAction("Details", "Question", new { id = answer.QuestionID });
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            ViewBag.QuestionID = new SelectList(db.Questions, "QuestionID", "Text", answer.QuestionID);
            return View(answer);
        }

        // GET: Answer/Edit/5
        [AuthLog(Roles = "Teacher")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Answer answer = db.Answers.Find(id);
            if (answer == null)
            {
                return HttpNotFound();
            }
            ViewBag.QuestionID = new SelectList(db.Questions.Where(q => q.QuestionID.Equals(answer.QuestionID)), "QuestionID", "Text", answer.QuestionID); 
            return View(answer);
        }

        // POST: Answer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AnswerID,AnswerText,IsCorrect,QuestionID")] Answer answer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(answer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", "Question", new { id = answer.QuestionID });
            }
            ViewBag.Question = answer.QuestionID;
            ViewBag.QuestionID = new SelectList(db.Questions, "QuestionID", "Text", answer.QuestionID); 
            return View(answer);
        }

        // GET: Answer/Delete/5
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
            Answer answer = db.Answers.Find(id);
            ViewBag.Question = answer.QuestionID;
            if (answer == null)
            {
                return HttpNotFound();
            }
            return View(answer);
        }

        // POST: Answer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Answer answer = db.Answers.Find(id);
            try
            {
                
                db.Answers.Remove(answer);
                db.SaveChanges();
            }
            catch (DataException/* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }

            return RedirectToAction("Details", "Question", new { id = answer.QuestionID });
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
