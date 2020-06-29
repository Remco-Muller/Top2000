using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Top2000.Models
{
    public class vmHome
    {
        [Key]
        public int ID { get; set;}
        public string Name { get; set; }
        public int VoteCount { get; set; }
        public string TrackArtist { get; set; }
        public DateTime TrackYear { get; set; }
        public bool Voted { get; set; }
        public string PostForm { get; set; }
        public int ListYear { get; set; }
        public int DropdownYear { get; set; }
    }
}