using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarrMIS4200.Models
{
    public class Doctor
    {
        public int doctorId { get; set; }

        [Required(ErrorMessage = "Doctor's first name is required")]
        [Display(Name = "Last Name")]
        [StringLength(20)]
        public string docLastName { get; set; }

        [Required(ErrorMessage = "Doctor's last name is required")]
        [Display(Name = "First Name")]
        [StringLength(20)]
        public string docFirstName { get; set; }

        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^(\+\d{1,2}\s)?\(?\d{3}\)?[\s.-]\d{3}[\s.-]\d{4}$",
           ErrorMessage = "Must be correctely formated number ex:xxx-xxx-xxxx")]
        public string docPhone { get; set; }
        public ICollection<Appointment> Appointment { get; set; }
    }
}