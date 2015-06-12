using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using SchoolProject.Models;

namespace SchoolProject.DAL
{
    public class SchoolProjectInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<SchoolProjectContext>
    {
        protected override void Seed(SchoolProjectContext context)
        {
            var students = new List<Student>
            {
                new Student {FirstName = "Carson", SureName = "Alexander", BirthDate = DateTime.Parse("2005-09-01")},
                new Student {FirstName = "Meredith", SureName = "Alonso", BirthDate = DateTime.Parse("2002-09-01")},
                new Student {FirstName = "Arturo", SureName = "Anand", BirthDate = DateTime.Parse("2003-09-01")},
                new Student {FirstName = "Gytis", SureName = "Barzdukas", BirthDate = DateTime.Parse("2002-09-01")},
                new Student {FirstName = "Yan", SureName = "Li", BirthDate = DateTime.Parse("2002-09-01")},
                new Student {FirstName = "Peggy", SureName = "Justice", BirthDate = DateTime.Parse("2001-09-01")},
                new Student {FirstName = "Laura", SureName = "Norman", BirthDate = DateTime.Parse("2003-09-01")},
                new Student {FirstName = "Nino", SureName = "Olivetto", BirthDate = DateTime.Parse("2005-09-01")}
            };
            students.ForEach(s => context.Students.Add(s));
            context.SaveChanges();

            var teachers = new List<Teacher>
            {
                new Teacher {FirstName = "Teacher1", SureName = "Alex", BirthDate = DateTime.Parse("1985-09-01")},
                new Teacher {FirstName = "Teacher2", SureName = "Ali", BirthDate = DateTime.Parse("1986-09-01")},
                new Teacher {FirstName = "Teacher3", SureName = "Anand", BirthDate = DateTime.Parse("1958-09-01")},
                new Teacher {FirstName = "Teacher4", SureName = "Barnat", BirthDate = DateTime.Parse("1880-09-01")},
                new Teacher {FirstName = "Teacher5", SureName = "Liaglo", BirthDate = DateTime.Parse("1991-09-01")}
            };
            teachers.ForEach(s => context.Teachers.Add(s));
            context.SaveChanges();

            var fields = new List<ThematicField>
            {
                new ThematicField {Title = "Biology"},
                new ThematicField {Title = "Geography"},
                new ThematicField {Title = "History"}
            };
            fields.ForEach(f => context.ThematicFields.Add(f));
            context.SaveChanges();

            var studentGroups = new List<StudentGroup>
            {
                new StudentGroup {Title = "Group A", Students = new List<Student> {students.First(), students.Last()}},
                new StudentGroup {Title = "Group B"}
            };
            studentGroups.ForEach(s => context.StudentGroups.Add(s));
            context.SaveChanges();

            var questions = new List<Question>
            {
                new Question
                {
                    Text = "Kolko noh ma pavuk?",
                    AnswersList = new List<string> {"1", "2", "6", "8"},
                    CorrectAnswersList = new List<string> {"8"},
                    Explanation = "Pavuk ma 8 noh lebo je mimozemstan",
                    Points = 5,
                    ThematicFieldID = 1
                },
                new Question
                {
                    Text = "Kde je Slovensko?",
                    AnswersList = new List<string> {"V Europe", "V Azii", "Vo vesmire", "V amerike"},
                    CorrectAnswersList = new List<string> {"V Europe"},
                    Explanation = "Slovensko je v Europe",
                    Points = 3,
                    ThematicFieldID = 2
                }
            };
            questions.ForEach(q => context.Questions.Add(q));
            context.SaveChanges();

            var testTemplates = new List<TestTemplate>
            {
                new TestTemplate
                {
                    Name = "Test",
                    QuestionCount = 1,
                    EndTime = new DateTime(2018, 4, 10),
                    StartTime = new DateTime(1984, 4, 10),
                    StudentGroupID = 1,
                    Questions = new List<Question> {questions.First()},
                    Time = new TimeSpan(0,5,0)
                },
                new TestTemplate
                {
                    Name = "Test2",
                    QuestionCount = 1,
                    EndTime = new DateTime(2017, 5, 11),
                    StartTime = new DateTime(1999, 4, 10),
                    StudentGroupID = 2,
                    Questions = new List<Question> {questions.Last()},
                    Time = new TimeSpan(0,5,0)
                }
            };
            testTemplates.ForEach(t => context.TestTemplates.Add(t));
            context.SaveChanges();
        }
    }
}