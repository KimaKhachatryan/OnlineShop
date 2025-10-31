using onlineShop.Domain.Interfaces.ServiceInterfaces;
using StackExchange.Redis;
using System.Text.Json;
using IDatabase = StackExchange.Redis.IDatabase;

namespace onlineShop.Application.Services;

public class RedisCacheService : IRedisCacheService
{
    private readonly IDatabase _db;

    public RedisCacheService(IConnectionMultiplexer connection)
    {
        _db = connection.GetDatabase();
    }

    public async Task<T?> GetAsync<T>(string key)
    {
        var data = await _db.StringGetAsync(key);
        return data.HasValue
            ? JsonSerializer.Deserialize<T>(data!)
            : default;
    }

    public async Task SetAsync<T>(string key, T value, TimeSpan expiration)
    {
        var json = JsonSerializer.Serialize(value);
        await _db.StringSetAsync(key, json, expiration);
    }
}