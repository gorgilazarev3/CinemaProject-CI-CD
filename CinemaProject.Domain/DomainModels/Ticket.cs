using CinemaProject.Domain.Identity;

namespace CinemaProject.Domain.DomainModels
{
    public class Ticket : BaseEntity
    {
        public Movie ForMovie { get; set; }
        public double Price { get; set; }
    }
}
