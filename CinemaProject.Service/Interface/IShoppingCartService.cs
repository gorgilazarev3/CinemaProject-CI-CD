using CinemaProject.Domain.DomainModels;
using CinemaProject.Domain.DTO;
using System;

namespace CinemaProject.Service.Interface
{
    public interface IShoppingCartService
    {
        public bool RemoveTicketFromShoppingCart(string userId, Guid ticketId);
        public bool AddTicketToShoppingCart(AddTicketToCartDTO model);
        public AddTicketToCartDTO AddTicketToShoppingCartPage(Guid ticketId);
        public ShoppingCart GetShoppingCartForUser(string userId);
        public Order CreateOrder(string userId);
    }
}
