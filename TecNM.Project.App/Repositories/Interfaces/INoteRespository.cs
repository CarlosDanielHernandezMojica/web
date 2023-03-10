using TecNM.Project.Core.Entities;

namespace TecNM.Project.App.Repositories.Interfaces;

public interface INoteRespository
{
    //Save categories method
    Task<Note> SaveAsync(Note note);
    
    //Update product categories method
    Task<Note> UpdateAsync(Note note);
    
    //Return note list method
    Task<List<Note>> GetAllAsync();
    
    //Return the id of the note that will be deleted method
    Task<bool> DeleteAsync(int id);
    
    //Get note by id method
    Task<Note> GetById(int id);
}