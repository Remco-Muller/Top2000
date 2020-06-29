﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Top2000.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class Top2000Entities6 : DbContext
    {
        public Top2000Entities6()
            : base("name=Top2000Entities6")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Track_YearList_User> Track_YearList_User { get; set; }
        public virtual DbSet<Tracks> Tracks { get; set; }
        public virtual DbSet<YearList> YearList { get; set; }
    
        public virtual ObjectResult<spCheckUserVote_Result> spCheckUserVote(Nullable<int> year, Nullable<int> track, string user)
        {
            var yearParameter = year.HasValue ?
                new ObjectParameter("year", year) :
                new ObjectParameter("year", typeof(int));
    
            var trackParameter = track.HasValue ?
                new ObjectParameter("track", track) :
                new ObjectParameter("track", typeof(int));
    
            var userParameter = user != null ?
                new ObjectParameter("user", user) :
                new ObjectParameter("user", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spCheckUserVote_Result>("spCheckUserVote", yearParameter, trackParameter, userParameter);
        }
    
        public virtual ObjectResult<spNumberOfSongsOfArtist_Result> spNumberOfSongsOfArtist(string name)
        {
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spNumberOfSongsOfArtist_Result>("spNumberOfSongsOfArtist", nameParameter);
        }
    
        public virtual ObjectResult<spSelectAllTitles_Result> spSelectAllTitles(Nullable<int> year)
        {
            var yearParameter = year.HasValue ?
                new ObjectParameter("Year", year) :
                new ObjectParameter("Year", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spSelectAllTitles_Result>("spSelectAllTitles", yearParameter);
        }
    
        public virtual ObjectResult<spSelectAllVotes_Result> spSelectAllVotes(Nullable<int> year, Nullable<int> track)
        {
            var yearParameter = year.HasValue ?
                new ObjectParameter("year", year) :
                new ObjectParameter("year", typeof(int));
    
            var trackParameter = track.HasValue ?
                new ObjectParameter("track", track) :
                new ObjectParameter("track", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spSelectAllVotes_Result>("spSelectAllVotes", yearParameter, trackParameter);
        }
    
        public virtual ObjectResult<spSelectListingOnYear_Result> spSelectListingOnYear(Nullable<int> yearid)
        {
            var yearidParameter = yearid.HasValue ?
                new ObjectParameter("Yearid", yearid) :
                new ObjectParameter("Yearid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spSelectListingOnYear_Result>("spSelectListingOnYear", yearidParameter);
        }
    
        public virtual int spDeleteTracks(Nullable<int> yearID)
        {
            var yearIDParameter = yearID.HasValue ?
                new ObjectParameter("YearID", yearID) :
                new ObjectParameter("YearID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spDeleteTracks", yearIDParameter);
        }
    
        public virtual int spDeleteVotes(Nullable<int> yearID)
        {
            var yearIDParameter = yearID.HasValue ?
                new ObjectParameter("YearID", yearID) :
                new ObjectParameter("YearID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spDeleteVotes", yearIDParameter);
        }
    }
}
