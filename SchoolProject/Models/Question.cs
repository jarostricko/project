using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolProject.Models
{
    public class Question
    {
        public int QuestionID { get; set; }
        public string Text { get; set; }
        public IEnumerable<string> AnswersList { get; set; }
        public IEnumerable<string> CorrectAnswersList { get; set; }
        public int Points { get; set; }
        public string Explanation { get; set; }
        public int ThematicFieldID { get; set; }
        public virtual ThematicField ThematicField { get; set; }
    }
}