namespace Recipes.Services;

using Recipes.Interfaces;
using Recipes.Models;

public class RecipesModelService : IRecipesInterface
{
    private readonly List<RecipesModel> _recipes = new List<RecipesModel>();

    public Task<RecipesModel?> GetRecipeByIdAsync(Guid id)
    {
        return Task.FromResult(_recipes.FirstOrDefault(r => r.Id == id));
    }

    public Task<List<RecipesModel>> GetAllRecipesAsync()
    {
        return Task.FromResult(_recipes);
    }

    public Task<bool> CreateRecipeAsync(RecipesModel recipe)
    {
        try
        {
            _recipes.Add(recipe);
            return Task.FromResult(true);
        }
        catch
        {
            return Task.FromResult(false);
        }
        
    }

    public Task<RecipesModel?> UpdateRecipeAsync(RecipesModel recipe)
    {
        var existingRecipe = _recipes.FirstOrDefault(r => r.Id == recipe.Id);
        if (existingRecipe == null)
        {
            return Task.FromResult<RecipesModel?>(null);
        }

        existingRecipe.Titulo = recipe.Titulo;
        existingRecipe.descricao = recipe.descricao;
        existingRecipe.Comentarios = recipe.Comentarios;
        return Task.FromResult<RecipesModel?>(existingRecipe);
    }

    public Task<bool> DeleteRecipeAsync(Guid id)
    {
        var recipe = _recipes.FirstOrDefault(r => r.Id == id);
        if (recipe == null)
        {
            return Task.FromResult(false);
        }

        _recipes.Remove(recipe);
        return Task.FromResult(true);
    }
}