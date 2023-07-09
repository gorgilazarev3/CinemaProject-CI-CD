using CinemaProject.Domain.DomainModels;
using CinemaProject.Domain;
using System.Collections.Generic;

namespace CinemaProject.Service.Interface
{
    public interface IOrderService
    {
        public List<Order> GetAllOrders();
        public Order GetOrder(BaseEntity entity);
    }
}
