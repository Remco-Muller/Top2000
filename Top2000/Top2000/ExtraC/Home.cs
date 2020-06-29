using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Top2000.Models;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Top2000.ExtraC
{
    public class Home
    {
        private Top2000Entities6 db = new Top2000Entities6();
        public ApplicationDbContext context = new ApplicationDbContext();
        public List<vmHome> GetList(string userName, int listYear)
        {
            var tracks = new List<vmHome>();
            foreach (var item in db.spSelectAllTitles(listYear))
            {

                tracks.Add(FindTrack(item, userName, listYear));
            }
            return tracks;
        }
        public List<vmHome> GetList(string userName, int listYear, string artistName, int publishYear)
        {
            var tracks = new List<vmHome>();
            foreach (var item in db.spSelectAllTitles(listYear))
            {
                Tracks track = db.Tracks.Find(item.Tracks_TrackId);
                if (CheckArtistName(item.Tracks_TrackId, artistName) && artistName != null)
                {
                    continue;
                }
                if (publishYear != track.trackYear.Year && publishYear != 0)
                {
                    continue;
                }
               

                
                tracks.Add(FindTrack(item, userName, listYear));
            }
            return tracks;
        }

        public vmHome FindTrack(spSelectAllTitles_Result item, string userName, int listYear)
        {
            Tracks track = db.Tracks.Find(item.Tracks_TrackId);
            var model = new vmHome()
            {
                ID = track.trackId,
                Name = track.trackName,
                TrackArtist = track.trackArtist,
                TrackYear = track.trackYear,
                ListYear = listYear,
                VoteCount = db.spSelectAllVotes(listYear, item.Tracks_TrackId).Count(),
                Voted = db.spCheckUserVote(listYear, item.Tracks_TrackId, userName).Count() != 0 ? true : false,


            };
            return model;
        }
        public bool CheckArtistName(int trackID, string ArtistName)
        {
            foreach (var items in db.spNumberOfSongsOfArtist(ArtistName))
            {
                if (items.trackId == trackID)
                {
                    return false;
                }
            }
            return true;
        }
        public bool IsUserInRole(string Username, string Rolename)
        {
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            return UserManager.IsInRole(Username, Rolename);
        }
        public IOrderedEnumerable<SelectListItem> CreateAndOrderDropdown()
        {
            return new SelectList(db.YearList, "YearListId", "YearListYear.Year").OrderByDescending(t => t.Value);
        }
    }
}