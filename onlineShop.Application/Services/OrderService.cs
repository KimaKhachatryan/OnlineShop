using onlineShop.Domain.Entities;
using onlineShop.Domain.Interfaces.RepositoryInterfaces;
using onlineShop.Domain.Interfaces.ServiceInterfaces;

namespace onlineShop.Application.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;

    public OrderService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public Task<IEnumerable<Order>> GetAllAsync()
        => _orderRepository.GetAllAsync();

    public Task<Order?> GetByIdAsync(int id)
        => _orderRepository.GetByIdAsync(id);

    public Task AddAsync(Order order)
        => _orderRepository.AddAsync(order);

    public Task UpdateAsync(Order order)
        => _orderRepository.UpdateAsync(order);

    public Task DeleteAsync(int id)
        => _orderRepository.DeleteAsync(id);
}
