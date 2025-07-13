namespace Recipes.Interfaces;

using Recipes.Models;

public interface IRecipesUserInterface
{
    Task<UserModel?> GetUserByIdAsync(Guid id);
    Task<List<UserModel>> GetAllUsersAsync();
    Task<UserModel> CreateUserAsync(UserModel user);
    Task<UserModel?> UpdateUserAsync(UserModel user);
    Task<bool> DeleteUserAsync(Guid id);
}