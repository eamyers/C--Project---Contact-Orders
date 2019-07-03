using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SQLServerOrders2.Models
{
    public class Order
    {
       
      public Order()
        {
            OrderDate = DateTime.Now;
        }
      
        public int OrderId { get; set; }
        [Required]
        public int ContactId { get; set; }
        [Required]
        [Column(TypeName = "DateTime2")]
        [Display(Name = "Order Date")]
        [DisplayFormat( DataFormatString = "{0:MM/dd/yy}")]
        public DateTime OrderDate { get; set; }
        [Required]
        [MaxLength(500, ErrorMessage ="Description has to be less than 500 long")]
        [Display(Name = "Order Description")]
        public string OrderDescription { get; set; }
        [Required]
        [Display(Name = "Order Amount")]
        public decimal OrderAmount { get; set; }

        public virtual Contact Contact { get; set; }

        internal object Include()
        {
            throw new NotImplementedException();
        }
    }
}