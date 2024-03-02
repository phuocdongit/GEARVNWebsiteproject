using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WEB_Project.Models.EF
{
    [Table("ProductCategory")]
    public class ProductCategory : CommonAbstract
    {
        public ProductCategory()
         {
            this.Products = new HashSet<Product>();
        }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.None)]
        public int ProductCategoryID { get; set; }
        [Required]
        [StringLength(150)]
        public string ProductCategoryName { get; set; }
        [Required]
        [StringLength(150)]
        public string Alias { get; set; }
        [StringLength(250)]
        public string HomeAvatar { get; set; }
        public ICollection<Product> Products { get; set; }

    }
}