using TecNM.Project.App.Repositories.Interfaces;
using TecNM.Project.Core.Entities;

namespace TecNM.Project.App.Repositories;

public class InMemoryTestGradeRepository: ITestGradeRepository
{
    private readonly List<TestGrade> _testGrade;

    public InMemoryTestGradeRepository()
    {
        _testGrade = new List<TestGrade>();
    }

    public async Task<TestGrade> SaveAsync(TestGrade testGrade)
    {
        testGrade.Id = _testGrade.Count + 1;
        _testGrade.Add(testGrade);

        return testGrade;
    }

    public async Task<TestGrade> UpdateAsync(TestGrade testGrade)
    {
        var index = _testGrade.FindIndex(x => x.Id == testGrade.Id);

        if (index != -1)
        {
            _testGrade[index] = testGrade;
        }

        return await Task.FromResult(testGrade);
    }

    public async Task<List<TestGrade>> GetAllAsync()
    {
        return _testGrade;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        _testGrade.RemoveAll(x => x.Id == id);

        return true;
    }

    public async Task<TestGrade> GetById(int id)
    {
        var testGrade = _testGrade.FirstOrDefault(x => x.Id == id);

        return await Task.FromResult(testGrade);
    }
}