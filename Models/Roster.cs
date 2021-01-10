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
        [Required]
        public string UniqueCode { get; set; }
        public int TeamId { get; set; }
        [ForeignKey("TeamId")]
        public virtual Team Team { get; set; }
        public int MotorId { get; set; }
        [ForeignKey("MotorId")]
        public virtual Motor Motor { get; set; }
        public int DriverId { get; set; }
        [ForeignKey("DriverId")]
        public virtual Driver Driver { get; set; }

    }
}