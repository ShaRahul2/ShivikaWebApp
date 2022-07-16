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
    public class FormsFieldsController : Controller
    {
        private ShivikaWebAppEntities db = new ShivikaWebAppEntities();

        // GET: FormsFields
        public ActionResult Index()
        {
            var formsFields = db.FormsFields.Include(f => f.FormsHeader).Include(f => f.TypeofAggregator);
            return View(formsFields.ToList());
        }

        // GET: FormsFields/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormsField formsField = db.FormsFields.Find(id);
            if (formsField == null)
            {
                return HttpNotFound();
            }
            return View(formsField);
        }

        // GET: FormsFields/Create
        public ActionResult Create()
        {
            ViewBag.FormsHeadersId = new SelectList(db.FormsHeaders, "Id", "Title");
            ViewBag.TypeOfAggregate = new SelectList(db.TypeofAggregators, "Id", "TypeofAggregate");
            return View();
        }

        // POST: FormsFields/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TestingDate,Source,TypeOfAggregate,WeightOfSample,InvoiceNo,VechleNo,FormsHeadersId")] FormsField formsField)
        {
            if (ModelState.IsValid)
            {
                db.FormsFields.Add(formsField);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FormsHeadersId = new SelectList(db.FormsHeaders, "Id", "Title", formsField.FormsHeadersId);
            ViewBag.TypeOfAggregate = new SelectList(db.TypeofAggregators, "Id", "TypeofAggregate", formsField.TypeOfAggregate);
            return View(formsField);
        }

        // GET: FormsFields/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormsField formsField = db.FormsFields.Find(id);
            if (formsField == null)
            {
                return HttpNotFound();
            }
            ViewBag.FormsHeadersId = new SelectList(db.FormsHeaders, "Id", "Title", formsField.FormsHeadersId);
            ViewBag.TypeOfAggregate = new SelectList(db.TypeofAggregators, "Id", "TypeofAggregate", formsField.TypeOfAggregate);
            return View(formsField);
        }

        // POST: FormsFields/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TestingDate,Source,TypeOfAggregate,WeightOfSample,InvoiceNo,VechleNo,FormsHeadersId")] FormsField formsField)
        {
            if (ModelState.IsValid)
            {
                formsField.ModifiedOn = DateTime.Now;
                formsField.ModifiedBy = User.Identity.GetUserId();
                db.Entry(formsField).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FormsHeadersId = new SelectList(db.FormsHeaders, "Id", "Title", formsField.FormsHeadersId);
            ViewBag.TypeOfAggregate = new SelectList(db.TypeofAggregators, "Id", "TypeofAggregate", formsField.TypeOfAggregate);
            return View(formsField);
        }

        // GET: FormsFields/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormsField formsField = db.FormsFields.Find(id);
            if (formsField == null)
            {
                return HttpNotFound();
            }
            return View(formsField);
        }

        // POST: FormsFields/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FormsField formsField = db.FormsFields.Find(id);
            db.FormsFields.Remove(formsField);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: FormsFields/Print/5
        [HttpPost, ActionName("Print")]
        [ValidateAntiForgeryToken]
        public ActionResult Print(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormsField formsField = db.FormsFields.Find(id);
            if (formsField == null)
            {
                return HttpNotFound();
            }
            return View(formsField);
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
