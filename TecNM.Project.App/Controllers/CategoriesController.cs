using Microsoft.AspNetCore.Mvc;
using TecNM.Project.App.Repositories.Interfaces;
using TecNM.Project.Core.Entities;
using TecNM.Project.Core.Http;

namespace TecNM.Project.App.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController: ControllerBase
{
    private readonly ICategoryRepository _categoryRepository;
    
    public CategoriesController(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }
    
    [HttpGet]
    public async Task<ActionResult<Response<List<Category>>>> GetAll()
    {
        var categories = await _categoryRepository.GetAllAsync();
        var response = new Response<List<Category>>();

        response.Data = categories;
        
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<Response<Category>>> Post([FromBody] Category category)
    {
        category = await _categoryRepository.SaveAsync(category);
        var response = new Response<Category>();
        response.Data = category;

        return Created($"/api/[controller]/{category.Id}", response);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<Category>>> GetById(int id)
    {
        var category = await _categoryRepository.GetById(id);
        var response = new Response<Category>();
        response.Data = category;

        return Ok(response);
    }

    [HttpPut]
    public async Task<ActionResult<Response<Category>>> Update([FromBody] Category category)
    {
        var result = await _categoryRepository.UpdateAsync(category);
        var response = new Response<Category> { Data = result };
        
        return Ok(response);
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<bool>>> Delete(int id)
    {
        var result = await _categoryRepository.DeleteAsync(id);
        var response = new Response<bool>();
        response.Data = result;
        
        return Ok(response);
    }
}