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
    public class CuentaController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Cuenta
        public ActionResult Index()
        {
            var account = db.Account.Include(a => a.AccountType).Include(a => a.Currency);
            return View(account.ToList());
        }

        // GET: Cuenta/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = db.Account.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        // GET: Cuenta/Create
        public ActionResult Create()
        {
            ViewBag.AccountTypeId = new SelectList(db.AccountType, "AccountTypeId", "AccountTypeName");
            ViewBag.CurrencyId = new SelectList(db.Currency, "CurrencyId", "CurrencyName");
            return View();
        }

        // POST: Cuenta/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AccountId,AccountName,Amount,Color,CurrencyId,AccountTypeId")] Account account)
        {

            account.CreatedDate = DateTime.Now;
            account.LastUpdate = DateTime.Now;
            account.IsActive = true;
            account.UserId = User.Identity.GetUserId();
            if (account.AccountTypeId == 1)
            {
                account.AccountIcon = "asd";
            }
            else
            {
                account.AccountIcon = "asd";
            }
            if (ModelState.IsValid)
            {
                db.Account.Add(account);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            var errors = ModelState.Values.SelectMany(v => v.Errors);

            ViewBag.AccountTypeId = new SelectList(db.AccountType, "AccountTypeId", "AccountTypeName", account.AccountTypeId);
            ViewBag.CurrencyId = new SelectList(db.Currency, "CurrencyId", "CurrencyName", account.CurrencyId);
            return View(account);
        }

        // GET: Cuenta/Edit/5
        public ActionResult Edit()
        {
            var id = String.IsNullOrEmpty(Request.QueryString["id"]) ? 0 : Convert.ToInt32(Request.QueryString["id"]);
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = db.Account.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            ViewBag.AccountTypeId = new SelectList(db.AccountType, "AccountTypeId", "AccountTypeName", account.AccountTypeId);
            ViewBag.CurrencyId = new SelectList(db.Currency, "CurrencyId", "CurrencyName", account.CurrencyId);
            return View(account);
        }

        // POST: Cuenta/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AccountName,Amount,IsActive,Color,CurrencyId,AccountTypeId")] Account account)
        {
            var id = String.IsNullOrEmpty(Request.QueryString["id"]) ? 0 : Convert.ToInt32(Request.QueryString["id"]);
            Account accountUp = db.Account.Find(id);
            if (accountUp != null)
            {
                account.AccountId = id;
                account.LastUpdate = DateTime.Now;
                db.Entry(accountUp).CurrentValues.SetValues(account);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AccountTypeId = new SelectList(db.AccountType, "AccountTypeId", "AccountTypeName", account.AccountTypeId);
            ViewBag.CurrencyId = new SelectList(db.Currency, "CurrencyId", "CurrencyName", account.CurrencyId);
            return View(account);
        }

        // GET: Cuenta/Delete/5
        [HttpPost]
        public ActionResult Delete(int? AccountId)
        {
            if (AccountId != null)
            {
                Account account = db.Account.Find(AccountId);
                if (account == null)
                {
                    return Json(new { ResponseCode = "203" });
                }
                else
                {
                    db.Account.Remove(account);
                    db.SaveChanges();
                    return Json(new { ResponseCode = "200" });
                }
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
