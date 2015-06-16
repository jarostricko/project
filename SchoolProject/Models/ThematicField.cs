using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace SchoolProject.Models
{
    public class ThematicField
    {
        /*
        public int ThematicFieldID { get; set; }
        public string Title { get; set; }
        public virtual List<TestTemplate> TestTemplates { get; set; }
        */
        public int ThematicFieldID { get; set; }
        [Required]
        [Display(Name = "Thematic Field Title")]
        [StringLength(50)]
        public string Title { get; set; }
        public virtual List<TestTemplate> TestTemplates { get; set; }
    }
}
