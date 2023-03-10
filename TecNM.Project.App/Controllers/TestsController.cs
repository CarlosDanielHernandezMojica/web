using Microsoft.AspNetCore.Mvc;
using TecNM.Project.App.Repositories.Interfaces;
using TecNM.Project.Core.Entities;
using TecNM.Project.Core.Http;

namespace TecNM.Project.App.Controllers;


[ApiController]
[Route("api/[controller]")]
public class TestsController: ControllerBase
{
    private readonly ITestRepository _testRepository;
    
    public TestsController(ITestRepository testRepository)
    {
        _testRepository = testRepository;
    }
    
    [HttpGet]
    public async Task<ActionResult<Response<List<Test>>>> GetAll()
    {
        var tests = await _testRepository.GetAllAsync();
        var response = new Response<List<Test>>();

        response.Data = tests;
        
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<Response<Test>>> Post([FromBody] Test test)
    {
        test = await _testRepository.SaveAsync(test);
        var response = new Response<Test>();
        response.Data = test;

        return Created($"/api/[controller]/{test.Id}", response);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<Test>>> GetById(int id)
    {
        var test = await _testRepository.GetById(id);
        var response = new Response<Test>();
        response.Data = test;

        return Ok(response);
    }

    [HttpPut]
    public async Task<ActionResult<Response<Test>>> Update([FromBody] Test test)
    {
        var result = await _testRepository.UpdateAsync(test);
        var response = new Response<Test> { Data = result };
        
        return Ok(response);
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<bool>>> Delete(int id)
    {
        var result = await _testRepository.DeleteAsync(id);
        var response = new Response<bool>();
        response.Data = result;
        
        return Ok(response);
    }
}