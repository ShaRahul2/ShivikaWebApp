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
    public class GridHeadersController : Controller
    {
        private ShivikaWebAppEntities1 db = new ShivikaWebAppEntities1();

        // GET: GridHeaders
        public ActionResult Index()
        {
            var gridHeaders = db.GridHeaders.Include(g => g.FormsField);
            return View(gridHeaders.ToList());
        }

        // GET: GridHeaders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GridHeader gridHeader = db.GridHeaders.Find(id);
            if (gridHeader == null)
            {
                return HttpNotFound();
            }
            return View(gridHeader);
        }

        // GET: GridHeaders/Create
        public ActionResult Create()
        {
            ViewBag.FormType = new SelectList(db.FormsFields, "Id", "FormName");
            return View();
        }

        // POST: GridHeaders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FormType,Name,GridHeaderType")] GridHeader gridHeader)
        {
            if (ModelState.IsValid)
            {
                gridHeader.CreatedBy = User.Identity.GetUserId();
                db.GridHeaders.Add(gridHeader);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FormType = new SelectList(db.FormsFields, "Id", "FormName", gridHeader.FormType);
            return View(gridHeader);
        }

        // GET: GridHeaders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GridHeader gridHeader = db.GridHeaders.Find(id);
            if (gridHeader == null)
            {
                return HttpNotFound();
            }
            ViewBag.FormType = new SelectList(db.FormsFields, "Id", "FormName", gridHeader.FormType);
            return View(gridHeader);
        }

        // POST: GridHeaders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FormType,Name,GridHeaderType")] GridHeader gridHeader)
        {
            if (ModelState.IsValid)
            {
                gridHeader.ModifiedBy = User.Identity.GetUserId();
                gridHeader.ModifiedOn = DateTime.Now;
                db.Entry(gridHeader).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FormType = new SelectList(db.FormsFields, "Id", "FormName", gridHeader.FormType);
            return View(gridHeader);
        }

        // GET: GridHeaders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GridHeader gridHeader = db.GridHeaders.Find(id);
            if (gridHeader == null)
            {
                return HttpNotFound();
            }
            return View(gridHeader);
        }

        // POST: GridHeaders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GridHeader gridHeader = db.GridHeaders.Find(id);
            db.GridHeaders.Remove(gridHeader);
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
