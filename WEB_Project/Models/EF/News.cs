using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;


namespace WEB_Project.Models.EF
{
    [Table("News")]
    public class News : CommonAbstract
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.None)]
        public int NewId { get; set; }
        [Required(ErrorMessage = "Bạn không để trống tiêu đề tin")] 
        [StringLength(150)]
        public string Title { get; set; }
        [StringLength(250)]
        public string Alias { get; set; }
       
        public string Description { get; set; }
        [AllowHtml]
        public string Detail { get; set; }
        [StringLength(250)]
        public string Image { get; set; }
        public int CategoryId { get; set; }
 
        public bool IsActive { get; set; }
        public virtual Category Category  { get; set; }
    }
}