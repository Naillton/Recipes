namespace Recipes.Controllers;

using Microsoft.AspNetCore.Mvc;
using Recipes.Services;
using Recipes.Interfaces;
using Recipes.Models;
using System;
using System.Collections.Generic;
using Recipes.DTO;

[ApiController]
[Route("api/user/[controller]")]
public class RecipesUserController : ControllerBase
{
    private readonly IRecipesUserInterface _userService;

    public RecipesUserController(IRecipesUserInterface userService)
    {
        _userService = userService;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserModel>> GetUserById(Guid id)
    {
        try
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpGet("lists")]
    public async Task<ActionResult<List<UserModel>>> GetAllUsers()
    {
        try
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPost("create")]
    public async Task<ActionResult<UserModel>> CreateUser([FromBody] UserInsertDto userInsertDto)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new UserModel
            {
                Nome = userInsertDto.Nome,
                Email = userInsertDto.Email,
                Senha = userInsertDto.Senha
            };

            var result = await _userService.CreateUserAsync(user);
            if (result == null)
            {
                return BadRequest("User with this email already exists.");
            }

            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}