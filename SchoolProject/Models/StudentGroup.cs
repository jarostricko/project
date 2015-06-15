using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolProject.Models
{
    public class StudentGroup
    {
        public int StudentGroupID { get; set; }
        [Required]
        [Display(Name = "Group Title")]
        [StringLength(50)]
        public string Title { get; set; }
        public virtual List<Student> Students { get; set; }


    }
}