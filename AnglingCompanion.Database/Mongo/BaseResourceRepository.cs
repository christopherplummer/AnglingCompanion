using AnglingCompanion.Models.Abstractions;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace AnglingCompanion.Database.Mongo;

public abstract class BaseResourceRepository<T> where T : Resource
{
    private readonly IMongoClient _mongoClient;
    protected string CollectionName;
    
    protected BaseResourceRepository(IMongoClient mongoClient)
    {
        _mongoClient = mongoClient;
    }
    
    public virtual async Task<List<T>> GetAll()
    {
        try
        {
            var items = await GetCollection().AsQueryable().ToListAsync();
            return items;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    public virtual async Task<List<T>> GetByUserId(Guid userId)
    {
        try
        {
            var items = await GetCollection().AsQueryable().ToListAsync();
            return items.Where(x => x.UserId == userId).ToList();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public virtual async Task<T> GetById(Guid id)
    {
        try
        {
            var item = await GetCollection().AsQueryable()
                .FirstOrDefaultAsync(w => w.Id.Equals(id));
            return item;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public virtual async Task<T> Create(T data)
    {
        data.Id = Guid.NewGuid();
        data.CreatedAt = DateTime.UtcNow;
        data.UpdatedAt = data.CreatedAt;
        
        try
        {
            await GetCollection().InsertOneAsync(data);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
        return data;
    }

    public virtual async Task<T> Update(Guid id, T data)
    {
        data.UpdatedAt = DateTime.UtcNow;
        
        try
        {
            await GetCollection().ReplaceOneAsync(x => x.Id.Equals(id), data);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
        return data;
    }

    public virtual async Task Delete(Guid id)
    {
        try
        {
            await GetCollection().DeleteOneAsync(x => x.Id == id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    private IMongoCollection<T> GetCollection()
    {
        var database = _mongoClient.GetDatabase("anglingcompanion");
        var collection = database.GetCollection<T>(CollectionName);
        return collection;
    }
}