using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using SchoolProject.CustomFilters;
using SchoolProject.DAL;
using SchoolProject.Models;
using SchoolProject.ViewModels;
using WebGrease.Activities;
using ModelBinders = System.Web.Mvc.ModelBinders;

namespace SchoolProject.Controllers
{
    public class TestTemplateController : Controller
    {
        private SchoolProjectContext db = new SchoolProjectContext();

        // GET: TestTemplate
        public ActionResult Index(string sortOrder, string searchString)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.TimeSortParm = sortOrder == "Time" ? "time_desc" : "Time";
            ViewBag.STimeSortParm = sortOrder == "STime" ? "stime_desc" : "STime";
            ViewBag.ETimeSortParm = sortOrder == "ETime" ? "etime_desc" : "ETime";
            ViewBag.CountSortParm = sortOrder == "Count" ? "count_desc" : "Count";
            ViewBag.GroupSortParm = sortOrder == "Group" ? "group_desc" : "Group";


            var testTemplates = db.TestTemplates.Include(t => t.StudentGroup);

            if (!String.IsNullOrEmpty(searchString))
            {
                testTemplates = testTemplates.Where(s => s.Name.Contains(searchString)
                                       || s.StudentGroup.Title.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    testTemplates = testTemplates.OrderByDescending(s => s.Name);
                    break;
                case "time_desc":
                    testTemplates = testTemplates.OrderByDescending(s => s.Time);
                    break;
                case "Time":
                    testTemplates = testTemplates.OrderBy(s => s.Time);
                    break;
                case "STime":
                    testTemplates = testTemplates.OrderBy(s => s.StartTime);
                    break;
                case "stime_desc":
                    testTemplates = testTemplates.OrderByDescending(s => s.StartTime);
                    break;
                case "ETime":
                    testTemplates = testTemplates.OrderBy(s => s.EndTime);
                    break;
                case "etime_desc":
                    testTemplates = testTemplates.OrderByDescending(s => s.EndTime);
                    break;
                case "Count":
                    testTemplates = testTemplates.OrderBy(s => s.QuestionCount);
                    break;
                case "count_desc":
                    testTemplates = testTemplates.OrderByDescending(s => s.QuestionCount);
                    break;
                case "Group":
                    testTemplates = testTemplates.OrderBy(s => s.StudentGroup.Title);
                    break;
                case "group_desc":
                    testTemplates = testTemplates.OrderByDescending(s => s.StudentGroup.Title);
                    break;
                default:
                    testTemplates = testTemplates.OrderBy(s => s.Name);
                    break;
            }
            return View(testTemplates.ToList());
        }

        public ActionResult IndexStudent(string sortOrder, string searchString)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.TimeSortParm = sortOrder == "Time" ? "time_desc" : "Time";
            ViewBag.STimeSortParm = sortOrder == "STime" ? "stime_desc" : "STime";
            ViewBag.ETimeSortParm = sortOrder == "ETime" ? "etime_desc" : "ETime";
            ViewBag.CountSortParm = sortOrder == "Count" ? "count_desc" : "Count";
            ViewBag.GroupSortParm = sortOrder == "Group" ? "group_desc" : "Group";

            Student student = (Student)db.Users.Find(User.Identity.GetUserId());
            List<StudentsTest> studentsTests = student.StudentsTests;
            List<TestTemplate> usedTemplates = studentsTests.Select(studentTest => studentTest.TestTemplate).ToList();

            List<StudentGroup> studentGroups = student.StudentGroups;
            List<TestTemplate> testTemplatesForStudent = new List<TestTemplate>();
            IEnumerable<TestTemplate> testTemplates = db.TestTemplates.Include(t => t.StudentGroup);
            foreach (var template in testTemplates)
            {
                if (studentGroups.Contains(template.StudentGroup) && !usedTemplates.Contains(template))
                {
                    testTemplatesForStudent.Add(template);
                }
            }
            //var testTemplates = db.TestTemplates.Include(t => t.StudentGroup);
            //testTemplates = testTemplates.Where(a => a.)

