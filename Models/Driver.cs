using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace fantasyF1.Models
{
    public class Driver
    {
        [Key]
        public int DriverId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Number { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public string Nationality { get; set; }
        [Required]
        public int ExpectedFinish { get; set; }
        [Required]
        public int Points { get; set; }
        public virtual PastExperience PastExperience { get; set; }
        public virtual ICollection<Roster> Rosters { get; set; }

    }
}