using TecNM.Project.App.Repositories.Interfaces;
using TecNM.Project.Core.Entities;

namespace TecNM.Project.App.Repositories;

public class InMemoryTestRepository: ITestRepository
{
    private readonly List<Test> _tests;

    public InMemoryTestRepository()
    {
        _tests = new List<Test>();
    }

    public async Task<Test> SaveAsync(Test test)
    {
        test.Id = _tests.Count + 1;
        _tests.Add(test);

        return test;
    }

    public async Task<Test> UpdateAsync(Test test)
    {
        var index = _tests.FindIndex(x => x.Id == test.Id);

        if (index != -1)
        {
            _tests[index] = test;
        }

        return await Task.FromResult(test);
    }

    public async Task<List<Test>> GetAllAsync()
    {
        return _tests;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        _tests.RemoveAll(x => x.Id == id);

        return true;
    }

    public async Task<Test> GetById(int id)
    {
        var test = _tests.FirstOrDefault(x => x.Id == id);

        return await Task.FromResult(test);
    }
}