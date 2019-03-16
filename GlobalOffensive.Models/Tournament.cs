using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GlobalOffensive.Models
{
    public class Tournament
    {
        [AutoIncrement, PrimaryKey]
        public int Id { get; set; }

        [ServiceStack.DataAnnotations.Required, System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        [ServiceStack.DataAnnotations.Required, System.ComponentModel.DataAnnotations.Required]
        [Display(Name = "From")]
        [DataType(DataType.DateTime)]
        public DateTimeOffset StartDate { get; set; }

        [ServiceStack.DataAnnotations.Required, System.ComponentModel.DataAnnotations.Required]
        [Display(Name = "To")]
        [DataType(DataType.DateTime)]
        public DateTimeOffset EndDate { get; set; }

        [Display(Name = "Teams")]
        public int NoOfTeamsParticipating { get; set; }

        [Display(Name = "Price Pool")]
        [DataType(DataType.Currency)]
        public decimal PricePool { get; set; }

        [Reference]
        public List<Match> Matches { get; set; }
    }
}