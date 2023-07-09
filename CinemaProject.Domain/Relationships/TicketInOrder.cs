using CinemaProject.Domain.DomainModels;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace CinemaProject.Domain.Relationships
{
    public class TicketInOrder : BaseEntity
    {
        public Guid OrderId { get; set; }
        public Guid TicketId { get; set; }
        [ForeignKey("TicketId")]
        public Ticket Ticket { get; set; }
        [ForeignKey("OrderId")]
        public Order Order { get; set; }
        public int Quantity { get; set; }
    }
}
