﻿using System;
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
        [Range(1, 4, ErrorMessage = "Expected finish must be between 1 and 4")]
        public int ExpectedFinish { get; set; }
        [Required]
        [Range(1, Int32.MaxValue)]
        public int Price { get; set; }
        public string Photo { get; set; }
        [Required]
        [Range(0, 10000)]
        public int Points { get; set; }
    }
}