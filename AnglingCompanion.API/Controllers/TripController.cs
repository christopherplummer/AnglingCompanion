using AnglingCompanion.Database.Mongo;
using AnglingCompanion.Models;
using Microsoft.AspNetCore.Mvc;

namespace AnglingCompanion.API.Controllers;

[ApiController]
[Route("trips")]
public class TripController : ControllerBase
{
    private readonly TripRepository _tripRepository;
    
    public TripController(TripRepository tripRepository)
    {
        _tripRepository = tripRepository;
    }
    
    [HttpGet]
    public async Task<IEnumerable<Trip>> Get()
    {
        return await _tripRepository.GetAll();
    }
    
    [HttpGet("/users/{userId:guid}/trips")]
    public async Task<IEnumerable<Trip>> GetByUserId(Guid userId)
    {
        return await _tripRepository.GetByUserId(userId);
    }
    
    [HttpGet("{id:guid}")]
    public async Task<Trip> Get(Guid id)
    {
        return await _tripRepository.GetById(id);
    }
    
    [HttpPost]
    public async Task<Trip> Create(Trip request)
    {
        return await _tripRepository.Create(request);
    }
}