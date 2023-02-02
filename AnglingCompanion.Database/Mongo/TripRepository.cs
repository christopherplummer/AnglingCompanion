using AnglingCompanion.Models;
using MongoDB.Driver;

namespace AnglingCompanion.Database.Mongo;

public class TripRepository : BaseResourceRepository<Trip>
{
    public TripRepository(IMongoClient mongoClient) : base(mongoClient)
    {
        CollectionName = "trip";
    }
}