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
        [Range(1, Int32.MaxValue)]
        public int Price { get; set; }
        [Required]
        public string Nationality { get; set; }
        public string Photo { get; set; }
        [Required]
        [Range(1, 20, ErrorMessage = "Expected finish must be between 1 and 20")]
        public int ExpectedFinish { get; set; }
        [Required]
        [Range(0, 10000)]
        public int Points { get; set; }

    }
}