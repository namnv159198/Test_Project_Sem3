using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using PagedList;
using Test_Project_IdentityMVC.Models;

namespace Test_Project_IdentityMVC.Controllers
{
    public class ProductsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Products


        public ActionResult Index(String keyword,DateTime? start , DateTime? end,int?  status, int? page, int? limit, string sortOrder, string searchString, string currentFilter)
        
        {
            var product = db.Products.Include(p => p.CreateBy).Include(p => p.DeleteBy).Include(p => p.UpdateBy);
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

            if (!string.IsNullOrEmpty(keyword))
            {
                product = product.Where(p => p.Name.Contains(keyword));
            }

            if (status.HasValue)
            {
                product = product.Where(p => (int)p.Status == status.Value);
            }

            if (start != null)
            {
                var startDate = start.GetValueOrDefault().Date;
                startDate = startDate.Date + new TimeSpan(0, 0, 0);
                product = product.Where(p => p.CreatedAt >= startDate);
            }
            if (end != null)
            {
                var endDate = end.GetValueOrDefault().Date;
                endDate = endDate.Date + new TimeSpan(23, 59, 59);
                product = product.Where(p => p.CreatedAt <= endDate);
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
            else if (sortOrder.Equals("price-asc"))
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
            int pageSize = (limit ?? 5);

            return View(product.ToPagedList(pageNumber, pageSize));
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Content,Description,Price,Thumbnails,CreatedAt,DeletedAt,CreateById,UpdateById,DeleteById")] Product product,string[] thumbnails)
        {
            if (ModelState.IsValid)
            {
                if (thumbnails != null && thumbnails.Length > 0)
                {
                    product.Thumbnails = string.Join(",", thumbnails);
                }

                // Get userId khi đăng nhập thành công
                // Gán UserId Trong bảng Product vs UserId đăng nhập
                if ((User.Identity.GetUserId()) == null)
                {
                    return RedirectToAction("Login","Account");
                }
                product.CreateById = String.Format(User.Identity.GetUserId());
                product.CreatedAt = DateTime.Now;
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            
            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }

            
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Content,Description,Price,Thumbnails,CreatedAt,CreateById,Status")] Product product, string[] thumbnails)
        {
            if (ModelState.IsValid)
            {
                if (thumbnails != null && thumbnails.Length > 0)
                {
                    product.Thumbnails = string.Join(",", thumbnails);
                }
                if ((User.Identity.GetUserId()) == null)
                {
                    return RedirectToAction("Login", "Account");
                }
                product.UpdateById = String.Format(User.Identity.GetUserId());
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
           
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
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
