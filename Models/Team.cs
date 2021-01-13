using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace fantasyF1.Models
{
    public class Team
    {
        [Key, Required]
        public int TeamId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Range(1, 10, ErrorMessage = "Expected finish must be between 1 and 10")]
        public int ExpectedFinish { get; set; }
        [Required]
        [Range(0, 10000)]
        public int Points { get; set; }
        [Required]
        [Range(1, Int32.MaxValue)]
        public int Price { get; set; }
    }
}