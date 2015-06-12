using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolProject.Models
{
    public class StudentGroup
    {
        public int StudentGroupID { get; set; }
        public string Title { get; set; }
        public virtual IEnumerable<Student> Students { get; set; }

    }
}