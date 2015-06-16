using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolProject.Models
{
    public class TestTemplate
    {
        /*
        public int TestTemplateID { get; set; }
        public string Name { get; set; }
        [DataType(DataType.Time)]
        public TimeSpan Time { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int QuestionCount { get; set; }
        public int StudentGroupID { get; set; }
        public virtual StudentGroup StudentGroup { get; set; }
        public virtual List<Question> Questions { get; set; }
        public virtual List<ThematicField> ThematicFields { get; set; }
        */
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
        

    }
}