            if (!String.IsNullOrEmpty(searchString))
            {
                testTemplatesForStudent = testTemplatesForStudent.Where(s => s.Name.Contains(searchString)
                                       || s.StudentGroup.Title.Contains(searchString)).ToList();
            }
            switch (sortOrder)
            {
                case "name_desc":
                    testTemplatesForStudent = testTemplatesForStudent.OrderByDescending(s => s.Name).ToList();
                    break;
                case "time_desc":
                    testTemplatesForStudent = testTemplatesForStudent.OrderByDescending(s => s.Time).ToList();
                    break;
                case "Time":
                    testTemplatesForStudent = testTemplatesForStudent.OrderBy(s => s.Time).ToList();
                    break;
                case "STime":
                    testTemplatesForStudent = testTemplatesForStudent.OrderBy(s => s.StartTime).ToList();
                    break;
                case "stime_desc":
                    testTemplatesForStudent = testTemplatesForStudent.OrderByDescending(s => s.StartTime).ToList();
                    break;
                case "ETime":
                    testTemplatesForStudent = testTemplatesForStudent.OrderBy(s => s.EndTime).ToList();
                    break;
                case "etime_desc":
                    testTemplatesForStudent = testTemplatesForStudent.OrderByDescending(s => s.EndTime).ToList();
                    break;
                case "Count":
                    testTemplatesForStudent = testTemplatesForStudent.OrderBy(s => s.QuestionCount).ToList();
                    break;
                case "count_desc":
                    testTemplatesForStudent = testTemplatesForStudent.OrderByDescending(s => s.QuestionCount).ToList();
                    break;
                case "Group":
                    testTemplatesForStudent = testTemplatesForStudent.OrderBy(s => s.StudentGroup.Title).ToList();
                    break;
                case "group_desc":
                    testTemplatesForStudent = testTemplatesForStudent.OrderByDescending(s => s.StudentGroup.Title).ToList();
                    break;
                default:
                    testTemplatesForStudent = testTemplatesForStudent.OrderBy(s => s.Name).ToList();
                    break;
            }
            return View(testTemplatesForStudent);
        }
          

        // GET: TestTemplate/Details/5
        [AuthLog(Roles = "Teacher")]
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
        [AuthLog(Roles = "Teacher")]
        public ActionResult Create()
        {
            var testTemplate = new TestTemplate();
            testTemplate.ThematicFields = new List<ThematicField>();
            PopulateAssignedFieldData(testTemplate);
            ViewBag.StudentGroupID = new SelectList(db.StudentGroups, "StudentGroupID", "Title");
            return View();
        }

