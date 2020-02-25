using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarrMIS4200.Models
{
    public class Patient
    {
        public int patientId { get; set; }

        [Display(Name = "Patient Full Name")]
        public string fullName { get { return patientLastName + ", " + patientFirstName; } }

        [Required(ErrorMessage = "Patients last name is required")]
        [Display(Name = "Last Name")]
        [StringLength(20)]
        public string patientLastName { get; set; }

        [Required(ErrorMessage = "Patients first name is required")]
        [Display(Name = "First Name")]
        [StringLength(20)]
        public string patientFirstName { get; set; }

        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^(\+\d{1,2}\s)?\(?\d{3}\)?[\s.-]\d{3}[\s.-]\d{4}$",
            ErrorMessage ="Must be correctely formated number ex:xxx-xxx-xxxx")]

        public string patientPhone { get; set; }
        

        
        [Display(Name = "Current Email Address")]
        [StringLength(50)]
        [EmailAddress(ErrorMessage ="Enter your most frequently used email address")]
        public string Email { get; set; }

        [Display(Name = "Current Office for Appointments")]
        public string Office { get; set; }

       
        




        public ICollection<Appointment> Appointment { get; set; }
    }
}