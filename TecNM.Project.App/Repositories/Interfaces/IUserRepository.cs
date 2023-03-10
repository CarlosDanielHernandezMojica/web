using TecNM.Project.Core.Entities;

namespace TecNM.Project.App.Repositories.Interfaces;

public interface IUserRepository
{
    //Save categories method
    Task<User> SaveAsync(User user);
    
    //Update product categories method
    Task<User> UpdateAsync(User user);
    
    //Return user list method
    Task<List<User>> GetAllAsync();
    
    //Return the id of the user that will be deleted method
    Task<bool> DeleteAsync(int id);
    
    //Get user by id method
    Task<User> GetById(int id);
}