using TecNM.Project.Core.Entities;

namespace TecNM.Project.App.Repositories.Interfaces;

public interface ITestRepository
{
    //Save categories method
    Task<Test> SaveAsync(Test test);
    
    //Update product categories method
    Task<Test> UpdateAsync(Test test);
    
    //Return test list method
    Task<List<Test>> GetAllAsync();
    
    //Return the id of the test that will be deleted method
    Task<bool> DeleteAsync(int id);
    
    //Get test by id method
    Task<Test> GetById(int id);
}