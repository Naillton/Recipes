namespace Recipes.Controllers;

using Microsoft.AspNetCore.Mvc;
using Recipes.Services;
using Recipes.Interfaces;
using Recipes.Models;
using System;
using System.Collections.Generic;
using Recipes.DTO;

[ApiController]
[Route("api/recipes/[controller]")]
public class RecipesController : ControllerBase
{
    private readonly IRecipesInterface _recipeService;
    public RecipesController(IRecipesInterface recipeService)
    {
        _recipeService = recipeService;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<RecipesModel>> GetRecipeById(Guid id)
    {
        try
        {
            var recipe = await _recipeService.GetRecipeByIdAsync(id);
            if (recipe == null)
            {
                return NotFound();
            }
            return Ok(recipe);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpGet]
    public async Task<ActionResult<List<RecipesModel>>> GetAllRecipes()
    {
        try
        {
            var recipes = await _recipeService.GetAllRecipesAsync();
            return Ok(recipes);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPost("create")]
    public async Task<ActionResult<RecipesModel>> CreateRecipe([FromBody] RecipeInsertDto recipe)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var RecipeModel = new RecipesModel
            {
                Titulo = recipe.Titulo,
                descricao = recipe.Descricao
            };

            var created = await _recipeService.CreateRecipeAsync(RecipeModel);
            if (!created)
            {
                return BadRequest("Recipe could not be created.");
            }

            // Retorba 201 created
            return CreatedAtAction(nameof(GetRecipeById), new { id = RecipeModel.Id }, RecipeModel);

        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPut("update")]
    public async Task<ActionResult<RecipesModel>> UpdateRecipe([FromBody] RecipeInsertDto recipe)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var RecipeModelUpdate = new RecipesModel
            {
                Titulo = recipe.Titulo,
                descricao = recipe.Descricao
            };

            var updatedRecipe = await _recipeService.UpdateRecipeAsync(RecipeModelUpdate);

            if (updatedRecipe == null)
            {
                return NotFound();
            }

            return Ok(updatedRecipe);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpDelete("delete/{id}")]
    public async Task<ActionResult> DeleteRecipe(Guid id)
    {
        try
        {
            var deleted = await _recipeService.DeleteRecipeAsync(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent(); // 204 No Content
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}