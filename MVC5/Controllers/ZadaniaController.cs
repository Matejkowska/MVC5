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
    public class ZadaniaController : Controller
    {
        private MVC5Entities db = new MVC5Entities();

        // GET: Zadania
        public ActionResult Index()
        {
            var zadania = db.Zadania.Include(z => z.Dzialy).Include(z => z.Pracownicy);
            return View(zadania.ToList());
        }

        // GET: Zadania/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zadania zadania = db.Zadania.Find(id);
            if (zadania == null)
            {
                return HttpNotFound();
            }
            return View(zadania);
        }

        // GET: Zadania/Create
        public ActionResult Create()
        {
            ViewBag.IdDzialu = new SelectList(db.Dzialy, "Id", "Nazwa");
            ViewBag.IdPracownika = new SelectList(db.Pracownicy, "Id", "Nazwisko");
            return View();
        }

        // POST: Zadania/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Opis_zadania,IdPracownika,IloscGodzin,Deadline,Zlecono,IdDzialu")] Zadania zadania)
        {
            if (ModelState.IsValid)
            {
                db.Zadania.Add(zadania);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdDzialu = new SelectList(db.Dzialy, "Id", "Nazwa", zadania.IdDzialu);
            ViewBag.IdPracownika = new SelectList(db.Pracownicy, "Id", "Nazwisko", zadania.IdPracownika);
            return View(zadania);
        }

        // GET: Zadania/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zadania zadania = db.Zadania.Find(id);
            if (zadania == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdDzialu = new SelectList(db.Dzialy, "Id", "Nazwa", zadania.IdDzialu);
            ViewBag.IdPracownika = new SelectList(db.Pracownicy, "Id", "Nazwisko", zadania.IdPracownika);
            return View(zadania);
        }

        // POST: Zadania/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Opis_zadania,IdPracownika,IloscGodzin,Deadline,Zlecono,IdDzialu")] Zadania zadania)
        {
            if (ModelState.IsValid)
            {
                db.Entry(zadania).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdDzialu = new SelectList(db.Dzialy, "Id", "Nazwa", zadania.IdDzialu);
            ViewBag.IdPracownika = new SelectList(db.Pracownicy, "Id", "Nazwisko", zadania.IdPracownika);
            return View(zadania);
        }

        // GET: Zadania/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zadania zadania = db.Zadania.Find(id);
            if (zadania == null)
            {
                return HttpNotFound();
            }
            return View(zadania);
        }

        // POST: Zadania/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Zadania zadania = db.Zadania.Find(id);
            db.Zadania.Remove(zadania);
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
