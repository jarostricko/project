using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolProject.Models
{
    public class Student
    {
        public int ID { get; set; }
        public string SureName { get; set; }
        public string FirstName { get; set; }
        public DateTime BirthDate { get; set; }
        public virtual List<StudentGroup> StudentGroups { get; set; } 


    }
}