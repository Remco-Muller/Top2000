using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Top2000.ExtraC;
using Top2000.Models;

namespace Top2000.Controllers
{
    public class HomeController : Controller
    {
        private Top2000Entities6 db = new Top2000Entities6();

        // GET: Home
        public ActionResult Index()
        {
            Home home = new Home();
            /*
             * Gets all database data with the paramater of the username and the lates  
             * Yearlist. Then sorts the data by votecount
             * 
             * 2020 - RM
             */
            var set = db.YearList.OrderByDescending(x => x.YearListId).Take(1).ToList();
            if (set == null)
            {
                List<vmHome> ts = new List<vmHome>();
                return View(ts) ;
            }
            int lastID = 1;
            foreach(var item in set)
            {
                lastID = item.YearListId;
            }
            List<vmHome> tracks = home.GetList(User.Identity.Name, lastID).OrderByDescending(t => t.VoteCount).Take(5).ToList();
            return View(tracks);
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
