namespace Recipes.Models;
using System.ComponentModel.DataAnnotations;

public class RecipesModel
{
    public Guid Id { get; private set; } = Guid.NewGuid();

    [Required(ErrorMessage = "A receita precisa ter um titulo")]
    [StringLength(100, ErrorMessage = "O titulo deve ter no maximo 100 caracteres")]
    [MinLength(8, ErrorMessage = "A receita precisa ter no minimo 8 caracteres")]
    public string Titulo { get; set; } = string.Empty;

    [Required(ErrorMessage = "A receita precisa ter uma descricao")]
    [StringLength(2000, ErrorMessage = "A descricao deve ter no maximo 2000 caracteres")]
    [MinLength(50, ErrorMessage = "A descricao da mreceita precisa ter no minimo 50 caracteres")]
    public string descricao { get; set; } = string.Empty;

    public Guid userId { get; set; } = Guid.Empty;

    public List<Comentario> Comentarios { get; set; } = new List<Comentario>();
}