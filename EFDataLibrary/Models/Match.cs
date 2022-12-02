using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EFDataLibrary.Models
{
    public class Match
    {
        public int ID { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? MatchDate { get; set; }

        [Required]
        [MaxLength(50)]
        public string MatchTime { get; set; }

        [Required]
        [MaxLength(100)]
        public string TeamA { get; set; }

        [Required]
        [MaxLength(100)]
        public string TeamB { get; set; }

        public enum Sport { Voleyball,Football,Basketball }
    }
}
