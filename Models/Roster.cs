using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace fantasyF1.Models
{
    public class Roster
    {
        [Key]
        public int RosterId { get; set; }
        public int Points { get; set; }
        public int Price { get; set; }
        public string User { get; set; }
        public string UniqueCode { get; set; }
        public int TeamId { get; set; }
        public virtual Team Team { get; set; }
        public int MotorId { get; set; }
        public virtual Motor Motor { get; set; }
        public int DriverId { get; set; }
        public virtual Driver Driver { get; set; }

    }
}