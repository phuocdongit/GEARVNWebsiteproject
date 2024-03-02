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
    public class ProductImagesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/ProductImages
        public ActionResult Index(int id)
        {
            ViewBag.ProductId = id;
            var items = db.ProductImages.Where(x => x.ProductId == id).ToList();
            return View(items);
        }
        [HttpPost]

        public ActionResult AddImage(int productId, string url)
        {
            // Lấy số lượng ảnh hiện tại của mặt hàng
            int currentImageCount = db.ProductImages.Count(pi => pi.ProductId == productId);
            // Tính toán ProductImageId
            int imageNumber = currentImageCount + 1;
            int productImageId;
            do
            {
                productImageId = int.Parse($"{productId}{imageNumber}");

                // Kiểm tra xem ProductImageId đã tồn tại chưa
                if (db.ProductImages.Any(pi => pi.ProductImageId == productImageId))
                {
                    imageNumber++;
                }
                else
                {
                    break; // Khi tìm được một ProductImageId chưa tồn tại, thoát khỏi vòng lặp
                }
            } while (true);

            // Thêm ProductImage vào cơ sở dữ liệu
            db.ProductImages.Add(new ProductImage
            {
                ProductId = productId,
                ProductImageId = productImageId,
                Image = url,
                IsDefault = false
            });
            db.SaveChanges();
            return Json(new { Success = true, Message = "Thêm ảnh thành công." });
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item = db.ProductImages.Find(id);
            db.ProductImages.Remove(item);
            db.SaveChanges();
            return Json(new { success = true });
        }
    }
}