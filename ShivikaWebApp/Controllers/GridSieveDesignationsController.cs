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
    public class GridSieveDesignationsController : Controller
    {
        private ShivikaWebAppEntities1 db = new ShivikaWebAppEntities1();

        // GET: GridSieveDesignations
        public ActionResult Index()
        {
            var gridSieveDesignations = db.GridSieveDesignations.Include(g => g.GridHeader);
            return View(gridSieveDesignations.ToList());
        }

        // GET: GridSieveDesignations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GridSieveDesignation gridSieveDesignation = db.GridSieveDesignations.Find(id);
            if (gridSieveDesignation == null)
            {
                return HttpNotFound();
            }
            return View(gridSieveDesignation);
        }

        // GET: GridSieveDesignations/Create
        public ActionResult Create()
        {
            ViewBag.GridHeaderType = new SelectList(db.GridHeaders, "Id", "Name");
            return View();
        }

        // POST: GridSieveDesignations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,GridHeaderType,Name")] GridSieveDesignation gridSieveDesignation)
        {
            if (ModelState.IsValid)
            {
                gridSieveDesignation.CreatedBy = User.Identity.GetUserId();
                db.GridSieveDesignations.Add(gridSieveDesignation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GridHeaderType = new SelectList(db.GridHeaders, "Id", "Name", gridSieveDesignation.GridHeaderType);
            return View(gridSieveDesignation);
        }

        // GET: GridSieveDesignations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GridSieveDesignation gridSieveDesignation = db.GridSieveDesignations.Find(id);
            if (gridSieveDesignation == null)
            {
                return HttpNotFound();
            }
            ViewBag.GridHeaderType = new SelectList(db.GridHeaders, "Id", "Name", gridSieveDesignation.GridHeaderType);
            return View(gridSieveDesignation);
        }

        // POST: GridSieveDesignations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,GridHeaderType,Name")] GridSieveDesignation gridSieveDesignation)
        {
            if (ModelState.IsValid)
            {
                gridSieveDesignation.ModifiedBy = User.Identity.GetUserId();
                gridSieveDesignation.ModifiedOn = DateTime.Now;
                db.Entry(gridSieveDesignation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GridHeaderType = new SelectList(db.GridHeaders, "Id", "Name", gridSieveDesignation.GridHeaderType);
            return View(gridSieveDesignation);
        }

        // GET: GridSieveDesignations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GridSieveDesignation gridSieveDesignation = db.GridSieveDesignations.Find(id);
            if (gridSieveDesignation == null)
            {
                return HttpNotFound();
            }
            return View(gridSieveDesignation);
        }

        // POST: GridSieveDesignations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GridSieveDesignation gridSieveDesignation = db.GridSieveDesignations.Find(id);
            db.GridSieveDesignations.Remove(gridSieveDesignation);
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
