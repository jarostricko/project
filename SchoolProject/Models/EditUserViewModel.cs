using System;
using System.ComponentModel.DataAnnotations;

namespace SchoolProject.Models
{
    public class EditUserViewModel
    {
        public EditUserViewModel() { }

        // Allow Initialization with an instance of ApplicationUser:
        public EditUserViewModel(ApplicationUser user)
        {
            //this.Id = System.Convert.ToInt32(user.Id);
            UserName = user.UserName;
            Email = user.Email;
            FirstName = user.FirstName;
            SureName = user.SureName;
            BirthDate = user.BirthDate;
        }

        public int Id { get; set; }

        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }


        [Required]
        public string Email { get; set; }

        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Display(Name = "Last name")]
        public string SureName { get; set; }

        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
    }
}