using TecNM.Project.App.Repositories.Interfaces;
using TecNM.Project.Core.Entities;

namespace TecNM.Project.App.Repositories;

public class InMemoryUserRepository: IUserRepository
{
    private readonly List<User> _users;

    public InMemoryUserRepository()
    {
        _users = new List<User>();
    }

    public async Task<User> SaveAsync(User user)
    {
        user.Id = _users.Count + 1;
        _users.Add(user);

        return user;
    }

    public async Task<User> UpdateAsync(User user)
    {
        var index = _users.FindIndex(x => x.Id == user.Id);

        if (index != -1)
        {
            _users[index] = user;
        }

        return await Task.FromResult(user);
    }

    public async Task<List<User>> GetAllAsync()
    {
        return _users;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        _users.RemoveAll(x => x.Id == id);

        return true;
    }

    public async Task<User> GetById(int id)
    {
        var user = _users.FirstOrDefault(x => x.Id == id);

        return await Task.FromResult(user);
    }
}