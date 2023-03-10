using TecNM.Project.Core.Entities;

namespace TecNM.Project.App.Repositories.Interfaces;

public interface IResourceRepository
{
    //Save categories method
    Task<Resource> SaveAsync(Resource resource);
    
    //Update product categories method
    Task<Resource> UpdateAsync(Resource resource);
    
    //Return Resource list method
    Task<List<Resource>> GetAllAsync();
    
    //Return the id of the Resource that will be deleted method
    Task<bool> DeleteAsync(int id);
    
    //Get Resource by id method
    Task<Resource> GetById(int id);
}