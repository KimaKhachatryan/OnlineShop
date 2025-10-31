using onlineShop.Domain.Entities;
using onlineShop.Domain.Interfaces.RepositoryInterfaces;
using onlineShop.Domain.Interfaces.ServiceInterfaces;

namespace onlineShop.Application.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public Task<IEnumerable<Product>> GetAllAsync()
        => _productRepository.GetAllAsync();

    public Task<Product?> GetByIdAsync(int id)
        => _productRepository.GetByIdAsync(id);

    public Task AddAsync(Product product)
        => _productRepository.AddAsync(product);

    public Task UpdateAsync(Product product)
        => _productRepository.UpdateAsync(product);

    public Task DeleteAsync(int id)
        => _productRepository.DeleteAsync(id);
}
