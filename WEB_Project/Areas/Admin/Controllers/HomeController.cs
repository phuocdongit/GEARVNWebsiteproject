using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEB_Project.Models;

namespace WEB_Project.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin, employee")]
    public class HomeController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/Home
        public ActionResult Index()
        {
            int productCount = db.Products.Count();
            int customerCount = db.Customers.Count();
            int orderCount = db.Orders.Count();
            int providerCount = db.Providers.Count();
            var recentOrders = db.Orders.OrderByDescending(o => o.CreatedDate).Take(5).ToList();

            // Truyền dữ liệu đến view
            ViewBag.ProductCount = productCount;
            ViewBag.CustomerCount = customerCount;
            ViewBag.OrderCount = orderCount;
            ViewBag.ProviderCount = providerCount;
            ViewBag.RecentOrders = recentOrders;

            // Truyền giá trị đến view
          



            return View();
        }

        


    }
}