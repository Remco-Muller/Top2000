using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Top2000.Models;
using Top2000.ExtraC;

namespace Top2000.Controllers
{
    public class ListController : Controller
    {
        private Top2000Entities6 db = new Top2000Entities6();

        // GET: Home
        public ActionResult Index()
        {
            var set = db.YearList.OrderByDescending(x => x.YearListId).Take(1).ToList();
            if (set == null)
            {
                List<vmHome> ts = new List<vmHome>();
                return View(ts);
            }
            int lastID = 1;
            foreach (var item in set)
            {
                lastID = item.YearListId;
            }
            Home home = new Home();
            List<vmHome> tracks = home.GetList(User.Identity.Name, lastID);
            ViewBag.DropdownYear = home.CreateAndOrderDropdown();
            List<vmHome> Tracks = tracks.OrderByDescending(t => t.VoteCount).ToList();
            return View(Tracks);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        //POST: Home
        public ActionResult Index(vmHome Home)
        {
            Home home = new Home();
            List<vmHome> tracks = null;
            if (Home.PostForm == "1")
            {
                if (db.spCheckUserVote(Home.ListYear, Home.ID, User.Identity.Name).Count() == 0)
                {
                    Track_YearList_User TrackYearListUser = new Track_YearList_User()
                    {
                        Track_TrackId = Home.ID,
                        Users_UserName = User.Identity.Name,
                        YearList_YearListId = Home.ListYear
                    };
                    db.Track_YearList_User.Add(TrackYearListUser);
                    db.SaveChanges();

                }
                tracks = home.GetList(User.Identity.Name, Home.ListYear);
            }else if (Home.PostForm == "2")
            {
                if (Home.TrackYear != DateTime.MinValue)
                {
                    tracks = home.GetList(User.Identity.Name, Home.DropdownYear, Home.TrackArtist, Home.TrackYear.Year);
                }
                else
                {
                    tracks = home.GetList(User.Identity.Name, Home.DropdownYear, Home.TrackArtist, 0);
                }
                
            }



            ViewBag.DropdownYear = home.CreateAndOrderDropdown();
            List<vmHome> Tracks = tracks.OrderByDescending(t => t.VoteCount).ToList();
            return View(Tracks);
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
