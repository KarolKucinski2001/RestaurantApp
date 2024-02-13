using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RestaurantApp.Models;
using RestaurantApp.Models.DbModels;

namespace RestaurantApp.Controllers
{
    public class OrderMenuItemsController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: OrderMenuItems
        public ActionResult Index()
        {
            var orderMenuItems = db.OrderMenuItems.Include(o => o.MenuItem).Include(o => o.Order);
            return View(orderMenuItems.ToList());
        }

        // GET: OrderMenuItems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderMenuItem orderMenuItem = db.OrderMenuItems.Find(id);
            if (orderMenuItem == null)
            {
                return HttpNotFound();
            }
            return View(orderMenuItem);
        }

        // GET: OrderMenuItems/Create
        public ActionResult Create()
        {
            ViewBag.MenuItemId = new SelectList(db.MenuItems, "MenuItemId", "MenuItemName");
            ViewBag.OrderId = new SelectList(db.Orders, "OrderId", "Comments");
            return View();
        }

        // POST: OrderMenuItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderId,MenuItemId,OrderMenuItemId,Quantity,UnitPrice")] OrderMenuItem orderMenuItem)
        {
            if (ModelState.IsValid)
            {
                db.OrderMenuItems.Add(orderMenuItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MenuItemId = new SelectList(db.MenuItems, "MenuItemId", "MenuItemName", orderMenuItem.MenuItemId);
            ViewBag.OrderId = new SelectList(db.Orders, "OrderId", "Comments", orderMenuItem.OrderId);
            return View(orderMenuItem);
        }

        // GET: OrderMenuItems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderMenuItem orderMenuItem = db.OrderMenuItems.Find(id);
            if (orderMenuItem == null)
            {
                return HttpNotFound();
            }
            ViewBag.MenuItemId = new SelectList(db.MenuItems, "MenuItemId", "MenuItemName", orderMenuItem.MenuItemId);
            ViewBag.OrderId = new SelectList(db.Orders, "OrderId", "Comments", orderMenuItem.OrderId);
            return View(orderMenuItem);
        }

        // POST: OrderMenuItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderId,MenuItemId,OrderMenuItemId,Quantity,UnitPrice")] OrderMenuItem orderMenuItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orderMenuItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MenuItemId = new SelectList(db.MenuItems, "MenuItemId", "MenuItemName", orderMenuItem.MenuItemId);
            ViewBag.OrderId = new SelectList(db.Orders, "OrderId", "Comments", orderMenuItem.OrderId);
            return View(orderMenuItem);
        }

        // GET: OrderMenuItems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderMenuItem orderMenuItem = db.OrderMenuItems.Find(id);
            if (orderMenuItem == null)
            {
                return HttpNotFound();
            }
            return View(orderMenuItem);
        }

        // POST: OrderMenuItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrderMenuItem orderMenuItem = db.OrderMenuItems.Find(id);
            db.OrderMenuItems.Remove(orderMenuItem);
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
