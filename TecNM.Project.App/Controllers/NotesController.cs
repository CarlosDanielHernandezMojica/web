using Microsoft.AspNetCore.Mvc;
using TecNM.Project.App.Repositories.Interfaces;
using TecNM.Project.Core.Entities;
using TecNM.Project.Core.Http;

namespace TecNM.Project.App.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NotesController: ControllerBase
{
    private readonly INoteRespository _noteRepository;
    
    public NotesController(INoteRespository noteRepository)
    {
        _noteRepository = noteRepository;
    }
    
    [HttpGet]
    public async Task<ActionResult<Response<List<Note>>>> GetAll()
    {
        var notes = await _noteRepository.GetAllAsync();
        var response = new Response<List<Note>>();

        response.Data = notes;
        
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<Response<Note>>> Post([FromBody] Note note)
    {
        note = await _noteRepository.SaveAsync(note);
        var response = new Response<Note>();
        response.Data = note;

        return Created($"/api/[controller]/{note.Id}", response);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<Note>>> GetById(int id)
    {
        var note = await _noteRepository.GetById(id);
        var response = new Response<Note>();
        response.Data = note;

        return Ok(response);
    }

    [HttpPut]
    public async Task<ActionResult<Response<Note>>> Update([FromBody] Note note)
    {
        var result = await _noteRepository.UpdateAsync(note);
        var response = new Response<Note> { Data = result };
        
        return Ok(response);
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<bool>>> Delete(int id)
    {
        var result = await _noteRepository.DeleteAsync(id);
        var response = new Response<bool>();
        response.Data = result;
        
        return Ok(response);
    }
}