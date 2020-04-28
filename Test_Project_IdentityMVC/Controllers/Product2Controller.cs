using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Test_Project_IdentityMVC.Models;
using PagedList;
namespace Test_Project_IdentityMVC.Controllers
{
    public class Product2Controller : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Product2
        public ActionResult Index(string sortOrder, int? page,int? limit, string searchString, string currentFilter)
        {

            var product = db.Product2.AsQueryable();
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;
            if (!string.IsNullOrEmpty(searchString))
            {
                product = product.Where(p => p.Name.Contains(searchString));
            }
            if (String.IsNullOrEmpty(sortOrder) || sortOrder.Equals("date-asc"))
            {
                ViewBag.DateSortParm = "date-desc";
                ViewBag.PriceSortParm = "price-desc";
                ViewBag.NameSortParm = "name-desc";
                ViewBag.SortIcon = "fa fa-sort-asc";

            }
            else if (sortOrder.Equals("date-desc"))
            {
                ViewBag.DateSortParm = "date-asc";
                ViewBag.SortIcon = "fa fa-sort-desc";
            }
            else if ( sortOrder.Equals("price-asc"))
            {
                ViewBag.PriceSortParm = "price-desc";
                ViewBag.SortIcon = "fa fa-sort-asc";
            }
            else if (sortOrder.Equals("price-desc"))
            {
                ViewBag.PriceSortParm = "price-asc";
                ViewBag.SortIcon = "fa fa-sort-desc";
            }
            else if (sortOrder.Equals("name-asc"))
            {
                ViewBag.NameSortParm = "name-desc";
                ViewBag.SortIcon = "fa fa-sort-asc";
            }
            else if (sortOrder.Equals("name-desc"))
            {
                ViewBag.NameSortParm = "name-asc";
                ViewBag.SortIcon = "fa fa-sort-desc";
            }

            switch (sortOrder)
            {
                case "name-asc":
                    product = product.OrderBy(p => p.Name);
                    break;
                case "name-desc":
                    product = product.OrderByDescending(p => p.Name);
                    break;
                case "price-asc":
                    product = product.OrderBy(p => p.Price);
                    break;
                case "price-desc":
                    product = product.OrderByDescending(p => p.Price);
                    break;
                case "date-asc":
                    product = product.OrderBy(p => p.CreatedAt);
                    break;
                case "date-desc":
                    product = product.OrderByDescending(p => p.CreatedAt);
                    break;
                 default:
                     product = product.OrderByDescending(p => p.CreatedAt);
                     ViewBag.SortIcon = "fa fa-sort";
                    break;
            }
            int pageNumber = (page ?? 1);
            int pageSize = (limit ?? 1);
            return View(product.ToPagedList(pageNumber, pageSize));
        }

        // GET: Product2/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product2 product2 = db.Product2.Find(id);
            if (product2 == null)
            {
                return HttpNotFound();
            }
            return View(product2);
        }

        // GET: Product2/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product2/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,Content,Price,Thumbnails,CreatedAt")] Product2 product2)
        {
            if (ModelState.IsValid)
            {
                product2.CreatedAt = DateTime.Now;
                db.Product2.Add(product2);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product2);
        }

        // GET: Product2/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product2 product2 = db.Product2.Find(id);
            if (product2 == null)
            {
                return HttpNotFound();
            }
            return View(product2);
        }

        // POST: Product2/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,Content,Price,Thumbnails,CreatedAt")] Product2 product2)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product2).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product2);
        }

        // GET: Product2/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product2 product2 = db.Product2.Find(id);
            if (product2 == null)
            {
                return HttpNotFound();
            }
            return View(product2);
        }

        // POST: Product2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product2 product2 = db.Product2.Find(id);
            db.Product2.Remove(product2);
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
