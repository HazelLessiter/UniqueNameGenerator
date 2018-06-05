using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UniqueNameGenerator.Models;

namespace UniqueNameGenerator.Controllers
{
    public class SuffixesController : Controller
    {
        private DBEntities db = new DBEntities();

        // GET: Suffixes
        public ActionResult Index()
        {
            return View(db.Suffixes.ToList());
        }

        // GET: Suffixes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Suffix suffix = db.Suffixes.Find(id);
            if (suffix == null)
            {
                return HttpNotFound();
            }
            return View(suffix);
        }

        // GET: Suffixes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Suffixes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SuffixID,Suffix1")] Suffix suffix)
        {
            if (ModelState.IsValid)
            {
                db.Suffixes.Add(suffix);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(suffix);
        }

        // GET: Suffixes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Suffix suffix = db.Suffixes.Find(id);
            if (suffix == null)
            {
                return HttpNotFound();
            }
            return View(suffix);
        }

        // POST: Suffixes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SuffixID,Suffix1")] Suffix suffix)
        {
            if (ModelState.IsValid)
            {
                db.Entry(suffix).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(suffix);
        }

        // GET: Suffixes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Suffix suffix = db.Suffixes.Find(id);
            if (suffix == null)
            {
                return HttpNotFound();
            }
            return View(suffix);
        }

        // POST: Suffixes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Suffix suffix = db.Suffixes.Find(id);
            db.Suffixes.Remove(suffix);
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
