using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WEB_Project.Models.EF
{
    [Table("Orders")]
    public class Order 
    {
        public Order()
        {
            this.OrderDetails = new HashSet<OrderDetail>();
        }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.None)]
        public int OrderID { get; set; }
        [Required]
        [StringLength(15)]
        public string LadingCode { get; set; }
        //[Required]
        //public string CustomerName { get; set; }
        [Required]
        [StringLength(15)]
        public string Phone { get; set; }
        [Required]
        [StringLength(100)]
        public string Address { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        public decimal TotalAmount { get; set; }
        //public int Quantity { get; set; }
        public DateTime CreatedDate { get; set; }
        public int StatusPayment { get; set; }
        [ForeignKey("Customer")]
        [StringLength(10)]
        public string CustomerID { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}