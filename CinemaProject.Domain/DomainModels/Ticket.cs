using CinemaProject.Domain.Identity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaProject.Domain.DomainModels
{
    public class Ticket : BaseEntity
    {
        public Guid ForMovieId { get; set; }
        public double Price { get; set; }
        public DateTime ValidForDate { get; set; }
        [ForeignKey("ForMovieId")]
        public Movie Movie { get; set; }
    }
}
