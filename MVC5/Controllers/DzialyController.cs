using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC5.Models;

namespace MVC5.Controllers
{
    public class DzialyController : Controller
    {
        private MVC5Entities db = new MVC5Entities();

        // GET: Dzialy
        public ActionResult Index()
        {
            return View(db.Dzialy.ToList());
        }

        // GET: Dzialy/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dzialy dzialy = db.Dzialy.Find(id);
            if (dzialy == null)
            {
                return HttpNotFound();
            }
            return View(dzialy);
        }

        // GET: Dzialy/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Dzialy/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nazwa")] Dzialy dzialy)
        {
            if (ModelState.IsValid)
            {
                db.Dzialy.Add(dzialy);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dzialy);
        }

        // GET: Dzialy/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dzialy dzialy = db.Dzialy.Find(id);
            if (dzialy == null)
            {
                return HttpNotFound();
            }
            return View(dzialy);
        }

        // POST: Dzialy/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nazwa")] Dzialy dzialy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dzialy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dzialy);
        }

        // GET: Dzialy/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dzialy dzialy = db.Dzialy.Find(id);
            if (dzialy == null)
            {
                return HttpNotFound();
            }
            return View(dzialy);
        }

        // POST: Dzialy/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Dzialy dzialy = db.Dzialy.Find(id);
            db.Dzialy.Remove(dzialy);
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
