//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace EFDataLibrary.Models
{
    public class MatchOdds
    {
        public int ID { get; set; }

        [Required]
        public int MatchId { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        [ForeignKey("MatchId")]
        public Match? Match { get; set; }

        [Required]
        public char Specifier { get; set; }

        [Required]
        public decimal Odd { get; set; }

    }
}
