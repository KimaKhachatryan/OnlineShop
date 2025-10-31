using onlineShop.Domain.Entities;
using onlineShop.Domain.Interfaces.RepositoryInterfaces;
using onlineShop.Domain.Interfaces.ServiceInterfaces;

namespace onlineShop.Application.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IRedisCacheService _cache;
    private const string CacheKey = "categories_all";



    public CategoryService(ICategoryRepository categoryRepository, IRedisCacheService cache)
    {
        _categoryRepository = categoryRepository;
        _cache = cache;
    }

    public async Task<IEnumerable<Category>> GetAllAsync()
    {
        var cached = await _cache.GetAsync<IEnumerable<Category>>(CacheKey);
        if (cached != null)
            return cached;


        var categories = await _categoryRepository.GetAllAsync();
        await _cache.SetAsync(CacheKey, categories, TimeSpan.FromMinutes(5));



        return categories;
    }

    public Task<Category?> GetByIdAsync(int id)
        => _categoryRepository.GetByIdAsync(id);

    public Task AddAsync(Category category)
        => _categoryRepository.AddAsync(category);

    public Task UpdateAsync(Category category)
        => _categoryRepository.UpdateAsync(category);

    public Task DeleteAsync(int id)
        => _categoryRepository.DeleteAsync(id);
}
