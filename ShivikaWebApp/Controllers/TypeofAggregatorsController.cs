using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using ShivikaWebApp.Models;

namespace ShivikaWebApp.Controllers
{
    [Authorize]
    public class TypeofAggregatorsController : Controller
    {
        private ShivikaWebAppEntities1 db = new ShivikaWebAppEntities1();

        // GET: TypeofAggregators
        public ActionResult Index()
        {
            return View(db.TypeofAggregators.ToList());
        }

        // GET: TypeofAggregators/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeofAggregator typeofAggregator = db.TypeofAggregators.Find(id);
            if (typeofAggregator == null)
            {
                return HttpNotFound();
            }
            return View(typeofAggregator);
        }

        // GET: TypeofAggregators/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TypeofAggregators/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TypeofAggregate")] TypeofAggregator typeofAggregator)
        {
            if (ModelState.IsValid)
            {
                typeofAggregator.CreatedBy = User.Identity.GetUserId();
                db.TypeofAggregators.Add(typeofAggregator);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(typeofAggregator);
        }

        // GET: TypeofAggregators/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeofAggregator typeofAggregator = db.TypeofAggregators.Find(id);
            if (typeofAggregator == null)
            {
                return HttpNotFound();
            }
            return View(typeofAggregator);
        }

        // POST: TypeofAggregators/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TypeofAggregate")] TypeofAggregator typeofAggregator)
        {
            if (ModelState.IsValid)
            {
                typeofAggregator.ModifiedOn = DateTime.Now;
                typeofAggregator.ModifiedBy = User.Identity.GetUserId();
                db.Entry(typeofAggregator).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(typeofAggregator);
        }

        // GET: TypeofAggregators/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeofAggregator typeofAggregator = db.TypeofAggregators.Find(id);
            if (typeofAggregator == null)
            {
                return HttpNotFound();
            }
            return View(typeofAggregator);
        }

        // POST: TypeofAggregators/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TypeofAggregator typeofAggregator = db.TypeofAggregators.Find(id);
            db.TypeofAggregators.Remove(typeofAggregator);
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
