using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using SchoolProject.Models;

namespace SchoolProject.Models
{
    public class Student : ApplicationUser
    {
        public virtual List<StudentGroup> StudentGroups { get; set; }
        public virtual List<StudentsTest> StudentsTests { get; set; }

        [Display(Name = "Full Name")]
        public string FullName
        {
            get { return SureName + " " + FirstName; }
        }
    }
}