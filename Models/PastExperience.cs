using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace fantasyF1.Models
{
    public class PastExperience
    {
        [Key]
        public int PastExperienceId { get; set; }
        public string Description { get; set; }
        public string JuniorExperience { get; set; }
        public string FirstRace { get; set; }
        public string SupportChampionships { get; set; }
        public int RaceStarts { get; set; }
        public int Podiums { get; set; }
        public int Wins { get; set; }
        public int WorldChampionships { get; set; }
        [Required]
        public virtual Driver Driver { get; set; }

    }
}