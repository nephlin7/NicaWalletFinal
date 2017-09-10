using NicaWallet.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace NicaWallet.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private ApplicationDbContext dbContext = new ApplicationDbContext();
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var account = dbContext.Account.Where(x => x.UserId == userId);
            ViewBag.accounts = dbContext.Account
                                   .Include(a => a.AccountType)
                                   .Include(a => a.Currency)
                                   .Where(x => x.UserId.Equals(userId))
                                   .Take(3)
                                   .ToList();
            //ViewBag.records = dbContext.Record.Include(r => r.Account)
            //                  .Include(r => r.Category)
            //                  .Include(r => r.Currency)
            //                  .Join(r in dbCon)
            //                  .Take(10)
            //                  .ToList();
            var record = (from r in dbContext.Record
                          join a in account on r.AccountId equals a.AccountId
                          join c in dbContext.Category on r.CategoryId equals c.CategoryId
                         join cr in dbContext.Currency on r.CurrencyId equals cr.CurrencyId
                         select r).Take(10).ToList();
            ViewBag.records = record;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}