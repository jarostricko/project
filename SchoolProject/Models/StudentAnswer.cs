using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchoolProject.Models
{
    public class StudentAnswer
    {
        public int StudentAnswerID { get; set; }
        public int AnswerID { get; set; }
        public Answer Answer { get; set; }
        public bool IsChecked { get; set; }
        public int StudentsTestID { get; set; }
        
        public virtual List<StudentsTest> StudentsTest { get; set; }
    }
}
