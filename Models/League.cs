using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using fantasyF1.CustomValidation;

namespace fantasyF1.Models
{
    public class League
    {
        [Key]
        public int LeagueId { get; set; }
        [MinLength(4, ErrorMessage = "League's name must be at least 4 characters long!")]
        public string Name { get; set; }
        public int? AllowedDriverId { get; set; }
        public virtual Driver AllowedDriver { get; set; }
        public int? AllowedTeamId { get; set; }
        public virtual Team AllowedTeam { get; set; }
        public int? AllowedMotorId { get; set; }
        public virtual Motor AllowedMotor { get; set; }
        public string Prize { get; set; }
        [DateValidation(ErrorMessage = "Impossible")]
        public DateTime CreatedTime { get; set; }

        public virtual ICollection<Roster> Rosters { get; set; }
    }
}