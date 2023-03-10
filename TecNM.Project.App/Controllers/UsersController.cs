using Microsoft.AspNetCore.Mvc;
using TecNM.Project.App.Repositories.Interfaces;
using TecNM.Project.Core.Entities;
using TecNM.Project.Core.Http;

namespace TecNM.Project.App.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController: ControllerBase
{
    private readonly IUserRepository _userRepository;
    
    public UsersController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    [HttpGet]
    public async Task<ActionResult<Response<List<User>>>> GetAll()
    {
        var users = await _userRepository.GetAllAsync();
        var response = new Response<List<User>>();

        response.Data = users;
        
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<Response<User>>> Post([FromBody] User user)
    {
        user = await _userRepository.SaveAsync(user);
        var response = new Response<User>();
        response.Data = user;

        return Created($"/api/[controller]/{user.Id}", response);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<User>>> GetById(int id)
    {
        var user = await _userRepository.GetById(id);
        var response = new Response<User>();
        response.Data = user;

        return Ok(response);
    }

    [HttpPut]
    public async Task<ActionResult<Response<User>>> Update([FromBody] User user)
    {
        var result = await _userRepository.UpdateAsync(user);
        var response = new Response<User> { Data = result };
        
        return Ok(response);
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<bool>>> Delete(int id)
    {
        var result = await _userRepository.DeleteAsync(id);
        var response = new Response<bool>();
        response.Data = result;
        
        return Ok(response);
    }
}