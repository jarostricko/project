using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolProject.Models
{
    public class StudentsTest
    {
        [Key]
        public int StudentTestID { get; set; }
        public int StudentID { get; set; }
        public virtual Student Student { get; set; }
        public int Points { get; set; }
        public virtual TestTemplate TestTemplate { get; set; }
        public virtual List<StudentAnswer> StudentAnswers { get; set; }

        public void CountPoints()
        {
            Points = 0;
            foreach (var studentAnswer in StudentAnswers)
            {
                if (studentAnswer.IsChecked || studentAnswer.Answer.IsCorrect)
                {
                    Points += studentAnswer.Answer.Question.Points;
                }
            }
        }
    }




}