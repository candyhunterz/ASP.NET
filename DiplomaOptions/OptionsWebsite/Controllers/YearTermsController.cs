using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DiplomaDataModel;
using OptionsWebsite.DataContext;

namespace OptionsWebsite.Controllers
{
    public class YearTermsController : Controller
    {
        private DiplomaContext db = new DiplomaContext();
        private List<int> valid = new List<int>() { 10, 20, 30 };

        // GET: YearTerms
        public ActionResult Index()
        {
            return View(db.YearTerms.ToList());
        }

        // GET: YearTerms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YearTerm yearTerm = db.YearTerms.Find(id);
            if (yearTerm == null)
            {
                return HttpNotFound();
            }
            return View(yearTerm);
        }

        // GET: YearTerms/Create
        public ActionResult Create()
        {
            ViewBag.Term = new SelectList(valid);
            return View();
        }

        // POST: YearTerms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "YearTermId,Year,Term,isDefault")] YearTerm yearTerm)
        {
            if (ModelState.IsValid)
            {
                db.YearTerms.Add(yearTerm);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Term = new SelectList(valid, yearTerm.Term);
            return View(yearTerm);
        }

        // GET: YearTerms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YearTerm yearTerm = db.YearTerms.Find(id);
            if (yearTerm == null)
            {
                return HttpNotFound();
            }

            ViewBag.Term = new SelectList(valid, yearTerm.Term);
            return View(yearTerm);
        }

        // POST: YearTerms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "YearTermId,Year,Term,isDefault")] YearTerm yearTerm)
        {
            if (ModelState.IsValid)
            {
                db.Entry(yearTerm).State = EntityState.Modified;
                if(yearTerm.isDefault == true)
                {
                    setDefault(yearTerm.YearTermId);
                } else
                {
                    var current = db.YearTerms.Where(y => y.isDefault == true).FirstOrDefault();
                    if(current != null)
                    {
                        current.isDefault = true;
                    }
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Term = new SelectList(valid, yearTerm.Term);
            return View(yearTerm);
        }

        // SET: Only one default term
        public void setDefault(int? id)
        {
            var previous = db.YearTerms.Find(id);
            var current = db.YearTerms.Where(y => y.isDefault == true).FirstOrDefault();
            if (current != null)
            {
                current.isDefault = false;
                previous.isDefault = true;
            }         
        }

        // GET: YearTerms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YearTerm yearTerm = db.YearTerms.Find(id);
            if (yearTerm == null)
            {
                return HttpNotFound();
            }
            return View(yearTerm);
        }

        // POST: YearTerms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            YearTerm yearTerm = db.YearTerms.Find(id);
            if(yearTerm.isDefault == true)
            {
                var term = db.YearTerms.FirstOrDefault(y => y.isDefault == false);
                term.isDefault = true;
            }
            db.YearTerms.Remove(yearTerm);
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
