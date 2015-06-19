using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolProject.Models
{
    public class Answer
    {
        /*
        public int AnswerID { get; set; }
        public string AnswerText { get; set; }
        public bool IsCorrect { get; set; }
        public int QuestionID { get; set; }
        public virtual Question Question { get; set; }
        */
        public int AnswerID { get; set; }
        [Required]
        [Display(Name = "Answer Text")]
        [StringLength(150)]
        public string AnswerText { get; set; }        
        [Display(Name = "Is Correct")]
        public bool IsCorrect { get; set; }
        public bool AnsweredByStudent { get; set; }
        public int QuestionID { get; set; }
        public virtual Question Question { get; set; }


    }
}