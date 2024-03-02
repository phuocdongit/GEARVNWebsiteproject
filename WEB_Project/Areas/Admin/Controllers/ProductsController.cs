using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEB_Project.Models;
using WEB_Project.Models.EF;

namespace WEB_Project.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin, employee")]
    public class ProductsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/Products
        public ActionResult Index(string Searchtext, int? page)
        {
            var pageSize = 10;
            if (page == null)
            {
                page = 1;
            }

            IEnumerable<Product> items = db.Products.OrderByDescending(x => x.CreatedDate);
            if (!string.IsNullOrEmpty(Searchtext))
            {
                items = items.Where(x => x.ProductCategory1.ProductCategoryName.ToLower().Contains(Searchtext.ToLower()) || x.ProductName.ToLower().Contains(Searchtext.ToLower())
                );
            }

            var pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            items = items.ToPagedList(pageIndex, pageSize);
            ViewBag.PageSize = pageSize;
            ViewBag.Page = page;
            return View(items);
        }

        public ActionResult Add()
        {
            ViewBag.Provider = new SelectList(db.Providers.ToList(), "ProID", "ProName");
            ViewBag.ProductCategory = new SelectList(db.ProductCategories.ToList(), "ProductCategoryID", "ProductCategoryName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Product model, List<string> Images, List<int> rDefault)
        {
            if (ModelState.IsValid)
            {
                if (Images != null && Images.Count > 0)
                {
                    for (int i = 0; i < Images.Count; i++)
                    {
                        int imageNumber = i + 1;
                        int productImageId = int.Parse($"{model.ProductID}{imageNumber}");

                        if (i + 1 == rDefault[0])
                        {
                            model.Avatar = Images[i];
                            model.ProductImage.Add(new ProductImage
                            {
                                ProductId = model.ProductID,
                                ProductImageId = productImageId,
                                Image = Images[i],
                                IsDefault = true
                            });
                        }
                        else
                        {
                            model.ProductImage.Add(new ProductImage
                            {
                                ProductId = model.ProductID,
                                ProductImageId = productImageId,
                                Image = Images[i],
                                IsDefault = false
                            });
                        }
                    }
                }
                // Thêm mặt hàng vào cơ sở dữ liệu
                model.CreatedDate = DateTime.Now;
                if (string.IsNullOrEmpty(model.Alias))
                    model.Alias = WEB_Project.Models.Common.Filter.FilterChar(model.ProductName);
                db.Products.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Provider = new SelectList(db.Providers.ToList(), "ProID", "ProName");
            ViewBag.ProductCategory = new SelectList(db.ProductCategories.ToList(), "ProductCategoryID", "ProductCategoryName");
            return View(model);
        }

        //BÀI 9 27:05
        public ActionResult Edit(int id)
        {
            ViewBag.Provider = new SelectList(db.Providers.ToList(), "ProID", "ProName");
            ViewBag.ProductCategory = new SelectList(db.ProductCategories.ToList(), "ProductCategoryID", "ProductCategoryName");
            var item = db.Products.Find(id);
            return View(item);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(Product model)
        {
            if (ModelState.IsValid)
            {
                //model.ModifiedDate = DateTime.Now;
                model.Alias = WEB_Project.Models.Common.Filter.FilterChar(model.ProductName);
                db.Products.Attach(model);
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item = db.Products.Find(id);
            if (item != null)
            {
                db.Products.Remove(item);
                db.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }

        [HttpPost]
        public ActionResult IsActive(int id)
        {
            var item = db.Products.Find(id);
            if (item != null)
            {
                item.IsActive = !item.IsActive;
                db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return Json(new { success = true, isAcive = item.IsActive });
            }

            return Json(new { success = false });
        }
        [HttpPost]
        public ActionResult IsHome(int id)
        {
            var item = db.Products.Find(id);
            if (item != null)
            {
                item.IsHome = !item.IsHome;
                db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return Json(new { success = true, IsHome = item.IsHome });
            }

            return Json(new { success = false });
        }

        [HttpPost]
        public ActionResult IsSale(int id)
        {
            var item = db.Products.Find(id);
            if (item != null)
            {
                item.IsSale = !item.IsSale;
                db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return Json(new { success = true, IsSale = item.IsSale });
            }

            return Json(new { success = false });
        }
    }
}