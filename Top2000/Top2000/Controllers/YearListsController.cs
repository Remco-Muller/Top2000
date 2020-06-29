using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Top2000.Models;

namespace Top2000.Controllers
{
    public class YearListsController : Controller
    {
        private Top2000Entities6 db = new Top2000Entities6();

        // GET: YearLists
        public ActionResult Index()
        {
            return View(db.YearList.ToList());
        }

        // GET: YearLists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YearList yearList = db.YearList.Find(id);
            if (yearList == null)
            {
                return HttpNotFound();
            }
            return View(yearList);
        }

        // GET: YearLists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: YearLists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "YearListId,YearListYear")] YearList yearList)
        {
            if (ModelState.IsValid)
            {
                db.YearList.Add(yearList);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(yearList);
        }

        // GET: YearLists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YearList yearList = db.YearList.Find(id);
            if (yearList == null)
            {
                return HttpNotFound();
            }
            return View(yearList);
        }

        // POST: YearLists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "YearListId,YearListYear")] YearList yearList)
        {
            if (ModelState.IsValid)
            {
                db.Entry(yearList).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(yearList);
        }

        // GET: YearLists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YearList yearList = db.YearList.Find(id);
            if (yearList == null)
            {
                return HttpNotFound();
            }
            return View(yearList);
        }

        // POST: YearLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            YearList yearList = db.YearList.Find(id);
            db.spDeleteVotes(yearList.YearListId);
            db.spDeleteTracks(yearList.YearListId);
            db.YearList.Remove(yearList);
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
