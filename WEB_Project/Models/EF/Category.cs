using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WEB_Project.Models.EF
{
    [Table("Category")]
    public class Category /*: CommonAbstract*/
    {
        public Category()
        {
            this.News = new HashSet<News>();
        }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.None)]
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Tên danh mục không được để trống!")]
        [StringLength(150)]
        public string Title { get; set; }
        [StringLength(200)]
        public string Alias { get; set; }
        [StringLength(250)]

        public string Link { get; set; }

        public bool IsActive { get; set; }

        public int Position { get; set; }
        public ICollection<News> News { get; set; }
        public ICollection<Posts> Posts { get; set; }
    }
}