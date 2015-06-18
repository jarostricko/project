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

        //public int ID { get; set; }
        //[Required]
        //[Display(Name = "Last Name")]
        //[StringLength(50, ErrorMessage = "Last name cannot be longer than 50 characters.")]
        //public string SureName { get; set; }
        //[Required]
        //[Display(Name = "First Name")]
        //[StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        //public string FirstName { get; set; }
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //[Display(Name = "Birth Date")]
        //public DateTime BirthDate { get; set; }
        public virtual List<StudentGroup> StudentGroups { get; set; }

        [Display(Name = "Full Name")]
        public string FullName
        {
            get { return SureName + " " + FirstName; }
        }
    }
}