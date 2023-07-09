using CinemaProject.Domain.DomainModels;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace CinemaProject.Domain.DTO
{
    public class TicketDTO
    {
        public Guid Id { get; set; }
        public Guid ForMovieId { get; set; }
        public double Price { get; set; }
        public DateTime ValidForDate { get; set; }
        public Movie Movie { get; set; }
    }
}
