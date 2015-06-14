using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolProject.Models
{
    public class Answer
    {
        public int AnswerID { get; set; }
        public string AnswerText { get; set; }
        public bool IsCorrect { get; set; }
        public int QuestionID { get; set; }
        public virtual Question Question { get; set; }


    }
}