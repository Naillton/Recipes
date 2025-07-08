namespace Recipes.Services;

using Recipes.Interfaces;
using Recipes.Models;

public class RecipesUserService : IRecipesUserInterface
{
    private readonly List<UserModel> _users = new List<UserModel>();

    public Task<UserModel?> GetUserByIdAsync(Guid id)
    {
        return Task.FromResult(_users.FirstOrDefault(u => u.Id == id));
    }

    public Task<List<UserModel>> GetAllUsersAsync()
    {
        return Task.FromResult(_users);
    }

    public Task<bool> CreateUserAsync(UserModel user)
    {
        if (_users.Any(u => u.Email == user.Email))
        {
            return Task.FromResult(false);
        }

        _users.Add(user);
        return Task.FromResult(true);
    }

    public Task<UserModel?> UpdateUserAsync(UserModel user)
    {
        var existingUser = _users.Any(u => u.Email == user.Email && u.Id != user.Id);
        var updateUser = _users.FirstOrDefault(u => u.Id == user.Id);

        if (user == null || existingUser || updateUser == null)
        {
            return Task.FromResult<UserModel?>(null);
        }

        updateUser.Nome = user.Nome;
        updateUser.Email = user.Email;
        updateUser.Senha = user.Senha;
        return Task.FromResult<UserModel?>(updateUser);
    }

    public Task<bool> DeleteUserAsync(Guid id)
    {
        var user = _users.FirstOrDefault(u => u.Id == id);
        if (user == null)
        {
            return Task.FromResult(false);
        }

        _users.Remove(user);
        return Task.FromResult(true);
    }
}