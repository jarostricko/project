namespace SchoolProject.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Collections.Generic;
    using SchoolProject.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<SchoolProject.DAL.SchoolProjectContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "SchoolProject.DAL.SchoolProjectContext";
        }

        protected override void Seed(SchoolProject.DAL.SchoolProjectContext context)
        {
            //STUDENTS
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
            students.ForEach(s => context.Students.AddOrUpdate(p => p.SureName, s));
            context.SaveChanges();

            //TEACHERS
            var teachers = new List<Teacher>
            {
                new Teacher {FirstName = "Teacher1", SureName = "Alex", BirthDate = DateTime.Parse("1985-09-01")},
                new Teacher {FirstName = "Teacher2", SureName = "Ali", BirthDate = DateTime.Parse("1986-09-01")},
                new Teacher {FirstName = "Teacher3", SureName = "Anand", BirthDate = DateTime.Parse("1958-09-01")},
                new Teacher {FirstName = "Teacher4", SureName = "Barnat", BirthDate = DateTime.Parse("1880-09-01")},
                new Teacher {FirstName = "Teacher5", SureName = "Liaglo", BirthDate = DateTime.Parse("1991-09-01")}
            };
            teachers.ForEach(s => context.Teachers.AddOrUpdate(p => p.SureName, s));
            context.SaveChanges();

            //THEMATIC FIELDS
            var fields = new List<ThematicField>
            {
                new ThematicField {Title = "Biology"},
                new ThematicField {Title = "Geography"},
                new ThematicField {Title = "History"}
            };
            fields.ForEach(s => context.ThematicFields.AddOrUpdate(p => p.Title, s));
            context.SaveChanges();

            //STUDENT GROUPS
            var studentGroups = new List<StudentGroup>
            {
                new StudentGroup {Title = "Group with Studs", Students = new List<Student>
                {students.Single(s => s.SureName == "Alexander"),students.Single(s => s.SureName == "Li")}},
                new StudentGroup {Title = "Group without Studs", Students = null}
            };
            studentGroups.ForEach(s => context.StudentGroups.AddOrUpdate(p => p.Title, s));
            context.SaveChanges();

            //QUESTIONS
            var questions = new List<Question>
            {
                new Question
                {
                    Text = "Kolko noh ma pavuk?",
                    Explanation = "Pavuk ma 8 noh lebo je mimozemstan",
                    Points = 5,
                    ThematicFieldID = 1
                },
                new Question
                {
                    Text = "Kde je Slovensko?",
                    Explanation = "Slovensko je v Europe",
                    Points = 3,
                    ThematicFieldID = 2
                }
            };
            questions.ForEach(q => context.Questions.AddOrUpdate(a => a.Text,q));
            context.SaveChanges();

            //ANSWERS
            var answers1 = new List<Answer>
            {
                new Answer{AnswerText = "1",Question = questions.Single(q => q.Text == "Kolko noh ma pavuk?")},
                new Answer{AnswerText = "2",Question = questions.Single(q => q.Text == "Kolko noh ma pavuk?")},
                new Answer{AnswerText = "6",Question = questions.Single(q => q.Text == "Kolko noh ma pavuk?")},
                new Answer{AnswerText = "8",IsCorrect = true,Question = questions.Single(q => q.Text == "Kolko noh ma pavuk?")}
            };
            var answers2 = new List<Answer>
            {
                new Answer{AnswerText = "V Europe",IsCorrect = true,Question = questions.Single(q => q.Text == "Kde je Slovensko?")},
                new Answer{AnswerText = "V Azii",Question = questions.Single(q => q.Text == "Kde je Slovensko?")},
                new Answer{AnswerText = "Vo Vesmire",Question = questions.Single(q => q.Text == "Kde je Slovensko?")},
                new Answer{AnswerText = "V Amerike",Question = questions.Single(q => q.Text == "Kde je Slovensko?")}
            };
            answers1.ForEach(a => context.Answers.AddOrUpdate(p => p.AnswerText, a));
            answers2.ForEach(a => context.Answers.AddOrUpdate(p => p.AnswerText, a));
            context.SaveChanges();

            //TEST TEMPLATES
            var testTemplates = new List<TestTemplate>
            {
                new TestTemplate
                {
                    Name = "Test",
                    QuestionCount = 1,
                    EndTime = new DateTime(2018, 4, 10),
                    StartTime = new DateTime(1984, 4, 10),
                    StudentGroupID = studentGroups.Single(s=>s.Title == "Group with Studs").StudentGroupID,
                    Questions = null,
                    Time = new TimeSpan(0,5,0)
                },
                new TestTemplate
                {
                    Name = "Test2",
                    QuestionCount = 1,
                    EndTime = new DateTime(2017, 5, 11),
                    StartTime = new DateTime(1999, 4, 10),
                    StudentGroupID = studentGroups.Single(s=>s.Title == "Group without Studs").StudentGroupID,
                    Questions = null,
                    Time = new TimeSpan(0,5,0)
                }
            };
            testTemplates.ForEach(t => context.TestTemplates.AddOrUpdate(s => s.Name,t));
            context.SaveChanges();
        }
    }
}
