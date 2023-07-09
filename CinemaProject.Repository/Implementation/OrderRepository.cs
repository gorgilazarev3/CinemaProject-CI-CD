using CinemaProject.Domain.DomainModels;
using CinemaProject.Domain;
using CinemaProject.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;
using System.Linq;

namespace CinemaProject.Repository.Implementation
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;
        private DbSet<Order> entities;

        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
            entities = context.Set<Order>();
        }

        public Order CreateNewOrder(Order entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _context.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return entities.Include(o => o.TicketHolder).Include(o => o.TicketsInOrder).ThenInclude(o => o.Ticket);
        }

        public Order GetOrder(BaseEntity entity)
        {
            return entities.Include(o => o.TicketHolder).Include(o => o.TicketsInOrder).ThenInclude(o => o.Ticket).SingleOrDefault(order => order.Id == entity.Id);
        }
    }
}
