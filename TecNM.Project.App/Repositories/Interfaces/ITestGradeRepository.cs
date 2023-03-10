using TecNM.Project.Core.Entities;

namespace TecNM.Project.App.Repositories.Interfaces;

public interface ITestGradeRepository
{
    //Save categories method
    Task<TestGrade> SaveAsync(TestGrade testGrade);
    
    //Update product categories method
    Task<TestGrade> UpdateAsync(TestGrade testGrade);
    
    //Return testGrade list method
    Task<List<TestGrade>> GetAllAsync();
    
    //Return the id of the testGrade that will be deleted method
    Task<bool> DeleteAsync(int id);
    
    //Get testGrade by id method
    Task<TestGrade> GetById(int id);
}