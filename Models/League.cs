using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace fantasyF1.Models
{
    public class League
    {
        [Key]
        public int LeagueId { get; set; }
        public string Name { get; set; }
        public int AllowedDriverId { get; set; }
        public virtual Driver AllowedDriver { get; set; }
        public int AllowedTeamId { get; set; }
        public virtual Team AllowedTeam { get; set; }
        public int AllowedMotorId { get; set; }
        public virtual Motor AllowedMotor { get; set; }
        public string Prize { get; set; }

        public virtual ICollection<Roster> Rosters { get; set; }
    }
}