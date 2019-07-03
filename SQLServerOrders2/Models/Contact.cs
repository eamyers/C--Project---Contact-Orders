using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SQLServerOrders2.Models
{
    public class Contact
    {

        public Contact()
        {
            CreatedDate = DateTime.Now;
        }
     

        public int ContactId { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Full Name")]
        public string FullName => FirstName + " " + LastName;

        [Column(TypeName = "DateTime2")]
        [Display(Name = "Birthday!")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yy}")]
        public DateTime DateOfBirth { get; set; }
        [Display(Name = "Can contact by phone?")]
        public bool AllowContactByPhone { get; set; }
        [Column(TypeName = "DateTime2")]
        public DateTime CreatedDate { get; set; }

        public string Role { get; set; }
        public virtual ICollection<Order> Orders { get; set; }


        public string GetFullName()
        {
            return this.FirstName + " " + this.LastName;
        }

    }
}