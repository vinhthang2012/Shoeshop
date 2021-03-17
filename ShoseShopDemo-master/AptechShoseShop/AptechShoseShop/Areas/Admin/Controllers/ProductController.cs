using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AptechShoseShop.Models;
using System.Data;
using System.IO;
using AptechShoseShop.Models.Entites;
using System.Data.Entity;

namespace AptechShoseShop.Areas.Admin.Controllers
{

    public class ProductController : Controller
    {
        AptechShoseShopDbContext db = new AptechShoseShopDbContext();
        // GET: Admin/Product
        public ActionResult Index()
        {
            return View(db.Products.OrderByDescending(x => x.Id).ToList());
        }

        // GET: Admin/Product/Details/5
        public ActionResult Details(int id)
        {
            return View(db.Products.Where(s=>s.Id == id).FirstOrDefault());
        }

        // GET: Admin/Product/Create
        public ActionResult Create()
        {
            List<Category> cate = db.Categories.ToList();
            SelectList cateList = new SelectList(cate, "Id", "CategoryName");
            ViewBag.CategoryList = cateList;

            Product pro = new Product();
            return View(pro);
        }

        // POST: Admin/Product/Create
        [HttpPost]
        public ActionResult Create(Product pro)
        {
            try
            {
                // TODO: Add insert logic here

                if (pro.ImageUpload != null)
                {
                    string Filename = Path.GetFileNameWithoutExtension(pro.ImageUpload.FileName);
                    string extension = Path.GetExtension(pro.ImageUpload.FileName);
                    Filename = Filename + extension;
                    pro.Images = "~/Content/images/" + Filename;
                    pro.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/"), Filename));
                }
                db.Products.Add(pro);
                db.SaveChanges();
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Product/Edit/5
        public ActionResult Edit(int id)
        {
            List<Category> cate = db.Categories.ToList();
            SelectList cateList = new SelectList(cate, "Id", "CategoryName");
            ViewBag.CategoryList = cateList;
            var rs = db.Products.Where(s => s.Id == id).FirstOrDefault();
            ViewBag.date = rs.CreatedDate.ToString("yyyy-MM-dd");
            ViewBag.discountDay = rs.DiscountExpiry.ToString("yyyy-MM-dd");
            return View(rs);
        }

        // POST: Admin/Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Product pro)
        {
            try
            {

                if (pro.ImageUpload != null)
                {

                    string Filename = Path.GetFileNameWithoutExtension(pro.ImageUpload.FileName);
                    string extension = Path.GetExtension(pro.ImageUpload.FileName);
                    Filename = Filename + extension;
                    pro.Images = "~/Content/images/" + Filename;
                    pro.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/"), Filename));
                }
                db.Entry(pro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View(db.Products.Where(s => s.Id == id).FirstOrDefault());
        }

        // POST: Admin/Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Product pro)
        {
            try
            {
                // TODO: Add delete logic here
                pro = db.Products.Where(s => s.Id == id).FirstOrDefault();
                db.Products.Remove(pro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult ChooseCategory() 
        {
            Category cate = new Category();
            cate.Categorycollection = db.Categories.ToList<Category>();
            return PartialView(cate);
        }
    }
}
