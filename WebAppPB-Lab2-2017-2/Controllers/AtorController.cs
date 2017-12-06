using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebAppPB_Lab2_2017_2.Models;

namespace WebAppPB_Lab2_2017_2.Controllers
{
    public class AtorController : Controller
    {
        private CinemaContext db = new CinemaContext();

        // GET: Ator
        public ActionResult Index()
        {
            return View(db.Ators.ToList());
        }

        // GET: Ator/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ator ator = db.Ators.Find(id);
            if (ator == null)
            {
                return HttpNotFound();
            }
            return View(ator);
        }

        // GET: Ator/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ator/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AtorId,Nome")] Ator ator)
        {
            if (ModelState.IsValid)
            {
                db.Ators.Add(ator);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ator);
        }

        // GET: Ator/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ator ator = db.Ators.Find(id);
            if (ator == null)
            {
                return HttpNotFound();
            }
            return View(ator);
        }

        // POST: Ator/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AtorId,Nome")] Ator ator)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ator).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ator);
        }

        // GET: Ator/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ator ator = db.Ators.Find(id);
            if (ator == null)
            {
                return HttpNotFound();
            }
            return View(ator);
        }

        // POST: Ator/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ator ator = db.Ators.Find(id);
            db.Ators.Remove(ator);
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
