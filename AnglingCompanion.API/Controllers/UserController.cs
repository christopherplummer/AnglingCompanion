using AnglingCompanion.Database.Mongo;
using AnglingCompanion.Models;
using Microsoft.AspNetCore.Mvc;

namespace AnglingCompanion.API.Controllers;

[ApiController]
[Route("users")]
public class UserController : ControllerBase
{
    private readonly UserRepository _userRepository;
    
    public UserController(UserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    [HttpGet]
    public async Task<IEnumerable<User>> Get()
    {
        return await _userRepository.GetAll();
    }
    
    [HttpGet("{id:guid}")]
    public async Task<User> Get(Guid id)
    {
        return await _userRepository.GetById(id);
    }
    
    [HttpPost]
    public async Task<User> Create(User request)
    {
        return await _userRepository.Create(request);
    }
}