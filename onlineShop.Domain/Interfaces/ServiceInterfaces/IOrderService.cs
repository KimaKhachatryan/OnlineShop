using onlineShop.Domain.Entities;

namespace onlineShop.Domain.Interfaces.ServiceInterfaces;

public interface IOrderService
{
    Task<IEnumerable<Order>> GetAllAsync();
    Task<Order?> GetByIdAsync(int id);
    Task AddAsync(Order order);
    Task UpdateAsync(Order order);
    Task DeleteAsync(int id);
}
