namespace Recipes.Interfaces;

using Recipes.Models;

public interface IRecipesInterface
{
    Task<RecipesModel?> GetRecipeByIdAsync(Guid id);
    Task<List<RecipesModel>> GetAllRecipesAsync();
    Task<bool> CreateRecipeAsync(RecipesModel recipe);
    Task<RecipesModel?> UpdateRecipeAsync(RecipesModel recipe);
    Task<bool> DeleteRecipeAsync(Guid id);
}