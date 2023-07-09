using CinemaProject.Domain.Relationships;
using System;
using System.Collections;
using System.Collections.Generic;

namespace CinemaProject.Domain.DomainModels
{
    public class ShoppingCart : BaseEntity
    {
        public string UserId { get; set; }
        public virtual ICollection<TicketInShoppingCart> TicketsInShoppingCart { get; set; }
        public double TotalPrice { get; set; }

        public double GetTotalPrice()
        {
            double totalPrice = 0;
            foreach(var ticket in TicketsInShoppingCart)
            {
                totalPrice += ticket.Quantity * ticket.Ticket.Price;
            }
            return totalPrice;
        }
    }
}
