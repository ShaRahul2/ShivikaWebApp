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
    public class FormsHeadersController : Controller
    {
        private ShivikaWebAppEntities1 db = new ShivikaWebAppEntities1();

        // GET: FormsHeaders
        public ActionResult Index()
        {
            return View(db.FormsHeaders.ToList());
        }

        // GET: FormsHeaders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormsHeader formsHeader = db.FormsHeaders.Find(id);
            if (formsHeader == null)
            {
                return HttpNotFound();
            }
            return View(formsHeader);
        }

        // GET: FormsHeaders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FormsHeaders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,ProjectName,AggregateDetails")] FormsHeader formsHeader)
        {
            if (ModelState.IsValid)
            {
                formsHeader.CreatedBy = User.Identity.GetUserId();
                db.FormsHeaders.Add(formsHeader);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(formsHeader);
        }

        // GET: FormsHeaders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormsHeader formsHeader = db.FormsHeaders.Find(id);
            if (formsHeader == null)
            {
                return HttpNotFound();
            }
            return View(formsHeader);
        }

        // POST: FormsHeaders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,ProjectName,AggregateDetails")] FormsHeader formsHeader)
        {
            if (ModelState.IsValid)
            {
                formsHeader.ModifiedBy = User.Identity.GetUserId();
                formsHeader.ModifiedOn = DateTime.Now;
                db.Entry(formsHeader).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(formsHeader);
        }

        // GET: FormsHeaders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormsHeader formsHeader = db.FormsHeaders.Find(id);
            if (formsHeader == null)
            {
                return HttpNotFound();
            }
            return View(formsHeader);
        }

        // POST: FormsHeaders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FormsHeader formsHeader = db.FormsHeaders.Find(id);
            db.FormsHeaders.Remove(formsHeader);
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
