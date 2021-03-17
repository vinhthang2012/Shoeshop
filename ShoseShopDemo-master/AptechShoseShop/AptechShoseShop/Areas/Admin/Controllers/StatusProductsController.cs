using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AptechShoseShop.Models.Entites;

namespace AptechShoseShop.Areas.Admin.Controllers
{
    public class StatusProductsController : Controller
    {
        private AptechShoseShopDbContext db = new AptechShoseShopDbContext();

        // GET: Admin/StatusProducts
        public ActionResult Index()
        {
            return View(db.StatusProducts.ToList());
        }

        // GET: Admin/StatusProducts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StatusProduct statusProduct = db.StatusProducts.Find(id);
            if (statusProduct == null)
            {
                return HttpNotFound();
            }
            return View(statusProduct);
        }

        // GET: Admin/StatusProducts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/StatusProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,StatusName")] StatusProduct statusProduct)
        {
            if (ModelState.IsValid)
            {
                db.StatusProducts.Add(statusProduct);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(statusProduct);
        }

        // GET: Admin/StatusProducts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StatusProduct statusProduct = db.StatusProducts.Find(id);
            if (statusProduct == null)
            {
                return HttpNotFound();
            }
            return View(statusProduct);
        }

        // POST: Admin/StatusProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StatusName")] StatusProduct statusProduct)
        {
            if (ModelState.IsValid)
            {
                db.Entry(statusProduct).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(statusProduct);
        }

        // GET: Admin/StatusProducts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StatusProduct statusProduct = db.StatusProducts.Find(id);
            if (statusProduct == null)
            {
                return HttpNotFound();
            }
            return View(statusProduct);
        }

        // POST: Admin/StatusProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StatusProduct statusProduct = db.StatusProducts.Find(id);
            db.StatusProducts.Remove(statusProduct);
            db.SaveChanges();
            return RedirectToAction("Index");
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
