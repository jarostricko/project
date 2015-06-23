using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using SchoolProject.Models;

namespace SchoolProject.ViewModels
{
    public class TestViewModel
    {
        [Key]
        public int TestViewModelID { get; set; }
        public string TestTemplateName { get; set; }
        public int Score { get; set; }
        public virtual List<Question> Questions { get; set; }
        //public virtual List<Answer> Answers { get; set; }
 

        public TestViewModel(List<Question> questions)
        {
            Questions = questions;
        }

        public TestViewModel()
        {
        }
        public void CountScore()
        {
            int score = 0;
            bool correctFlag = false;
            foreach (var question in this.Questions)
            {
                correctFlag = false;
                foreach (var answer in question.AnswersList)
                {
                    if (answer.AnsweredByStudent && answer.IsCorrect)
                    {
                        correctFlag = true;
                    }
                    score += question.Points;
                }
            }
            this.Score = score;

        }
    }
}