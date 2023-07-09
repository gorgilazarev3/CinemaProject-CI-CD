using CinemaProject.Domain.DomainModels;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaProject.Domain.Relationships
{
    public class TicketInShoppingCart : BaseEntity
    {
        public Guid TicketId { get; set; }
        public Guid CartId { get; set; }
        public int Quantity { get; set; }

        [ForeignKey("TicketId")]
        public Ticket Ticket { get; set; }
        [ForeignKey("CartId")]
        public ShoppingCart ShoppingCart { get; set; }
    }
}
