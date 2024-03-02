using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEB_Project.Models;


namespace WEB_Project.Areas.Admin.Controllers
{
    public class ThongKeController : Controller
    {
        // GET: Admin/ThongKeDT
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            return View();
        }
        
        [HttpGet]
        public ActionResult GetStatistical(string fromDate, string toDate)
        {
            DateTime currentDate = DateTime.Now;

            // Đặt ngày bắt đầu là 30 ngày trước ngày hiện tại
            DateTime startDate = currentDate.AddDays(-30);

            var query = from o in db.Orders
                        join od in db.OrderDetails on o.OrderID equals od.OrderId
                        join p in db.Products on od.ProductId equals p.ProductID
                        where o.CreatedDate >= startDate // Lọc theo ngày bắt đầu
                        select new
                        {
                            CreatedDate = o.CreatedDate,
                            Quantity = od.Quantity,
                            Price = od.Price,
                            OriginalPrice = p.OriginalPrice
                        };

            if (!string.IsNullOrEmpty(toDate))
            {
                DateTime endDate = DateTime.ParseExact(toDate, "dd/MM/yyyy", null);
                query = query.Where(x => x.CreatedDate < endDate);
            }

            var result = query.GroupBy(x => DbFunctions.TruncateTime(x.CreatedDate)).Select(x => new
            {
                Date = x.Key.Value,
                TotalBuy = x.Sum(y => y.Quantity * y.OriginalPrice),
                TotalSell = x.Sum(y => y.Quantity * y.Price),
            }).Select(x => new
            {
                Date = x.Date,
                DoanhThu = x.TotalSell,
                LoiNhuan = x.TotalSell - x.TotalBuy
            });

            return Json(new { Data = result }, JsonRequestBehavior.AllowGet);
            
        }

    }
}