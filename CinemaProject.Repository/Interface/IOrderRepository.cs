using CinemaProject.Domain.DomainModels;
using CinemaProject.Domain;
using System.Collections.Generic;

namespace CinemaProject.Repository.Interface
{
    public interface IOrderRepository
    {
        public IEnumerable<Order> GetAllOrders();
        public Order GetOrder(BaseEntity entity);
        public Order CreateNewOrder(Order entity);
    }
}
