using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolProject.Models
{
    public class Question
    {
        public int QuestionID { get; set; }
        [Required]
        [Display(Name = "Question Text")]
        [StringLength(250)]
        public string Text { get; set; }
        public virtual List<Answer> AnswersList { get; set; }
        public int Points { get; set; }
        //[Required]
        [StringLength(150)]
        public string Explanation { get; set; }
        [Required]
        public int ThematicFieldID { get; set; }
        public virtual List<TestTemplate> TestTemplates { get; set; }
        public virtual ThematicField ThematicField { get; set; }
    }
}