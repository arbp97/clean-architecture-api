using Onboarding.Infrastructure.Persistence;
using Onboarding.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Onboarding.Infrastructure.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OnboardingDbContext _context;

        public OrderRepository(OnboardingDbContext context)
        {
            _context = context;
        }

        public async Task<Order> GetOrderById(Guid id)
        {
            return await _context.Orders.FindAsync(id);
        }

        public async Task<IEnumerable<Order>> GetAllOrders()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task<Order> CreateOrder(Order order)
        {
            try
            {
                var task = await _context.Orders.AddAsync(order);
                await _context.SaveChangesAsync();
                return task.Entity;
            }
            catch (DbUpdateException)
            {
                throw;
            }
            catch (OperationCanceledException)
            {
                throw;
            }
        }

        public async Task<Order> UpdateOrder(Order order)
        {
            _context.Entry(order).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return order;
        }
    }
}
