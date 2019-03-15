using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;

namespace GlobalOffensive.WebAPI.Models
{
    public class Tournament
    {
        [AutoIncrement, PrimaryKey]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTimeOffset StartDate { get; set; }

        [Required]
        public DateTimeOffset EndDate { get; set; }

        public int NoOfTeamsParticipating { get; set; }

        public decimal PricePool { get; set; }

        [Reference]
        public List<Match> Matches { get; set; }
    }
}