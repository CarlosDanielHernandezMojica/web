using TecNM.Project.Core.Entities;

namespace TecNM.Project.App.Repositories.Interfaces;

public interface ICategoryRepository
{
    //Save categories method
    Task<Category> SaveAsync(Category category);
    
    //Update product categories method
    Task<Category> UpdateAsync(Category category);
    
    //Return category list method
    Task<List<Category>> GetAllAsync();
    
    //Return the id of the category that will be deleted method
    Task<bool> DeleteAsync(int id);
    
    //Get category by id method
    Task<Category> GetById(int id);
}