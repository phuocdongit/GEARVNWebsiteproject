using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WEB_Project.Models;
using System.Web.Mvc;

namespace WEB_Project.Controllers
{
    public class ArticleController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Article
        public ActionResult Index(string alias)
        {
            var item = db.Posts.FirstOrDefault(x => x.Alias == alias);
            return View(item);
        }
    }
}