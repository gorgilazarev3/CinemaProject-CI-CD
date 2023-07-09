using CinemaProject.Domain.DomainModels;
using CinemaProject.Domain.DTO;
using CinemaProject.Domain.Relationships;
using CinemaProject.Repository.Interface;
using CinemaProject.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CinemaProject.Service.Implementation
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IRepository<ShoppingCart> _shoppingCartRepository;
        private readonly IRepository<TicketInShoppingCart> _ticketInShoppingCartRepository;
        private readonly IRepository<TicketInOrder> _ticketInOrderRepository;
        private readonly IRepository<Ticket> _ticketRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IUserRepository _userRepository;

        public ShoppingCartService(IRepository<ShoppingCart> shoppingCartRepository, IRepository<TicketInShoppingCart> ticketInShoppingCartRepository, IUserRepository userRepository, IRepository<Ticket> ticketRepository, IOrderRepository orderRepository, IRepository<TicketInOrder> ticketInOrderRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
            _ticketInShoppingCartRepository = ticketInShoppingCartRepository;
            _userRepository = userRepository;
            _ticketRepository = ticketRepository;
            _orderRepository = orderRepository;
            _ticketInOrderRepository = ticketInOrderRepository;
        }

        public bool AddTicketToShoppingCart(AddTicketToCartDTO model)
        {
            var user = _userRepository.Get(model.UserId.ToString());
            var ticket = _ticketRepository.Get(model.TicketId);
            model.Ticket = ticket;
            TicketInShoppingCart ticketInShoppingCart = new TicketInShoppingCart();
            var userCart = GetShoppingCartForUser(user.Id);
            if (userCart != null)
            {
                ticketInShoppingCart.CartId = userCart.Id;
                ticketInShoppingCart.TicketId = model.TicketId;
                ticketInShoppingCart.Ticket = model.Ticket;
                ticketInShoppingCart.ShoppingCart = userCart;
                ticketInShoppingCart.Quantity = model.Quantity;
                _ticketInShoppingCartRepository.Insert(ticketInShoppingCart);
                userCart.TotalPrice = userCart.GetTotalPrice();
                _userRepository.Update(user);
                _shoppingCartRepository.Update(userCart);
                return true;
            }
           
            return false;
        }


        public AddTicketToCartDTO AddTicketToShoppingCartPage(Guid ticketId)
        {
            if (ticketId == null)
            {
                throw new ArgumentNullException("id");
            }
            var ticket = _ticketRepository.Get(ticketId);
            AddTicketToCartDTO model = new AddTicketToCartDTO();
            model.TicketId = ticket.Id;
            model.Ticket = ticket;
            model.Quantity = 0;
            return model;
        }

        public ShoppingCart GetShoppingCartForUser(string userId)
        {
            var user = _userRepository.Get(userId);
            var shoppingCart = _shoppingCartRepository.GetAll().SingleOrDefault(sc => sc.UserId == user.Id);
            Guid shoppingCartId = Guid.Empty;
            if (shoppingCart != null)
            {
                shoppingCartId = shoppingCart.Id;
            }
            var userCart = _shoppingCartRepository.Get(shoppingCartId);
            if(userCart == null)
            {
                userCart = new ShoppingCart();
                userCart.Id = Guid.NewGuid();
                userCart.UserId = userId;
                userCart.TicketsInShoppingCart = new List<TicketInShoppingCart>();
                _shoppingCartRepository.Insert(userCart);
                user.ShoppingCart = userCart;
                _userRepository.Update(user);
            }
            return userCart;
        }

        public bool RemoveTicketFromShoppingCart(string userId, Guid ticketId)
        {
            var user = _userRepository.Get(userId);
            var userCart = GetShoppingCartForUser(userId);
            if (userCart != null)
            {
                var toDelete = _ticketInShoppingCartRepository.GetAll().SingleOrDefault(p => p.TicketId == ticketId && p.CartId == userCart.Id);
                userCart.TicketsInShoppingCart.Remove(toDelete);
                userCart.TotalPrice = userCart.GetTotalPrice();
                _userRepository.Update(user);
                _shoppingCartRepository.Update(userCart);
                return true;
            }
            return false;
        }

        public Order CreateOrder(string userId)
        {
            var user = _userRepository.Get(userId);
            var userCart = user.ShoppingCart;
            if (userCart != null)
            {
                Order newOrder = new Order();
                newOrder.UserId = userId;
                newOrder.TicketHolder = user;
                _orderRepository.CreateNewOrder(newOrder);
                List<TicketInOrder> ticketsInOrders = userCart.TicketsInShoppingCart.Select(p => new TicketInOrder
                {
                    Ticket = p.Ticket,
                    TicketId = p.TicketId,
                    Quantity = p.Quantity,
                    Order = newOrder,
                    OrderId = newOrder.Id
                }).ToList();

                foreach (var item in ticketsInOrders)
                {
                    _ticketInOrderRepository.Insert(item);
                }
                user.ShoppingCart.TicketsInShoppingCart.Clear();
                _userRepository.Update(user);
                return newOrder;
            }
            throw new ArgumentNullException("Exception in the shopping cart");
        }
    }
}
