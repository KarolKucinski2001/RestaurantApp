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
    public class TableSeatingsController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: TableSeatings
        public ActionResult Index()
        {
            return View(db.TableSeatings.ToList());
        }

        // GET: TableSeatings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TableSeating tableSeating = db.TableSeatings.Find(id);
            if (tableSeating == null)
            {
                return HttpNotFound();
            }
            return View(tableSeating);
        }

        // GET: TableSeatings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TableSeatings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TableSeatingId,Seats")] TableSeating tableSeating)
        {
            if (ModelState.IsValid)
            {
                db.TableSeatings.Add(tableSeating);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tableSeating);
        }

        // GET: TableSeatings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TableSeating tableSeating = db.TableSeatings.Find(id);
            if (tableSeating == null)
            {
                return HttpNotFound();
            }
            return View(tableSeating);
        }

        // POST: TableSeatings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TableSeatingId,Seats")] TableSeating tableSeating)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tableSeating).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tableSeating);
        }

        // GET: TableSeatings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TableSeating tableSeating = db.TableSeatings.Find(id);
            if (tableSeating == null)
            {
                return HttpNotFound();
            }
            return View(tableSeating);
        }

        // POST: TableSeatings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TableSeating tableSeating = db.TableSeatings.Find(id);
            db.TableSeatings.Remove(tableSeating);
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
        [HttpGet]
        public ActionResult ViewAll()
        {
            List<TableSeating> tableSeatings;
            using (DatabaseContext db = new DatabaseContext())
                tableSeatings = db.TableSeatings.ToList();
            return View(tableSeatings);
        }
    }
}
