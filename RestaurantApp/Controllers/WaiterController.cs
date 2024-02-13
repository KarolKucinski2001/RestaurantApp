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
    public class WaiterController : Controller
    {
        
        // GET: Waiter
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult View(int id)
        {
            Waiter waiter;
            using (DatabaseContext db = new DatabaseContext())
                waiter = db.Waiters.FirstOrDefault(x => x.WaiterId == id);

            return View(waiter);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View(new Waiter());
        }
        [HttpPost]
        public ActionResult Create(Waiter waiter)
        {
            if (!ModelState.IsValid)
            {
                return View(new Waiter());
            }
            using (DatabaseContext db = new DatabaseContext())
            {
                db.Waiters.Add(waiter);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult ViewAll()
        {
            List<Waiter> waiters;
            using (DatabaseContext db = new DatabaseContext())
                waiters = db.Waiters.ToList();
            return View(waiters);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Waiter author;
            using (DatabaseContext db = new DatabaseContext())
                author = db.Waiters.FirstOrDefault(x => x.WaiterId == id);
            return View(author);
        }


        [HttpPost]
        public ActionResult Edit(Waiter waiter)
        {
            if (!ModelState.IsValid)
                return View(waiter);

            using (DatabaseContext db = new DatabaseContext())
            {
                db.Entry(waiter).State = EntityState.Modified;
                db.SaveChanges();
            }

            return RedirectToAction("ViewAll");
        }


        [HttpGet]
        public ActionResult Delete(int? id)
        {
            Waiter waiter;
            using (DatabaseContext db = new DatabaseContext())
            {
                waiter = db.Waiters.FirstOrDefault(x => x.WaiterId == id);
            }
            return View(waiter);
        }


        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(int? id)
        {
            Waiter waiter;
            using (DatabaseContext db = new DatabaseContext())
            {
                waiter = db.Waiters.FirstOrDefault(x => x.WaiterId == id);
                db.Waiters.Remove(waiter);
                db.SaveChanges();
            }

            return RedirectToAction("ViewAll");
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            Waiter waiter;
            using (DatabaseContext db = new DatabaseContext())
            {
                waiter = db.Waiters.FirstOrDefault(x => x.WaiterId == id);
            }
            return View(waiter);
        }
    }
}