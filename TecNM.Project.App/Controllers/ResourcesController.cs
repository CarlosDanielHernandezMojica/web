using Microsoft.AspNetCore.Mvc;
using TecNM.Project.App.Repositories.Interfaces;
using TecNM.Project.Core.Entities;
using TecNM.Project.Core.Http;

namespace TecNM.Project.App.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ResourcesController: ControllerBase
{
    private readonly IResourceRepository _resourceRepository;
    
    public ResourcesController(IResourceRepository resourceRepository)
    {
        _resourceRepository = resourceRepository;
    }
    
    [HttpGet]
    public async Task<ActionResult<Response<List<Resource>>>> GetAll()
    {
        var resources = await _resourceRepository.GetAllAsync();
        var response = new Response<List<Resource>>();

        response.Data = resources;
        
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<Response<Resource>>> Post([FromBody] Resource resource)
    {
        resource = await _resourceRepository.SaveAsync(resource);
        var response = new Response<Resource>();
        response.Data = resource;

        return Created($"/api/[controller]/{resource.Id}", response);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<Resource>>> GetById(int id)
    {
        var resource = await _resourceRepository.GetById(id);
        var response = new Response<Resource>();
        response.Data = resource;

        return Ok(response);
    }

    [HttpPut]
    public async Task<ActionResult<Response<Resource>>> Update([FromBody] Resource resource)
    {
        var result = await _resourceRepository.UpdateAsync(resource);
        var response = new Response<Resource> { Data = result };
        
        return Ok(response);
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<bool>>> Delete(int id)
    {
        var result = await _resourceRepository.DeleteAsync(id);
        var response = new Response<bool>();
        response.Data = result;
        
        return Ok(response);
    }
}