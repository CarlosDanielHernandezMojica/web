using TecNM.Project.App.Repositories.Interfaces;
using TecNM.Project.Core.Entities;

namespace TecNM.Project.App.Repositories;

public class InMemoryCategoryRepository: ICategoryRepository
{
    private readonly List<Category> _categories;

    public InMemoryCategoryRepository()
    {
        _categories = new List<Category>();
    }

    public async Task<Category> SaveAsync(Category category)
    {
        category.Id = _categories.Count + 1;
        _categories.Add(category);

        return category;
    }

    public async Task<Category> UpdateAsync(Category category)
    {
        var index = _categories.FindIndex(x => x.Id == category.Id);

        if (index != -1)
        {
            _categories[index] = category;
        }

        return await Task.FromResult(category);
    }

    public async Task<List<Category>> GetAllAsync()
    {
        return _categories;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        _categories.RemoveAll(x => x.Id == id);

        return true;
    }

    public async Task<Category> GetById(int id)
    {
        var category = _categories.FirstOrDefault(x => x.Id == id);

        return await Task.FromResult(category);
    }
}