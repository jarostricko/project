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
        
    }
}