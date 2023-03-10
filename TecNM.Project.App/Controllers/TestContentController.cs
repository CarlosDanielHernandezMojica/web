using Microsoft.AspNetCore.Mvc;
using TecNM.Project.App.Repositories.Interfaces;
using TecNM.Project.Core.Entities;
using TecNM.Project.Core.Http;

namespace TecNM.Project.App.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TestContentController: ControllerBase
{
    private readonly ITestContentRepository _testContentRepository;
    
    public TestContentController(ITestContentRepository testContentRepository)
    {
        _testContentRepository = testContentRepository;
    }
    
    [HttpGet]
    public async Task<ActionResult<Response<List<TestContent>>>> GetAll()
    {
        var testContent = await _testContentRepository.GetAllAsync();
        var response = new Response<List<TestContent>>();

        response.Data = testContent;
        
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<Response<TestContent>>> Post([FromBody] TestContent testContent)
    {
        testContent = await _testContentRepository.SaveAsync(testContent);
        var response = new Response<TestContent>();
        response.Data = testContent;

        return Created($"/api/[controller]/{testContent.Id}", response);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<TestContent>>> GetById(int id)
    {
        var testContent = await _testContentRepository.GetById(id);
        var response = new Response<TestContent>();
        response.Data = testContent;

        return Ok(response);
    }

    [HttpPut]
    public async Task<ActionResult<Response<TestContent>>> Update([FromBody] TestContent testContent)
    {
        var result = await _testContentRepository.UpdateAsync(testContent);
        var response = new Response<TestContent> { Data = result };
        
        return Ok(response);
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<bool>>> Delete(int id)
    {
        var result = await _testContentRepository.DeleteAsync(id);
        var response = new Response<bool>();
        response.Data = result;
        
        return Ok(response);
    }
}