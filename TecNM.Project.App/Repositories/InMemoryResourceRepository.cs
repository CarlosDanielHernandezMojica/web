using TecNM.Project.App.Repositories.Interfaces;
using TecNM.Project.Core.Entities;

namespace TecNM.Project.App.Repositories;

public class InMemoryResourceRepository: IResourceRepository
{
    private readonly List<Resource> _resources;

    public InMemoryResourceRepository()
    {
        _resources = new List<Resource>();
    }

    public async Task<Resource> SaveAsync(Resource resource)
    {
        resource.Id = _resources.Count + 1;
        _resources.Add(resource);

        return resource;
    }

    public async Task<Resource> UpdateAsync(Resource resource)
    {
        var index = _resources.FindIndex(x => x.Id == resource.Id);

        if (index != -1)
        {
            _resources[index] = resource;
        }

        return await Task.FromResult(resource);
    }

    public async Task<List<Resource>> GetAllAsync()
    {
        return _resources;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        _resources.RemoveAll(x => x.Id == id);

        return true;
    }

    public async Task<Resource> GetById(int id)
    {
        var resource = _resources.FirstOrDefault(x => x.Id == id);

        return await Task.FromResult(resource);
    }
}