using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolProject.Models
{
    public class TestTemplate
    {
        public int TestTemplateID { get; set; }
        [Required]
        [Display(Name = "Template Name")]
        [StringLength(50)]
        public string Name { get; set; }
        [DataType(DataType.Time)]
        public TimeSpan Time { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime StartTime { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime EndTime { get; set; }
        public int QuestionCount { get; set; }
        public int StudentGroupID { get; set; }
        public virtual StudentGroup StudentGroup { get; set; }
        public virtual List<Question> Questions { get; set; }
        public virtual List<ThematicField> ThematicFields { get; set; }
        
        //public List<Question> GetTestQuestions()
        //{
        //    List<Question> listOfAll = new List<Question>();
        //    List<Question> list = new List<Question>();
        //    Random rnd = new Random();
        //    foreach (var field in this.ThematicFields)
        //    {
        //        foreach (var question in field.Questions)
        //        {
        //            listOfAll.Add(question);
        //        }
        //    }
        //    int qustionNumber = listOfAll.Count;
        //    int number;
        //    if (listOfAll.Count < this.NumberOfQuestions)
        //    {
        //        return null;
        //    }
        //    for (int i = 0; i < this.NumberOfQuestions; i++)
        //    {
        //        number = rnd.Next(1, qustionNumber);
        //        while(list.Contains(listOfAll[number]))
        //        {
        //           number = rnd.Next(1, qustionNumber);
        //        }
        //        list.Add(listOfAll[number]);
        //    }
        //        return list;
        //}
    
    }
}