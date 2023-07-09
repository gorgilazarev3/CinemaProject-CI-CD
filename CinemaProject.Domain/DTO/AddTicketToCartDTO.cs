using CinemaProject.Domain.DomainModels;
using System;

namespace CinemaProject.Domain.DTO
{
    public class AddTicketToCartDTO
    {
        public Guid TicketId { get; set; }
        public Ticket Ticket { get; set; }
        public string UserId { get; set; }
        public int Quantity { get; set; }
    }
}
