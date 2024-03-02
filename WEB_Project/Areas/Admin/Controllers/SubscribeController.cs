using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEB_Project.Models;
using PagedList;
using System.Globalization;
using System.Data.Entity;
using WEB_Project.Models.ViewModels;
using WEB_Project.Models.EF;

namespace WEB_Project.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin, employee")]
    public class SubscribeController : Controller
    {
        // GET: Admin/Subscribe
        private ApplicationDbContext db = new ApplicationDbContext();
     
        public ActionResult Index(int? page, int? status)
        {
            IQueryable<WEB_Project.Models.EF.Subscribe> items = db.Subscribes.OrderByDescending(x => x.CreatedDate);

            if (page == null)
            {
                page = 1;
            }
            var pageNumber = page ?? 1;
            var pageSize = 10;
            ViewBag.PageSize = pageSize;
            ViewBag.Page = pageNumber;
            return View(items.ToPagedList(pageNumber, pageSize));

        }
    }
}