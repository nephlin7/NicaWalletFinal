using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NicaWallet.Models;
using System.Data.Entity;
using Microsoft.AspNet.Identity;

namespace NicaWallet.Controllers
{
    [Authorize]
    public class CategoriesController : Controller
    {
        private ApplicationDbContext dbContext = new ApplicationDbContext();
        //GET: Admin
        public ActionResult Index()
        {
            string userId = User.Identity.GetUserId();
            var listCategory = dbContext.Category.Where(x => x.UserId == null || x.UserId == userId).ToList();
            return View(listCategory);
        }

        [HttpPost]
        public ActionResult CreateCategory(Category c)
        {
            string userId = User.Identity.GetUserId();
            var cat = new Category
            {
                CategoryName = c.CategoryName,
                ParentId = c.ParentId,
                IsParent = (c.ParentId != null ? false : true),
                UserId = userId
            };
            dbContext.Category.Add(cat);
            dbContext.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult UpdateCategory(int categoryId)
        {
            var Category = dbContext.Category.Where(x => x.CategoryId == categoryId).FirstOrDefault();
            if (Category != null)
            {
                dbContext.Entry(Category).State = EntityState.Modified;
                dbContext.SaveChanges();
                return Json(new { ResponseCode = "200" });
            }
            else
            {
                return Json(new { ResponseCode = "203" });
            }
            //User.Identity.AuthenticationType
        }
        [HttpPost]
        public ActionResult DeleteCategory(int categoryId)
        {
            var ifHasChild = dbContext.Category.Where(x => x.ParentId == categoryId).Count();
            var Category = dbContext.Category.Where(x => x.CategoryId == categoryId).FirstOrDefault();

            if (Category != null)
            {
                if (Category.IsParent == true && ifHasChild > 0)
                {
                    return Json(new { ResponseCode = "203" });
                }
                else
                {
                    dbContext.Category.Remove(Category);
                    dbContext.SaveChanges();
                    return Json(new { ResponseCode = "200" });
                }
            }
            else
                return Json(new { ResponseCode = "203" });
        }
    }
}