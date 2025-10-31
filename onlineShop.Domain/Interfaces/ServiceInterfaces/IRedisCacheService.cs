namespace onlineShop.Domain.Interfaces.ServiceInterfaces;

public interface IRedisCacheService
{
    Task<T?> GetAsync<T>(string key);
    Task SetAsync<T>(string key, T value, TimeSpan expiration);
}
