using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolProject.Models
{
    public class TestTemplate
    {
        public int TestTemplateID { get; set; }
        public string Name { get; set; }
        public DateTime Time { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int QuestionCount { get; set; }
        public int StudentGroupID { get; set; }
        public virtual StudentGroup StudentGroup { get; set; }
        public virtual IEnumerable<Question> Questions { get; set; }
        public virtual IEnumerable<ThematicField> ThematicFields { get; set; }
        

    }
}