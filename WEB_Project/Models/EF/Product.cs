using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WEB_Project.Models.EF
{
    [Table("Product")]
    public class Product : CommonAbstract
    {
        public Product()
        {
            this.ProductImage = new HashSet<ProductImage>();
            this.OrderDetails = new HashSet<OrderDetail>();
        }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.None)]
        public int ProductID { get; set; }
        [StringLength(250)]

        public string Alias { get; set; }

        [Required]
        [StringLength(250)]

        public string ProductName { get; set; }
        [AllowHtml]
        public string Description { get; set; }
        [AllowHtml]

        public string Detail { get; set; }
        [StringLength(250)]

        //Sua lai thanh avt
        public string Avatar { get; set; }
        public decimal OriginalPrice { get; set; }
        public decimal Price { get; set; }
        public decimal? PriceSale { get; set; }
        public int Quantity { get; set; }
        public int ViewCount { get; set; }
        public bool IsHome { get; set; }
        public bool IsSale { get; set; }
        public bool IsFeature { get; set; }
        public bool IsHot { get; set; }
        public bool IsActive { get; set; }
        [ForeignKey("ProductCategory1")]
        public int ProductCategoryId { get; set; }

        [ForeignKey("Provider")]
        public int ProviderID { get; set; }
        public virtual Provider Provider { get; set; }
        public virtual ProductCategory ProductCategory1 { get; set; }
        public virtual ICollection<ProductImage> ProductImage { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }


    }
}