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

namespace SchoolProject.Controllers
{
    public class StudentsTestController : Controller
    {
        private SchoolProjectContext db = new SchoolProjectContext();

        // GET: StudentsTest
        [AuthLog(Roles = "Teacher")]
        public ActionResult Index()
        {
            var studentTests = db.StudentsTests.Include(a => a.StudentAnswers).Include(s => s.Student).Include(c => c.TestTemplate).ToList();
            
            
            return View(studentTests);
        }

        [AuthLog]
        public ActionResult IndexStudent()
        {
            var userID = User.Identity.GetUserId();
            Student student = (Student)db.Users.Find(userID);
            var studeTests = student.StudentsTests;
            var studentTests = db.StudentsTests.Include(a => a.StudentAnswers).Include(s => s.Student).Include(c => c.TestTemplate).ToList();
            return View(studeTests);
        }

        [AuthLog(Roles = "Teacher")]
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

        [AuthLog(Roles = "Teacher")]
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

        [AuthLog(Roles = "Teacher")]
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

        [AuthLog(Roles = "Teacher")]
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
        [AuthLog(Roles = "Teacher")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentsTest studentsTest = db.StudentsTests.Find(id);
            List<StudentAnswer> studentAnswers = studentsTest.StudentAnswers;
            db.StudentAnswers.RemoveRange(studentAnswers);
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

        [AuthLog(Roles = "Teacher")]
        public ActionResult Answers(int id)
        {
            StudentsTest studentsTest = db.StudentsTests.Find(id);
            List<Answer> studentAnswers = new List<Answer>();

            foreach (var ans in studentsTest.StudentAnswers)
            {
                int answerID = ans.AnswerID;
                var answer = db.Answers.Find(answerID);
                answer.TempPoints = ans.Points;
                studentAnswers.Add(answer);
            }
            return View(studentAnswers);
        }
        [AuthLog]
        public ActionResult AnswersStudent(int id)
        {
            StudentsTest studentsTest = db.StudentsTests.Find(id);
            List<Answer> studentAnswers = new List<Answer>();

            foreach (var ans in studentsTest.StudentAnswers)
            {
                int answerID = ans.AnswerID;
                var answer = db.Answers.Find(answerID);
                answer.TempPoints = ans.Points;
                studentAnswers.Add(answer);
            }
            return View(studentAnswers);
        }

        
    }
}
