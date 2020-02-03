using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarrMIS4200.Models
{
    public class customer
    {
        public int customerID { get; set; }
        public string customerLastName { get; set; }

        public string customerFirstName { get; set; }

        public string email { get; set; }

        public string phone { get; set; }

        public DateTime customerSince { get; set; }

        public string fullName { get { return customerLastName + "," + customerFirstName; } }
    }
   

}