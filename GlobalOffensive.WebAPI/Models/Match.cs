using ServiceStack.DataAnnotations;
using System;

namespace GlobalOffensive.WebAPI.Models
{
    public class Match
    {
        [AutoIncrement, PrimaryKey]
        public int Id { get; set; }

        [Required]
        public string TeamA { get; set; }

        [Required]
        public string TeamB { get; set; }

        public DateTimeOffset StartTime { get; set; }

        [ForeignKey(typeof(Tournament), OnDelete = "CASCADE"), References(typeof(Tournament))]
        public int TournamentId { get; set; }
    }
}