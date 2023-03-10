using TecNM.Project.Core.Entities;

namespace TecNM.Project.App.Repositories.Interfaces;

public interface ITestContentRepository
{
    //Save categories method
    Task<TestContent> SaveAsync(TestContent testContent);
    
    //Update product categories method
    Task<TestContent> UpdateAsync(TestContent testContent);
    
    //Return testContent list method
    Task<List<TestContent>> GetAllAsync();
    
    //Return the id of the testContent that will be deleted method
    Task<bool> DeleteAsync(int id);
    
    //Get testContent by id method
    Task<TestContent> GetById(int id);
}