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
        public string StudentID { get; set; }
        public virtual Student Student { get; set; }
        public float Points { get; set; }
        public virtual TestTemplate TestTemplate { get; set; }
        public virtual List<StudentAnswer> StudentAnswers { get; set; }

        
    }




}