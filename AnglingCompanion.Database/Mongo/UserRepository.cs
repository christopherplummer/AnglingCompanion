using AnglingCompanion.Models;
using MongoDB.Driver;

namespace AnglingCompanion.Database.Mongo;

public class UserRepository : BaseResourceRepository<User>
{
    public UserRepository(IMongoClient mongoClient) : base(mongoClient)
    {
        CollectionName = "users";
    }
}