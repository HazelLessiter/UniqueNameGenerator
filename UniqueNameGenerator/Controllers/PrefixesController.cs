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
    public class PrefixesController : Controller
    {
        private DBEntities db = new DBEntities();

        // GET: Prefixes
        public ActionResult Index()
        {
            Random rnd = new Random();
            int i = 0;
            List<string> names = new List<string>();//Create list that contains names
            for (i = 0; i < 22; i++)//For Loop 22 times
            {
                int maxPrefixID = db.Prefixes.Max(u => u.PrefixID);//Get max prefix ID in database
                int randomPrefixID = rnd.Next(maxPrefixID);//Get random number from 0 to max ID in prefix database
                string prefix = db.Prefixes.Where(x => x.PrefixID == randomPrefixID).Select(x => x.Prefix1).First();//Grab random prefix from database
                int maxSuffixID = db.Suffixes.Max(a => a.SuffixID);//Get max suffix ID in database
                int randomSuffixID = rnd.Next(maxSuffixID);//Get random number from 0 to max ID in suffix database
                string suffix = db.Suffixes.Where(x => x.SuffixID == randomSuffixID).Select(x => x.Suffix1).First();//Grab random suffix from database
                names.Add(prefix+suffix);//Add string = prefix + suffix to list
            }
            //Send list to view 
            return View(names.ToList());
        }

        // GET: Prefixes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prefix prefix = db.Prefixes.Find(id);
            if (prefix == null)
            {
                return HttpNotFound();
            }
            return View(prefix);
        }

        // GET: Prefixes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Prefixes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PrefixID,Prefix1")] Prefix prefix)
        {
            if (ModelState.IsValid)
            {
                db.Prefixes.Add(prefix);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(prefix);
        }

        // GET: Prefixes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prefix prefix = db.Prefixes.Find(id);
            if (prefix == null)
            {
                return HttpNotFound();
            }
            return View(prefix);
        }

        // POST: Prefixes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PrefixID,Prefix1")] Prefix prefix)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prefix).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(prefix);
        }

        // GET: Prefixes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prefix prefix = db.Prefixes.Find(id);
            if (prefix == null)
            {
                return HttpNotFound();
            }
            return View(prefix);
        }

        // POST: Prefixes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Prefix prefix = db.Prefixes.Find(id);
            db.Prefixes.Remove(prefix);
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
