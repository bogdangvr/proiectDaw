using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace fantasyF1.Models
{
    public class Motor
    {
        [Key, Required]
        public int MotorId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double ExpectedAverageFinish { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public int Points { get; set; }
        public virtual ICollection<Team> Teams { get; set; }
        public virtual ICollection<Roster> Rosters { get; set; }
    }
}