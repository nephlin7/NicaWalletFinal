using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NicaWallet.Models;
using Microsoft.AspNet.Identity;

namespace NicaWallet.Controllers
{
    [Authorize]
    public class RecordsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Records
        public ActionResult Index()
        {

            //var accountId = Convert.ToInt32(Request.QueryString["accountId"]);
            string userId = User.Identity.GetUserId();
            var test = (from x in db.Account
                        where x.UserId == userId 
                        select x.AccountId).SingleOrDefault();
            int accountId = Convert.ToInt32(test);
            List<Record> record = db.Record.Include(r => r.Account).Include(r => r.Category).Include(r => r.Currency).Where(x => x.AccountId == accountId).ToList();
            if (accountId > 0)
            {
                var record2 = (from Record in record.Where(x => x.AccountId.Equals(accountId)) select Record);
                return View(record2.ToList());
            }

            return View(record);
        }

        // GET: Records/Create
        public ActionResult Create()
        {
            ViewBag.AccountId = new SelectList(db.Account, "AccountId", "AccountName");
            ViewBag.CategoryId = new SelectList(db.Category, "CategoryId", "CategoryName");
            ViewBag.CurrencyId = new SelectList(db.Currency, "CurrencyId", "CurrencyName");
            return View();
        }


        // POST: Records/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RecordId,Amount,Note,PaymentType,AccountId,CurrencyId,CategoryId")] Record record)
        {
            record.RecordDate = DateTime.Now;
            var account = db.Account.Find(record.AccountId);
            if (ModelState.IsValid)
            {
                db.Record.Add(record);
                db.SaveChanges();
                if (account != null)
                {
                    if (record.PaymentType == true)
                    {
                        var sum = account.Amount + record.Amount;
                        account.Amount = Convert.ToDouble(sum);
                    }
                    else
                    {
                        var rest = account.Amount - record.Amount;
                        account.Amount = Convert.ToDouble(rest);
                    }
                    db.Entry(account).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            ViewBag.AccountId = new SelectList(db.Account, "AccountId", "AccountName", record.AccountId);
            ViewBag.CategoryId = new SelectList(db.Category, "CategoryId", "CategoryName", record.CategoryId);
            ViewBag.CurrencyId = new SelectList(db.Currency, "CurrencyId", "CurrencyName", record.CurrencyId);
            return View(record);
        }

        // GET: Records/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Record record = db.Record.Find(id);
            string userId = User.Identity.GetUserId();
            var account = (from x in db.Account where x.AccountId == record.AccountId && x.UserId == userId select x).FirstOrDefault();
            //if(record.)
            if (account != null)
            {
                if (record == null)
                {
                    return HttpNotFound();
                }
                ViewBag.AccountId = new SelectList(db.Account, "AccountId", "AccountName", record.AccountId);
                ViewBag.CategoryId = new SelectList(db.Category, "CategoryId", "CategoryName", record.CategoryId);
                ViewBag.CurrencyId = new SelectList(db.Currency, "CurrencyId", "CurrencyName", record.CurrencyId);
                return View(record);
            }
            else
            {                
                return RedirectToAction("Index", "Dashboard");
            }
        }

        // POST: Records/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RecordId,Amount,Note,PaymentType,AccountId,CurrencyId,CategoryId")] Record record)
        {
            if (ModelState.IsValid)
            {
                db.Entry(record).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AccountId = new SelectList(db.Account, "AccountId", "AccountName", record.AccountId);
            ViewBag.CategoryId = new SelectList(db.Category, "CategoryId", "CategoryName", record.CategoryId);
            ViewBag.CurrencyId = new SelectList(db.Currency, "CurrencyId", "CurrencyName", record.CurrencyId);
            return View(record);
        }

        // GET: Records/Delete/5
        public ActionResult Delete(int? recordId)
        {
            if (recordId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Record record = db.Record.Find(recordId);

            if (record != null)
            {

                db.Record.Remove(record);
                db.SaveChanges();
                return Json(new { ResponseCode = "200" });
            }
            else
                return Json(new { ResponseCode = "203" });
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
