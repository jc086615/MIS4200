﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarrMIS4200.Models
{
    public class Appointment
    {
        
        public int appointmentId { get; set; }

        [Display(Name = "Appointment Date")]
        public DateTime appointmentDate { get; set; }

       
        public int doctorId { get; set; }

        public virtual Doctor Doctor { get; set; }

       
        public int patientId { get; set; }

        public virtual Patient Patient { get; set; }
    }
}