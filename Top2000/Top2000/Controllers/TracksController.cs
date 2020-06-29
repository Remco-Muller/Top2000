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
    public class TracksController : Controller
    {
        private Top2000Entities6 db = new Top2000Entities6();

        // GET: Tracks
        public ActionResult Index()
        {
            return View(db.Tracks.ToList());
        }

        // GET: Tracks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tracks tracks = db.Tracks.Find(id);
            if (tracks == null)
            {
                return HttpNotFound();
            }
            return View(tracks);
        }

        // GET: Tracks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tracks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "trackId,trackName,trackYear,trackArtist")] Tracks tracks)
        {
            if (ModelState.IsValid)
            {
                db.Tracks.Add(tracks);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tracks);
        }
        // GET: Tracks/Add
        public ActionResult Add(int? id)
        {
            ViewData["Listing"] = new SelectList(db.YearList, "YearListId", "YearListYear.Year");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tracks tracks = db.Tracks.Find(id);
            if (tracks == null)
            {
                return HttpNotFound();
            }
            return View(tracks);
        }

        // POST: Tracks/Add
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add([Bind(Include = "trackId,Listing")] Tracks tracks)
        {
            var Yearlist = db.YearList.SingleOrDefault(x => x.YearListId == tracks.Listing);
            if (Yearlist == null)
            {
                return RedirectToAction("Edit/1");
            }
            var TrackList = db.Tracks.SingleOrDefault(x => x.trackId == tracks.trackId);
            if (TrackList == null)
            {
                return RedirectToAction(tracks.trackId.ToString());
            }
            TrackList.YearList.Add(Yearlist);
            Yearlist.Tracks.Add(TrackList);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: Tracks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tracks tracks = db.Tracks.Find(id);
            if (tracks == null)
            {
                return HttpNotFound();
            }
            return View(tracks);
        }

        // POST: Tracks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "trackId,trackName,trackYear,trackArtist")] Tracks tracks)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tracks).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tracks);
        }

        // GET: Tracks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tracks tracks = db.Tracks.Find(id);
            if (tracks == null)
            {
                return HttpNotFound();
            }
            return View(tracks);
        }

        // POST: Tracks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tracks tracks = db.Tracks.Find(id);
            db.Tracks.Remove(tracks);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Remove(int? id)
        {
            List<YearList> set = new List<YearList>();

            foreach (var item in db.YearList)
            {
                var f = item.Tracks.SingleOrDefault(x=> x.trackId == id);
                if (f != null)
                {
                    set.Add(item);
                }
            }

            ViewData["Listing"] = new SelectList(set, "YearListId", "YearListYear.Year");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tracks tracks = db.Tracks.Find(id);
            if (tracks == null)
            {
                return HttpNotFound();
            }
            return View(tracks);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Remove([Bind(Include = "trackId,Listing")] Tracks tracks)
        {
            var Yearlist = db.YearList.SingleOrDefault(x => x.YearListId == tracks.Listing);
            if (Yearlist == null)
            {
                return RedirectToAction("Edit/1");
            }
            var TrackList = db.Tracks.SingleOrDefault(x => x.trackId == tracks.trackId);
            if (TrackList == null)
            {
                return RedirectToAction(tracks.trackId.ToString());
            }
            TrackList.YearList.Remove(Yearlist);
            Yearlist.Tracks.Remove(TrackList);
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
