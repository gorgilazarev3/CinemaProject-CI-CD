using CinemaProject.Domain.DomainModels;
using CinemaProject.Domain;
using CinemaProject.Repository.Interface;
using CinemaProject.Service.Interface;
using System.Collections.Generic;
using System.Linq;

namespace CinemaProject.Service.Implementation
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public List<Order> GetAllOrders()
        {
            return _orderRepository.GetAllOrders().ToList();
        }

        public Order GetOrder(BaseEntity entity)
        {
            return _orderRepository.GetOrder(entity);
        }
    }
}
