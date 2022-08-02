using Onboarding.Domain.Entities;

namespace Onboarding.Infrastructure.Repository
{
    public interface IOrderRepository
    {
        Task<Order> GetOrderById(Guid id);
        Task<IEnumerable<Order>> GetAllOrders();
        Task<Order> AddOrder(Order order);
        Task<Order> UpdateOrder(Order order);
    }
}
