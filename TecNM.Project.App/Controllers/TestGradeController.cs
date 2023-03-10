using Microsoft.AspNetCore.Mvc;
using TecNM.Project.App.Repositories.Interfaces;
using TecNM.Project.Core.Entities;
using TecNM.Project.Core.Http;

namespace TecNM.Project.App.Controllers;


[ApiController]
[Route("api/[controller]")]
public class TestGradeController: ControllerBase
{
    private readonly ITestGradeRepository _testGradeRepository;
    
    public TestGradeController(ITestGradeRepository testGradeRepository)
    {
        _testGradeRepository = testGradeRepository;
    }
    
    [HttpGet]
    public async Task<ActionResult<Response<List<TestGrade>>>> GetAll()
    {
        var testGrades = await _testGradeRepository.GetAllAsync();
        var response = new Response<List<TestGrade>>();

        response.Data = testGrades;
        
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<Response<TestGrade>>> Post([FromBody] TestGrade testGrade)
    {
        testGrade = await _testGradeRepository.SaveAsync(testGrade);
        var response = new Response<TestGrade>();
        response.Data = testGrade;

        return Created($"/api/[controller]/{testGrade.Id}", response);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<TestGrade>>> GetById(int id)
    {
        var testGrade = await _testGradeRepository.GetById(id);
        var response = new Response<TestGrade>();
        response.Data = testGrade;

        return Ok(response);
    }

    [HttpPut]
    public async Task<ActionResult<Response<TestGrade>>> Update([FromBody] TestGrade testGrade)
    {
        var result = await _testGradeRepository.UpdateAsync(testGrade);
        var response = new Response<TestGrade> { Data = result };
        
        return Ok(response);
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<bool>>> Delete(int id)
    {
        var result = await _testGradeRepository.DeleteAsync(id);
        var response = new Response<bool>();
        response.Data = result;
        
        return Ok(response);
    }
}