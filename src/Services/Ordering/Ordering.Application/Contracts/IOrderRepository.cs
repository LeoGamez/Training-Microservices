using Ordering.Domain.Entities;

namespace Ordering.Application.Contracts
{
    public interface IOrderRepository : IAsyncRepository<Order>
    {
        Task<IEnumerable<Order>> GetOrdersByUserName(string userName);
    }
}
