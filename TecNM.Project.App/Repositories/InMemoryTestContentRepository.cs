using TecNM.Project.App.Repositories.Interfaces;
using TecNM.Project.Core.Entities;

namespace TecNM.Project.App.Repositories;

public class InMemoryTestContentRepository: ITestContentRepository
{
    private readonly List<TestContent> _testContent;

    public InMemoryTestContentRepository()
    {
        _testContent = new List<TestContent>();
    }

    public async Task<TestContent> SaveAsync(TestContent testContent)
    {
        testContent.Id = _testContent.Count + 1;
        _testContent.Add(testContent);

        return testContent;
    }

    public async Task<TestContent> UpdateAsync(TestContent testContent)
    {
        var index = _testContent.FindIndex(x => x.Id == testContent.Id);

        if (index != -1)
        {
            _testContent[index] = testContent;
        }

        return await Task.FromResult(testContent);
    }

    public async Task<List<TestContent>> GetAllAsync()
    {
        return _testContent;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        _testContent.RemoveAll(x => x.Id == id);

        return true;
    }

    public async Task<TestContent> GetById(int id)
    {
        var testContent = _testContent.FirstOrDefault(x => x.Id == id);

        return await Task.FromResult(testContent);
    }
}