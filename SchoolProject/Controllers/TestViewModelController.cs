using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using SchoolProject.CustomFilters;
using SchoolProject.DAL;
using SchoolProject.Models;
using SchoolProject.Models.Binders;
using SchoolProject.ViewModels;

namespace SchoolProject.Controllers
{
    public class TestViewModelController : Controller
    {
        private SchoolProjectContext db = new SchoolProjectContext();
        
        [AuthLog]
        public ActionResult TakeTest(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestTemplate testTemplate = db.TestTemplates.Include(a => a.Questions).Single(a => a.TestTemplateID == id);
            if (testTemplate == null)
            {
                return HttpNotFound();
            }
            var allQuestions = db.Questions.Include(a => a.AnswersList).ToList();
            var questions = new List<Question>();
            foreach (var q in allQuestions)
            {
                if (testTemplate.Questions.Contains(q))
                {
                    questions.Add(q);
                }
            }
            TestViewModel testViewModel = new TestViewModel
            {
                Questions = questions,
                TestTemplateName = testTemplate.Name,
                Score = 0
            };
            ViewBag.Questions = testViewModel.Questions;
            return View(testViewModel);
        }

        [AuthLog]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TakeTest(string[] selectedObjects)
        {
            float points = 0;
            List<StudentAnswer> studentAnswers = new List<StudentAnswer>();
            List<Question> testQuestions = new List<Question>();
            StudentsTest studentsTest = new StudentsTest();
            foreach (var pair in selectedObjects)
            {
                var splitted = pair.Split(',');

                var ansIDstring = splitted[0];
                int ansID;
                Int32.TryParse(ansIDstring, out ansID);
                var answer = db.Answers.Find(ansID);
                var sAns = new StudentAnswer { Answer = answer, AnswerID = ansID, IsChecked = true };

                var queIDstring = splitted[1];
                int queID;
                Int32.TryParse(queIDstring, out queID);
                var question = db.Questions.Find(queID);
                testQuestions.Add(question);
                float numCA = question.NumOfCorrectAns();

                if (answer.IsCorrect)
                {
                    if (numCA > 1 )
                    {
                        points = points + (question.Points / numCA);
                        sAns.Points = question.Points/numCA;


                    }
                    else
                    {
                        points = points + question.Points;
                        sAns.Points = question.Points;
                    }
                }
                studentAnswers.Add(sAns);
            }
            
            string templateName = selectedObjects[0].Split(',')[2];
            TestTemplate testTemplate = db.TestTemplates.Single(t => t.Name.Equals(templateName));
            studentsTest.TestTemplate = testTemplate;
            studentsTest.Points = points;
            studentsTest.StudentAnswers = studentAnswers;
            var userID = User.Identity.GetUserId();
            Student student = (Student) db.Users.Find(userID);
            studentsTest.Student = student;
            db.StudentsTests.Add(studentsTest);
            db.StudentAnswers.AddRange(studentAnswers);
            db.SaveChanges();
            
            return RedirectToAction("IndexStudent", "TestTemplate");
        }
        [AuthLog(Roles = "Teacher")]
        // GET: TestViewModel
        public ActionResult Index()
        {
            return View(db.TestViewModels.ToList());
        }

        [AuthLog(Roles = "Teacher")]
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

        [AuthLog(Roles = "Teacher")]
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

        [AuthLog(Roles = "Teacher")]
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

        [AuthLog(Roles = "Teacher")]
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
        [AuthLog(Roles = "Teacher")]
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
