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
    [Authorize(Roles = "admin, employee")]
    public class CustomerController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/Customer
        public ActionResult Index(string Searchtext, int? page)
        {
            var pageSize = 10;
            if (page == null)
            {
                page = 1;
            }
            CustomerList cusList = new CustomerList();
            List<Customer> obj = cusList.getCustomer(string.Empty).OrderBy(x => x.CustomerID).ToList();
            if (!string.IsNullOrEmpty(Searchtext))
            {
                // Thực hiện lọc trên List đã lấy được từ cơ sở dữ liệu
                obj = obj.Where(x => x.CustomerName.Contains(Searchtext) || x.Phone.Contains(Searchtext)).ToList();
            }
            var pagedListItems = obj.ToPagedList(page.Value, pageSize);
            ViewBag.PageSize = pageSize;
            ViewBag.Page = page;
            return View(pagedListItems);

        }

        public ActionResult ViewCustomer(string id = "")
        {
            CustomerList cusList = new CustomerList();
            List<Customer> obj = cusList.getCustomer(id);
            // Truy xuất số lượng hóa đơn từ phương thức mới và truyền vào ViewBag
            int numberOfInvoices = cusList.GetNumberOfInvoices(id);
            ViewBag.NumberOfInvoices = numberOfInvoices;
            return View(obj.FirstOrDefault());
        }
        public ActionResult Delete(string id = "")
        {
            CustomerList cusList = new CustomerList();
            List<Customer> obj = cusList.getCustomer(id);
            return View(obj.FirstOrDefault());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Customer model)
        {

            CustomerList cusList = new CustomerList();
            cusList.DeleteCustomer(model);

            return RedirectToAction("Index");

        }
    }
}