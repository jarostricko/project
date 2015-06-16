using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SchoolProject.Models;

namespace SchoolProject.ViewModels
{
    public class StudentGroupIndexData
    {
        public IEnumerable<StudentGroup> StudentGroups { get; set; }
        public IEnumerable<Student> Students { get; set; }
    }
}