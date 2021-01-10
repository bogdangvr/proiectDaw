using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace fantasyF1.Models
{
    public class League
    {
        public int LeagueId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Roster> Rosters { get; set; }
    }
}