        // POST: TestTemplate/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,Time,StartTime,EndTime,QuestionCount,StudentGroupID")] TestTemplate testTemplate, string[] selectedFields)
        {
            if (selectedFields != null)
            {
                testTemplate.ThematicFields = new List<ThematicField>();
                foreach (var field in selectedFields)
                {
                    var fieldToAdd = db.ThematicFields.Find(int.Parse(field));
                    testTemplate.ThematicFields.Add(fieldToAdd);
                }
            }
            try
            {
                if (ModelState.IsValid)
                {
                    GenerateRandomQuestions(testTemplate,false);
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
            PopulateAssignedFieldData(testTemplate);
            ViewBag.StudentGroupID = new SelectList(db.StudentGroups, "StudentGroupID", "Title", testTemplate.StudentGroupID);
            return View(testTemplate);
        }

        private void PopulateAssignedFieldData(TestTemplate testTemplate)
        {
            var allFields = db.ThematicFields;
            var templateFields = new HashSet<int>(testTemplate.ThematicFields.Select(c => c.ThematicFieldID));
            var viewModel = new List<FieldsTemplatesData>();
            foreach (var field in allFields)
            {
                viewModel.Add(new FieldsTemplatesData
                {
                    ThematicFieldID = field.ThematicFieldID,
                    Title = field.Title,
                    Assigned = templateFields.Contains(field.ThematicFieldID)
                });
            }
            ViewBag.ThematicFields = viewModel;
        }

        // GET: TestTemplate/Edit/5
        [AuthLog(Roles = "Teacher")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestTemplate testTemplate = db.TestTemplates.Find(id);
            PopulateAssignedFieldData(testTemplate);
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
        [AuthLog(Roles = "Teacher")]
        public ActionResult Edit(int? id, string[] selectedFields)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var templateToUpdate = db.TestTemplates
               .Include(i => i.StudentGroup)
               .Include(i => i.ThematicFields)
               .Where(i => i.TestTemplateID == id)
               .Single();

            if (TryUpdateModel(templateToUpdate, "",
                new string[] { "TestTemplateID", "Name", "Time", "StartTime", "EndTime", "QuestionCount", "StudentGroupID" }))
            {
                try
                {

                    UpdateTemplateFields(selectedFields, templateToUpdate);
                    GenerateRandomQuestions(templateToUpdate,false);

                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch (RetryLimitExceededException /* dex */)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            }
            PopulateAssignedFieldData(templateToUpdate);
            return View(templateToUpdate);
        }
        //public ActionResult Edit([Bind(Include = "TestTemplateID,Name,Time,StartTime,EndTime,QuestionCount,StudentGroupID")] TestTemplate testTemplate, string[] selectedFields)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {

        //            UpdateTemplateFields(selectedFields, testTemplate);
        //            db.Entry(testTemplate).State = EntityState.Modified;
        //            db.SaveChanges();
        //            return RedirectToAction("Index");
        //        }
        //    }
        //    catch (RetryLimitExceededException)
        //    {

        //        ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
        //    }
        //    PopulateAssignedFieldData(testTemplate);
        //    ViewBag.StudentGroupID = new SelectList(db.StudentGroups, "StudentGroupID", "Title", testTemplate.StudentGroupID);
        //    return View(testTemplate);
        //}

        private void UpdateTemplateFields(string[] selectedFields, TestTemplate testTemplate)
        {
            if (selectedFields == null)
            {
                testTemplate.ThematicFields = new List<ThematicField>();
                return;
            }



            var selectedFieldsHS = new HashSet<string>(selectedFields);
            var templateFields = new HashSet<int>
                (testTemplate.ThematicFields.Select(c => c.ThematicFieldID));
            foreach (var field in db.ThematicFields)
            {
                if (selectedFieldsHS.Contains(field.ThematicFieldID.ToString()))
                {
                    
                    if (!templateFields.Contains(field.ThematicFieldID))
                    {
                        testTemplate.ThematicFields.Add(field);
                    }
                }
                else
                {
                    if (templateFields.Contains(field.ThematicFieldID))
                    {

                        testTemplate.ThematicFields.Remove(field);
                    }
                }
            }
        }

        // GET: TestTemplate/Delete/5
        [AuthLog(Roles = "Teacher")]
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
        [AuthLog(Roles = "Teacher")]
        public ActionResult DeleteConfirmed(int id)
        {
            TestTemplate testTemplate = db.TestTemplates.Find(id);
            db.TestTemplates.Remove(testTemplate);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public void GenerateRandomQuestions(TestTemplate testTemplate, bool refresh)
        {
            if (refresh)
            {
                testTemplate.Questions.Clear();
                testTemplate.Questions = null;
                db.SaveChanges();
            }
            else if (testTemplate.Questions != null)
            {
                if (testTemplate.QuestionCount == testTemplate.Questions.Count)
                {
                    return;
                }
                testTemplate.Questions.Clear();
                testTemplate.Questions = null;
                db.SaveChanges();
            }
            
            
            var thematicFields = testTemplate.ThematicFields;
            var questions = db.Questions.ToList();
            List<Question> list = new List<Question>();
            List<Question> toChoose = new List<Question>();
            Random rnd = new Random();
            int number;
            int totalPoints = 0;

            foreach (var question in questions)
            {
                if (thematicFields.Contains(question.ThematicField))
                {
                    toChoose.Add(question);
                }
            }

            if (toChoose.Count <= testTemplate.QuestionCount)
            {
                testTemplate.Questions = toChoose.ToList();
                totalPoints += toChoose.Sum(question => question.Points);
                testTemplate.FullPoints = totalPoints;
                return;
            }
            for (int i = 0; i < testTemplate.QuestionCount; i++)
            {
                number = rnd.Next(0, toChoose.Count);
                while (list.Contains(toChoose[number]))
                {
                    number = rnd.Next(0, toChoose.Count);
                }
                list.Add(toChoose[number]);
                totalPoints += toChoose[number].Points;
            }

            testTemplate.Questions = list;
            testTemplate.FullPoints = totalPoints;

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult Refresh(int id)
        {
            try
            {

                TestTemplate testTemplate = db.TestTemplates.Find(id);
                GenerateRandomQuestions(testTemplate, true);
                db.SaveChanges();
                
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }
            return RedirectToAction("Details", new { id = id });
        }

        public ActionResult TakeTest(int? id)
        {
            return RedirectToAction("TakeTest", "TestViewModel",new {id = id});
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //TestTemplate testTemplate = db.TestTemplates.Include(a => a.Questions).Single(a => a.TestTemplateID == id);
            //if (testTemplate == null)
            //{
            //    return HttpNotFound();
            //}
            //TestViewModel testViewModel = new TestViewModel();
            //testViewModel.Questions = testTemplate.Questions;
            //testViewModel.TestTemplateName = testTemplate.Name;
            //testViewModel.Score = 0;
            //ViewBag.Questions = testViewModel.Questions;
            //return View(testViewModel);
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult TakeTest(TestViewModel modelBinder)
        //{
        //    var questions = ViewBag.Questions;
        //    if (ModelState.IsValid)
        //    {
        //        var result = new StudentsTest();
        //        //result.TestTemplate.Name = testViewModel.TestTemplateName;
        //    }
        //    return RedirectToAction("IndexStudent", "TestTemplate");
        //}
    }
}
