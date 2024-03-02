using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEB_Project.Models;
using WEB_Project.Models.EF;
using PagedList;

namespace WEB_Project.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class ProviderController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/Provider
        public ActionResult Index(string Searchtext, int? page)
        {
            var pageSize = 10;
            if (page == null)
            {
                page = 1;
            }
            ProviderList proList = new ProviderList();
            List<Provider> obj = proList.getProvider(string.Empty).OrderBy(x => x.ProID).ToList();
            if (!string.IsNullOrEmpty(Searchtext))
            {
                // Thực hiện lọc trên List đã lấy được từ cơ sở dữ liệu
                obj = obj.Where(x => x.ProName.Contains(Searchtext) || x.Phone.Contains(Searchtext)).ToList();
            }
            var pagedListItems = obj.ToPagedList(page.Value, pageSize);
            ViewBag.PageSize = pageSize;
            ViewBag.Page = page;
            return View(pagedListItems);

        }

        // GET: NhaCungCaps/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Provider model)
        {
            if (ModelState.IsValid)
            {
                ProviderList proList = new ProviderList();
                proList.AddProvider(model);

                return RedirectToAction("Index");
            }

            return View(model);
        }


        public ActionResult Edit(int id = 0)
        {
            ProviderList proList = new ProviderList();
            List<Provider> obj = proList.getProvider(id.ToString()); 
            return View(obj.FirstOrDefault());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Provider model)
        {

            ProviderList proList = new ProviderList();
            proList.UpdateProvider(model);

            return RedirectToAction("Index");

        }
        public ActionResult Delete(string id = "")
        {
            ProviderList proList = new ProviderList();
            List<Provider> obj = proList.getProvider(id);
            return View(obj.FirstOrDefault());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Provider model)
        {

            ProviderList proList = new ProviderList();
            proList.DeleteProvider(model);

            return RedirectToAction("Index");

        }
    }
}
