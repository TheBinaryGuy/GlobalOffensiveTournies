using ServiceStack.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations;

namespace GlobalOffensive.Models
{
    public class Match
    {
        [AutoIncrement, PrimaryKey]
        public int Id { get; set; }

        [ServiceStack.DataAnnotations.Required, System.ComponentModel.DataAnnotations.Required]
        [Display(Name = "Team A")]
        public string TeamA { get; set; }

        [ServiceStack.DataAnnotations.Required, System.ComponentModel.DataAnnotations.Required]
        [Display(Name = "Team B")]
        public string TeamB { get; set; }

        [DataType(DataType.DateTime)]
        public DateTimeOffset StartTime { get; set; }

        [ForeignKey(typeof(Tournament), OnDelete = "CASCADE"), References(typeof(Tournament))]
        public int TournamentId { get; set; }
    }
}